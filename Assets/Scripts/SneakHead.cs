using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]

public class SneakHead : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;

    // Start is called before the first frame update
    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }



    public void Move(Vector3 newPosition)
    {
        rigidBody2D.MovePosition(newPosition);
    }
}
