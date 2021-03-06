﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftSideCrosshair : MonoBehaviour
{
    [SerializeField] private Transform center;
    [SerializeField] private float bound = 3.0f;
    [SerializeField] private float speed = 1.0f;
    public bool isMovable = false;
    public float distanceCounter = 0.0f;

    void Start()
    {
        speed = 1.0f + FindObjectOfType<GameManager>().playerSkill * 0.2f;
    }

    void Update()
    {
        if (isMovable)
        {
            Vector3 move = new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * speed, Input.GetAxis("Vertical") * Time.deltaTime * speed, transform.position.z);
            
            if ((transform.position.x >= center.position.x + bound && Input.GetAxis("Horizontal") > 0) || 
                (transform.position.x <= center.position.x - bound && Input.GetAxis("Horizontal") < 0))
            {
                move.x = 0;
            }
            
            if ((transform.position.y >= center.position.y + bound && Input.GetAxis("Vertical") > 0) || 
                (transform.position.y <= center.position.y - bound && Input.GetAxis("Vertical") < 0))
            {
                move.y = 0;
            }
            
            transform.position += move;
            distanceCounter += move.magnitude;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LeftPoint"))
        {            
            FindObjectOfType<GameManager>().Unlock();
            FindObjectOfType<LeftSideCheckPoint>().Respawn();
        }

        if (other.CompareTag("Laser"))
        {            
            FindObjectOfType<GameManager>().Gameover(false);
        }
    }
}