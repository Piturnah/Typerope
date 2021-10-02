using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyButton : MonoBehaviour
{
    char key;
    public TextMeshProUGUI text;

    public Color defaultColour;
    public Color depressedColour;

    public void UpdateKeyValue(char newVal) {
        key = newVal;
        text.text = ("" + key).ToUpper();
    }

    private void Update() {
        GetComponent<Image>().color = (Input.GetKey(KeyMap.charToKeycode[key])) ? depressedColour : defaultColour;
    }
}
