using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    static GameEnd _instance;
    public Canvas gameEndCanvas;

    private void Start()
    {
        _instance = this;
        gameEndCanvas.enabled = false;
    }

    public static void EndGame()
    {
        _instance.gameEndCanvas.enabled = true;
    }
}
