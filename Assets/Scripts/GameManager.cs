using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Game.Scene1;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float START_TIME = 72.7f;
    public float END_TIME = 66.0f;
    public float time;
    public float gameSpeed { get; private set; }

    [SerializeField] private TextMeshProUGUI scoreText;
    //[SerializeField] private TextMeshProUGUI hiscoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private Button retryButton;
    [SerializeField] private Spawner spawner;

    private Player player;

    private float score;
    public float Score => score;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            time = START_TIME;
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        time = START_TIME;
        NewGame();
    }

    public void NewGame()
    {
        Obstacle1[] obstacles = FindObjectsOfType<Obstacle1>();

        foreach (var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }

        score = 0f;
        gameSpeed = initialGameSpeed;
        enabled = true;

        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);

        //UpdateHiscore();
    }

    public void GameOver()
    {
        gameSpeed = 0f;
        enabled = false;

        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);

        //UpdateHiscore();
    }

    private void Update()
    {
        if (time < END_TIME)
        {
            triggerEndScene();
        }
        else
        {
            gameSpeed += gameSpeedIncrease * Time.deltaTime;
            time -= initialGameSpeed * 0.05f * Time.deltaTime;
            score = time;
            scoreText.text = score.ToString("F4");
        }
    }

    public void triggerEndScene()
    {
        Time.timeScale = 0;
        /*Color color = scenePassBackground.color;
        if (color.a < 0.3f)
        {
            color.a += 0.002f;
            scenePassBackground.color = color;
        }*/
        SceneManager.LoadScene("MegalodonScene");
    }

    /*private void UpdateHiscore()
    {
        float hiscore = PlayerPrefs.GetFloat("hiscore", 0);

        if (score > hiscore)
        {
            hiscore = score;
            PlayerPrefs.SetFloat("hiscore", hiscore);
        }

        hiscoreText.text = Mathf.FloorToInt(hiscore).ToString("D5");
    }*/

}