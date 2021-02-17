using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftSideCheckPoint : MonoBehaviour
{
    [SerializeField] private Transform center;
    [SerializeField] private float bound = 3.0f;

    void Start()
    {
        Respawn();
    }
    
    public void Respawn()
    {
        Vector3 newPosition = new Vector3(center.position.x + Random.Range(-3.0f, 3.0f), center.position.y + Random.Range(-3.0f, 3.0f), transform.position.z);
        transform.position = newPosition;
    }
}
