using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TailGenerator))]
[RequireComponent(typeof(SnakeInput))]

public class Snake : MonoBehaviour
{
    [SerializeField] private SnakeHead snakeHead;
    [SerializeField] private float speed;
    [SerializeField] private float tailSpringiness;

    public event UnityAction<int> SizeUpdate;

    private SnakeInput snakeInput;
    private List<Segment> tail;
    private TailGenerator tailGenerator;


    private void Awake()
    {
        snakeInput = GetComponent<SnakeInput>();

        tailGenerator = GetComponent<TailGenerator>();

        tail = tailGenerator.Generate();

        SizeUpdate?.Invoke(tail.Count);
    }

    private void OnEnable()
    {
        snakeHead.BlockCollided += OnBlockCollided;
    }

    private void OnDisable()
    {
        snakeHead.BlockCollided -= OnBlockCollided;
    }



    private void FixedUpdate()
    {
        Move(snakeHead.transform.position + snakeHead.transform.up * speed * Time.fixedDeltaTime);

        snakeHead.transform.up = snakeInput.GetDirectionFromClick(snakeHead.transform.position);
    }


    private void Move(Vector3 nextPosition)
    {
        Vector3 targetPosition = snakeHead.transform.position;

        foreach (var segment in tail)
        {
            Vector3 currentPosition = segment.transform.position;
            segment.transform.position = Vector2.Lerp(segment.transform.position, targetPosition, tailSpringiness);
            targetPosition = currentPosition;
        }

        snakeHead.Move(nextPosition);
    }


    private void OnBlockCollided()
    {
        Segment deletedSegment = tail[tail.Count - 1];
        tail.Remove(deletedSegment);
        Destroy(deletedSegment.gameObject);

        SizeUpdate?.Invoke(tail.Count);
    }

}
