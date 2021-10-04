using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcessKeyHolder : MonoBehaviour
{
    public GameController gc;
    public GameObject keyImage;

    List<char> excessKeys = new List<char>();

    private void Start() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
    }

    private void Update() {
        foreach(char key in excessKeys.ToList()) {
            if (!Input.GetKeyDown(KeyMap.charToKeycode[key])) {
                excessKeys.Remove(key);
                UpdateKeys();
            }
        }
        foreach (char key in KeyMap.charToKeycode.Keys) {
            if (Input.GetKey(KeyMap.charToKeycode[key]) && !excessKeys.Contains(key) && !gc.keysToPress.Contains(key)) {
                excessKeys.Add(key);
                UpdateKeys();
            }
        }
    }

    void UpdateKeys() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < excessKeys.Count; i++) {
            GameObject newImageObject = Instantiate(keyImage, Vector3.zero, Quaternion.identity, transform);
            newImageObject.GetComponent<RectTransform>().anchoredPosition = Vector3.right * (14 - 400 + 35 + 84 * i);

            ExcessKeyButton newImageKeyButtonComp = newImageObject.GetComponent<ExcessKeyButton>();
            newImageKeyButtonComp.UpdateKeyValue(excessKeys[i]);
        }
    }
}
