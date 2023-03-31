using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeInput : MonoBehaviour
{
    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }

    public Vector2 GetDirectionFromClick(Vector2 headPosition)
    {
        Vector3 mousePosition = Input.mousePosition;


        //Преобразует координаты экрана в координаты мира игры, так как координаты экрана могут быть разными для
        //разных телефонов, ведь экраны у разных телефонов имеют разное разрешение
        //Это вариант кода для клика в любом месте экрана
        //mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //Это вариант кода для клика только в верхней части экрана.
        //В данном случае при каждом клике Y всегда равен 1 (максимум в режиме ScreenToViewportPoint)
        mousePosition = camera.ScreenToViewportPoint(mousePosition);
        mousePosition.y = 1;
        mousePosition = camera.ViewportToWorldPoint(mousePosition);


        Vector2 direction = new Vector2(mousePosition.x - headPosition.x, mousePosition.y - headPosition.y);

        return direction;
    }
}
