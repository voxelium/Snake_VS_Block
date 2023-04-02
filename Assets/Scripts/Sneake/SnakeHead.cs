using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof (Rigidbody2D))]

public class SnakeHead : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;

    public event UnityAction BlockCollided;

    // Start is called before the first frame update
    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }


    public void Move(Vector3 newPosition)
    {
        rigidBody2D.MovePosition(newPosition);
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Block block))
        {
            BlockCollided?.Invoke();
            block.Fill();
        }
    }

  

}
