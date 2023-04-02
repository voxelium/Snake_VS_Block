using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TailGenerator))]
[RequireComponent(typeof(SnakeInput))]

public class Snake : MonoBehaviour
{
    [SerializeField] private SnakeHead head;
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


    private void FixedUpdate()
    {
        Move(head.transform.position + head.transform.up * speed * Time.fixedDeltaTime);

        head.transform.up = snakeInput.GetDirectionFromClick(head.transform.position);
    }


    private void Move(Vector3 nextPosition)
    {
        Vector3 targetPosition = head.transform.position;

        foreach (var segment in tail)
        {
            Vector3 currentPosition = segment.transform.position;
            segment.transform.position = Vector2.Lerp(segment.transform.position, targetPosition, tailSpringiness);
            targetPosition = currentPosition;
        }

        head.Move(nextPosition);
    }

}
