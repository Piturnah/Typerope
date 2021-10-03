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

    IEnumerator PressNewKey() {
        while(true) {
            char newKey = 'a';
            bool keyNotUnique = true;
            while (keyNotUnique) {
                newKey = KeyMap.charToKeycode.ElementAt(UnityEngine.Random.Range(0, KeyMap.charToKeycode.Count)).Key;
                keyNotUnique = keysToPress.Contains(newKey);
            }
            if (keysToPress.Count >= 5) { keysToPress.RemoveAt(0); }
            keysToPress.Add(newKey);
            keyUpdate?.Invoke();

            yield return new WaitForSeconds(timeBtwNewKeys);
        }
    }

    private void Start() {
        StartCoroutine(PressNewKey());
    }
}
