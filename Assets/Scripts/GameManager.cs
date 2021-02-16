using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float timer = 60.0f;
    public int unlockedPoint = 0;
    [SerializeField] Text timerText;
    private bool isTiming = false;
    [SerializeField] private Image[] lights;
    [SerializeField] private Sprite greenLight;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;

    void Update()
    {
        if (isTiming)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Gameover(false);
            }
        }

        timerText.text = "TIME: " + timer.ToString("0.00");
        //Debug.Log(timer);
    }

    public void StartTimer()
    {
        isTiming = true;
    }

    public void StopTiming()
    {
        isTiming = false;
    }

    public void Unlock()
    {
        unlockedPoint += 1;
        lights[unlockedPoint - 1].sprite = greenLight;
        if (unlockedPoint >= 5)
             Gameover(true); 
    }

    public void Gameover(bool won)
    {
        isTiming = false;
        FindObjectOfType<LeftSideCrosshair>().gameObject.SetActive(false);
        FindObjectOfType<RightSideCrosshair>().gameObject.SetActive(false);

        if (won)
        {
            winScreen.SetActive(true);
        }
        else
        {
            timerText.text = "TIME: 0.00";
            loseScreen.SetActive(true);
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("Lockpicking");
    }
}
