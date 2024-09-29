using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading;

public class JetGameManager : MonoBehaviour
{
    public static JetGameManager instance;
    public Jet player;
    public Spawner spawner;
    public GameObject WTCPrefab; // Keep the prefab reference
    private GameObject WTCInstance; // Variable to hold the instantiated WTC
    public int score;

    [SerializeField] TMP_Text scoretext;
    [SerializeField] Button PlayButton;

    private void Awake()
    {
        instance = this;
        PlayButton.gameObject.SetActive(true);
    }

    private void Start()
    {
        Pause();
    }

    public void UpdateScore()
    {
        score++;
        scoretext.text = score.ToString();

        // Stop spawning buildings when the score reaches
        if (score >= 4)
        {
            spawner.StopSpawning(); // Stop spawning
        }

        // Instantiate WTC when the score reaches
        if (score == 6 && WTCInstance == null) // Check if WTC is not already instantiated
        {
            WTCInstance = Instantiate(WTCPrefab, new Vector3(30, -0.1f, 0), Quaternion.identity);
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
        PlayButton.gameObject.SetActive(false);
        score = 0;
        scoretext.text = score.ToString();
        Time.timeScale = 1;
        player.gameObject.SetActive(true);
        player.transform.position = new Vector3(1, 0, 0);
        spawner.gameObject.SetActive(true);
        spawner.ResumeSpawning();
    }

    public void GameOver()
    {
        PlayButton.gameObject.SetActive(true);

        Thread.Sleep(1000); // Pause 1 second

        Pause();

        // Destroy all spawned buildings
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
        }

    }
}
