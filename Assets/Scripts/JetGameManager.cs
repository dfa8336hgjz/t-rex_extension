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
    public int score;

    [SerializeField] TMP_Text scoretext;
    //[SerializeField] Button PlayButton;
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] Button retryButton;

    float time;
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
        // Pause();
        StartGame();
    }

    public void Update()
    {
        time += Time.deltaTime * runSpeed;

        // Ensure that time doesn't go past the END_TIME
        if (time >= END_TIME)
        {
            time = END_TIME;
        }

        // Display the time (year) in the score text
        scoretext.text = "Holocene: Year " + Mathf.FloorToInt(time).ToString();

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
        player.transform.position = new Vector3(1, 0, 0);
        spawner.gameObject.SetActive(true);
        spawner.ResumeSpawning();
    }

    public void GameOver()
    {
        //PlayButton.gameObject.SetActive(true);

        Time.timeScale = 0;
        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);

        //Pause();

        //time = START_TIME;

        /*// Destroy all spawned buildings
        foreach (GameObject building in spawner.spawnedBuildings)
        {
            if (building != null)
                Destroy(building);
        }

        // Destroy the WTC instance if it exists
        if (WTCInstance != null)
        {
            Destroy(WTCInstance);
            WTCInstance = null; // Reset the instance reference
        }*/
    }

    public void NewGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("T-Rex Scene");
    }
}
