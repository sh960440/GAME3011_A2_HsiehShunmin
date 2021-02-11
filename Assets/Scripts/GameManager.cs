using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float timer = 60.0f;
    [SerializeField] Text timerText;
    private bool isTiming = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (isTiming)
        {
            timer -= Time.deltaTime;
        }

        timerText.text = "TIME: " + timer.ToString("0.00");
        Debug.Log(timer);
    }

    public void StartTimer()
    {
        isTiming = true;
    }

    public void StopTiming()
    {
        isTiming = false;
    }
}
