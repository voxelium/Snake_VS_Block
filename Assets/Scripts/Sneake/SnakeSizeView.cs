using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Snake))]

public class SnakeSizeView : MonoBehaviour
{
    [SerializeField] TMP_Text sizeView;
    private Snake snake;

    private void Awake()
    {
        snake = GetComponent<Snake>();
    }


    private void OnEnable()
    {
        snake.SizeUpdate += PrintSizeUpdate;
    }


    private void OnDisable()
    {
        snake.SizeUpdate -= PrintSizeUpdate;
    }

    private void PrintSizeUpdate(int size)
    {
        sizeView.text = size.ToString();

    }


}
