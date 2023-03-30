using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TailGenerator))]

public class Sneak : MonoBehaviour
{
    private SneakHead head;
    private List<Segment> tail;
    private TailGenerator tailGenerator;


    private void Awake()
    {
        tailGenerator = GetComponent<TailGenerator>();

        tail = tailGenerator.Generate();
    }



}
