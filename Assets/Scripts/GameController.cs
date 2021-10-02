using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    float timeBtwNewKeys = 5f;
    public List<char> keysToPress = new List<char>();

    public event Action keyUpdate;

    private void Update() {
        CheckKeysDown();
    }

    void CheckKeysDown() {
        foreach(char key in keysToPress) {
            if (!Input.GetKey(KeyMap.charToKeycode[key])) {
                Debug.Log("Not pressing key " + key.ToString().ToUpper() + "!");
            }
        }
    }

    IEnumerator PressNewKey() {
        while(true) {
            if (keysToPress.Count >= 5) { keysToPress.RemoveAt(0); }
            keysToPress.Add(KeyMap.charToKeycode.ElementAt(UnityEngine.Random.Range(0, KeyMap.charToKeycode.Count)).Key);
            keyUpdate?.Invoke();
            yield return new WaitForSeconds(timeBtwNewKeys);
        }
    }

    private void Start() {
        StartCoroutine(PressNewKey());
    }
}
