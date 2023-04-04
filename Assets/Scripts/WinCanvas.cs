using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinCanvas : MonoBehaviour
{
    [SerializeField] TMP_Text volumeWin;
    [SerializeField] Snake snake;

    private Canvas _canvas;

    private void OnEnable()
    {
        snake.WinVolume += PrintWinVolume;
    }

    private void Start()
    {
        _canvas = GetComponent<Canvas>();
        _canvas.enabled = false;
    }

    private void OnDisable()
    {
        snake.WinVolume -= PrintWinVolume;
    }


    private void PrintWinVolume(int volume)
    {
        _canvas.enabled = true;
        volumeWin.text = volume.ToString();
    }

}
