using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MegalodonGameManager : MonoBehaviour
{
    public static MegalodonGameManager Instance;
    [SerializeField] TextMeshProUGUI endgameText;
    [SerializeField] Button restartBtn;
    [SerializeField] SpriteRenderer scenePassBackground;
    [SerializeField] TextMeshProUGUI eraTimeText;

    float time;
    public float runSpeed;
    public float START_TIME = 5.33f;
    public float END_TIME = 2.58f;
    private void Start()
    {
        Instance = this;
        time = START_TIME;
    }

    private void Update()
    {
        if(time < END_TIME)
        {
            triggerEndScene();
        }
        else
        {
            time -= Time.deltaTime * runSpeed;
            eraTimeText.text = "Pliocene: " + System.Math.Round(time, 2) + " millions year ago";
        }
    }

    public void endGame()
    {
        endgameText.text = "You died!";
        Time.timeScale = 0;
    }

    public void triggerEndScene()
    {
        Time.timeScale = 0;
        Color color = scenePassBackground.color;
        if(color.a < 0.3f)
        {
            color.a += 0.002f;
            scenePassBackground.color = color;
        }
    }

    public bool IsSceneEnd()
    {
        return time < END_TIME;
    }
}
