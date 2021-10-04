using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExcessKeyButton : MonoBehaviour
{
    char key;

    Animator anim;
    public TextMeshProUGUI text;

    private void Awake() {
        anim = GetComponent<Animator>();
        anim.SetBool("Wobbling", true);
    }

    public void UpdateKeyValue(char newVal) {
        key = newVal;
        text.text = ("" + key).ToUpper();
    }
}
