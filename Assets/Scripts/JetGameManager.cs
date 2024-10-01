using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class JetGameManager : MonoBehaviour
{
    public static JetGameManager instance;
    public Jet player;
    public buildingSpawner spawner;
    public GameObject WTCPrefab; // Keep the prefab reference
    private GameObject WTCInstance; // Variable to hold the instantiated WTC
    //public int score;
    public bool isStart = false;

    [SerializeField] TMP_Text scoreText;
    //[SerializeField] Button PlayButton;
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] Button retryButton;
    [SerializeField] SpriteRenderer guideImg;

    float time;
    private float score;
    public float runSpeed = 10f;
    public float START_TIME = 1914f;
    public float END_TIME = 2001f;

    private void Awake()
    {
        instance = this;
        time = START_TIME;
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
    }

    private void Start()
    {
        StartGame();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isStart)
        {
            isStart = true;
            player.setGravityOn();
            guideImg.gameObject.SetActive(false);
        }
        if(isStart)
        {
            time += Time.deltaTime * runSpeed;
            score = time;
            scoreText.text = Mathf.FloorToInt(score).ToString("D5");

            // Ensure that time doesn't go past the END_TIME
            if (time >= END_TIME)
            {
                time = END_TIME;
            }

            // Display the time (year) in the score text
            //scoretext.text = "Holocene: Year " + Mathf.FloorToInt(time).ToString();

            // Stop spawning buildings when the score reaches
            if (time >= 1990)
            {
                spawner.StopSpawning(); // Stop spawning
            }

            // Instantiate WTC when the score reaches
            if (time == 2001 && WTCInstance == null) // Check if WTC is not already instantiated
            {
                WTCInstance = Instantiate(WTCPrefab, new Vector3(15, -0.1f, 0), Quaternion.identity);
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        //PlayButton.gameObject.SetActive(false);
        Time.timeScale = 1;
        player.gameObject.SetActive(true);
        player.transform.position = new Vector3(-3, 0, 0);
        player.setGravityOff();
        spawner.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
    }

    public void NewGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("T-Rex Scene");
    }
}
