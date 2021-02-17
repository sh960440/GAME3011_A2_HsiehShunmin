using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float timer = 60.0f;
    public int unlockedPoint = 0;
    public int playerSkill = 0;
    private bool isTiming = false;
    [SerializeField] private Text timerText;
    [SerializeField] private Text difficulty;
    [SerializeField] private Text playerSkillText;
    [SerializeField] private GameObject indicator;
    [SerializeField] private Image[] lights;
    [SerializeField] private Sprite greenLight;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;

    void Awake()
    {
        playerSkill = PlayerPrefs.GetInt("PlayerSkill");
    }

    void Start()
    {
        playerSkillText.text = "SKILL LEVEL: " + playerSkill;
    }

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
    }

    public void StartLockpicking(int level)
    {
        isTiming = true;
        switch (level)
        {
            case 1:
                FindObjectOfType<LaserController>().hasLaser = false;
                foreach(GameObject h in FindObjectOfType<LaserController>().horizontalLaser)
                    Destroy(h);
                foreach(GameObject v in FindObjectOfType<LaserController>().verticalLaser)
                    Destroy(v);
                difficulty.text = "DIFFICULTY: EASY";
                break;
            case 2:
                FindObjectOfType<LaserController>().hasLaser = true;
                difficulty.text = "DIFFICULTY: MEDIUM";
                break;
            case 3:
                FindObjectOfType<LaserController>().hasLaser = true;
                indicator.GetComponent<SpriteRenderer>().enabled = false;
                difficulty.color = Color.red;
                difficulty.text = "DIFFICULTY: HARD";
                break;
        }
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
            if (playerSkill < 10)
            playerSkill++;
        }
        else
        {
            timerText.text = "TIME: 0.00";
            loseScreen.SetActive(true);
            if (playerSkill > 0)
                playerSkill--;
        }

        PlayerPrefs.SetInt("PlayerSkill", playerSkill);
    }

    public void Replay()
    {
        SceneManager.LoadScene("Lockpicking");
    }
}
