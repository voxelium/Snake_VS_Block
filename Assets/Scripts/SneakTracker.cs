using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SneakTracker : MonoBehaviour
{
    [SerializeField] SneakHead sneakHead;
    [SerializeField] private float speed;
    [SerializeField] private float offsetY;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, GetTargetPosition(), speed * Time.fixedDeltaTime);
    }

    private Vector3 GetTargetPosition()
    {
        Vector3 targetPosition = new Vector3(transform.position.x, sneakHead.transform.position.y + offsetY, transform.position.z);

        return targetPosition;
    }
}
