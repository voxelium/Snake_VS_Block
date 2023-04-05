using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResolution : MonoBehaviour
{

    private float defaultWidth;
    private Camera cameraMain;
    [SerializeField] private int GameOrthographicSize = 6;
    [SerializeField] private float GameAspect = 0.46f;


    private void Start()
    {
       cameraMain = Camera.main;
       defaultWidth = GameOrthographicSize * GameAspect;

       cameraMain.orthographicSize = defaultWidth / cameraMain.aspect;

    }


    private void Update()
    {
       //cameraMain.orthographicSize = defaultWidth / cameraMain.aspect;
    }


}
