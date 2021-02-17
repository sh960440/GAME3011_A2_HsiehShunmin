using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSideCheckPoint : MonoBehaviour
{
    [SerializeField] private GameObject rightCrosshair;
    [SerializeField] private GameObject leftCrosshair;
    [SerializeField] private Transform center;
    [SerializeField] private float radius = 2.5f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Vector3 moveTo;
    [SerializeField] private AudioSource sound;
    
    void Start()
    {
        transform.position = new Vector3(Random.Range(3.0f, 6.0f), Random.Range(2.0f, -2.0f), transform.position.z);
        moveTo = transform.position;
    }

    void Update()
    {
        float distance = Vector3.Distance(rightCrosshair.transform.position, transform.position);
        if (distance <= 2)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1.0f - distance / 2.0f);
            sound.volume = 0.5f - distance / 4;
            leftCrosshair.GetComponent<LeftSideCrosshair>().isMovable = distance <= 1 + FindObjectOfType<GameManager>().playerSkill * 0.1f ? true : false;
        }
        else
        {
            sound.volume = 0;
        }

        if (leftCrosshair.GetComponent<LeftSideCrosshair>().distanceCounter >= 2.0f)
        {
            leftCrosshair.GetComponent<LeftSideCrosshair>().distanceCounter = 0.0f;
            FindNextPoint();
        }

        transform.position = Vector3.Lerp(transform.position, moveTo, 0.5f * Time.deltaTime);
    }

    void FindNextPoint()
    {
        do 
        {
            moveTo = new Vector3(transform.position.x + Random.Range(-1.0f, 1.0f), transform.position.y + Random.Range(-1.0f, 1.0f), transform.position.z);
        } 
        while(Vector3.Distance(moveTo, center.position) >= radius);
    }
}
