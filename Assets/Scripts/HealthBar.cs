using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Image image;
    GameController gc;

    private void Start() {
        image = GetComponent<Image>();
        gc = FindObjectOfType<GameController>();
    }

    private void Update() {
        float healthRatio = gc.timeB4KO / gc.maxTimeB4KO;

        image.fillAmount = healthRatio;

        image.enabled = !(healthRatio >= .99f);

        if (healthRatio <= .5f) {
            image.color = Color.Lerp(Color.red, Color.white, healthRatio * 2);
        }
    }
}
