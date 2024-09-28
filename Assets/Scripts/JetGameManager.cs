using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class JetGameManager : MonoBehaviour
{
    public static JetGameManager instance;
    public Bird player;
    public Spawner spawner;
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
        player.transform.position = Vector3.zero;
        spawner.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        PlayButton.gameObject.SetActive(true);
        foreach(GameObject pipe in spawner.spawnedPipes)
        {
            if (pipe != null)
                Destroy(pipe);
        }
        Pause();
    }
}
