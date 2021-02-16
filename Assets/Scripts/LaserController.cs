using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] private GameObject[] horizontalLaser;
    [SerializeField] private GameObject[] verticalLaser;
    [SerializeField] private float timeInterval = 3.0f;

    private float timer = 0.0f;
    private bool isHotrizontal = false;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeInterval)
        {
            isHotrizontal = !isHotrizontal;

            foreach(GameObject h in horizontalLaser)
            {
                h.GetComponent<SpriteRenderer>().enabled = isHotrizontal;
                h.GetComponent<BoxCollider2D>().enabled = isHotrizontal;
            }

            foreach(GameObject v in verticalLaser)
            {
                v.GetComponent<SpriteRenderer>().enabled = !isHotrizontal;
                v.GetComponent<BoxCollider2D>().enabled = !isHotrizontal;
            }

            timer = 0.0f;
        }
    }
}
