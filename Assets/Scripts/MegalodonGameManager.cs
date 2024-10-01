using Game.Scene1;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MegalodonGameManager : MonoBehaviour
{
    public static MegalodonGameManager Instance;
    //[SerializeField] TextMeshProUGUI endgameText;
    [SerializeField] TMP_Text scoreText;
    //[SerializeField] Button restartBtn;
    [SerializeField] SpriteRenderer scenePassBackground;
    //[SerializeField] TextMeshProUGUI eraTimeText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private Button retryButton;
    [SerializeField] private Image guideImg;

    float time;
    public float runSpeed;
    private float score;
    public float START_TIME = 5.33f;
    public float END_TIME = 2.58f;
    private bool isStart = false;

    private void Start()
    {
        Instance = this;
        time = START_TIME;
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) && !isStart)
        {
            isStart = true;
            guideImg.gameObject.SetActive(false);
        }
        if (isStart)
        {
            if (time < END_TIME)
            {
                triggerEndScene();
            }
            else
            {
                time -= Time.deltaTime * runSpeed;
                score = time;
                scoreText.text = score.ToString("F4");
            }
        }
    }

    public void endGame()
    {
        Time.timeScale = 0;
        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
    }

    public void triggerEndScene()
    {
        Time.timeScale = 0;
        Color color = scenePassBackground.color;
        if (color.a < 1.0f)
        {
            color.a += 0.0008f;
            scenePassBackground.color = color;
        }

        else
        {
            // Once the fade-out effect is done, load the Jet scene
            SceneManager.LoadScene("Jet Scene");
        }
    }

    public bool IsGameStart()
    {
        return isStart;
    }

    public void NewGame()
    {
        Thread.Sleep(1000);
        Time.timeScale = 1;
        SceneManager.LoadScene("T-Rex Scene");
    }
}
