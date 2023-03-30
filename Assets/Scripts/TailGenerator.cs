using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailGenerator : MonoBehaviour
{
    [SerializeField] private int snakeSize;
    [SerializeField] Segment segment;


    public List<Segment> Generate()
    {
        List<Segment> tail = new List<Segment>();

        for (int i = 0; i < snakeSize; i++)
        {
            tail.Add(Instantiate(segment, transform));
        }

        return tail;
    }
}
