using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    float timeBtwNewKeys = 5f;
    List<char> keysToPress = new List<char>();

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
            keysToPress.Add(KeyMap.charToKeycode.ElementAt(Random.Range(0, KeyMap.charToKeycode.Count)).Key);
            yield return new WaitForSeconds(timeBtwNewKeys);
        }
    }

    private void Start() {
        StartCoroutine(PressNewKey());
    }
}
