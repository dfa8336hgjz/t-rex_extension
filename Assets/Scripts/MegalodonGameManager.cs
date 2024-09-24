using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MegalodonGameManager : MonoBehaviour
{
    public static MegalodonGameManager Instance;
    [SerializeField] TextMeshProUGUI endgameText;
    private void Start()
    {
        Instance = this;
    }

    public void endGame()
    {
        endgameText.text = "You died!";
        Time.timeScale = 0;
    }
}
