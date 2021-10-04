using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerThing : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene(1);
    }
}
