using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameEnd : MonoBehaviour
{
    static GameEnd _instance;
    public GameObject gameEndCanvas;
    public GameObject normalCanvas;
    public TextMeshProUGUI FinalScore;

    private void Start()
    {
        _instance = this;
        gameEndCanvas.SetActive(false);
        normalCanvas.SetActive(true);
    }

    public static void EndGame(int finalScore)
    {
        _instance.gameEndCanvas.SetActive(true);
        _instance.normalCanvas.SetActive(false);
        _instance.FinalScore.text = "Final Score: " + finalScore.ToString();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(1);
    }
}
