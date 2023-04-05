using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasGameOver : MonoBehaviour
{

    [SerializeField] Snake _snake;
    private Canvas _canvas;

    private void Start()
    {
        _canvas = GetComponent<Canvas>();
        _canvas.enabled = false;
    }

    private void OnEnable()
    {
        _snake.ShowGameOverCanvas += ShowCanvas;
    }

    private void Ondisable()
    {
        _snake.ShowGameOverCanvas -= ShowCanvas;
    }

    private void ShowCanvas()
    {
        _canvas.enabled = true;
    }

    public void PlayButtonPressed()
    {
        // Load the level named "HighScore"
        SceneManager.LoadScene("GameScene");
    }

}
