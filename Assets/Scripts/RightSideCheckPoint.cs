    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSideCheckPoint : MonoBehaviour
{
    [SerializeField] private GameObject rightCrosshair;
    [SerializeField] private GameObject leftCrosshair;
    [SerializeField] private float radius = 2.5f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Vector3 moveTo;
    
    void Start()
    {
        FindNextPoint();
    }

    void Update()
    {
        float distance = Vector3.Distance(rightCrosshair.transform.position, transform.position);
        if (distance <= 2)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1.0f - distance / 2.0f);
            leftCrosshair.GetComponent<LeftSideCrosshair>().isMovable = distance <= 1 ? true : false;
        }

        Move();
    }

    void FindNextPoint()
    {
        moveTo = new Vector3(transform.position.x + Random.Range(-1.0f, 1.0f), transform.position.y + Random.Range(-1.0f, 1.0f), transform.position.z);
    }

    void Move()
    {
        transform.position = Vector3.Lerp(transform.position, moveTo, 0.5f * Time.deltaTime);
    }
}
