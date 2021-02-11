using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSideCrosshair : MonoBehaviour
{
    [SerializeField] private Transform center;
    [SerializeField] private float radius = 2.8f;
    private Vector3 targetPos;

    void Start()
    {
        targetPos = transform.position;
    }
    
    void Update()
    {
        targetPos = Input.mousePosition;
        targetPos = Camera.main.ScreenToWorldPoint(targetPos);
        Vector3 newPosition = new Vector3(targetPos.x, targetPos.y, transform.position.z);
        if (Vector3.Distance(center.position, newPosition) <= radius)
        {
            transform.position = newPosition;
        }
    }
}
