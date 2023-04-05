using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasWin : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI volumeWin;
    [SerializeField] Snake snake;

    private Canvas _canvas;

    private void OnEnable()
    {
        snake.ShowWinCanvas += PrintWinVolume;
    }

    private void Start()
    {
        _canvas = GetComponent<Canvas>();
        _canvas.enabled = false;
    }

    private void OnDisable()
    {
        snake.ShowWinCanvas -= PrintWinVolume;
    }


    private void PrintWinVolume(int volume)
    {
        _canvas.enabled = true;
        volumeWin.text = volume.ToString();
    }


    public void PlayButtonPressed()
    {
        // Load the level named "HighScore"
        SceneManager.LoadScene("GameScene");
    }

}
