using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUIManager : MonoBehaviour
{
    public GameController gc;
    public GameObject keyImage;

    void KeyUpdate() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }

        // TODO: Make generic for any gap size
        float startingOffset = -60 * gc.keysToPress.Count + 60;
        for (int i = 0; i < gc.keysToPress.Count; i++) {
            float newPosX = startingOffset + 120 * i;
            GameObject newImageObject = Instantiate(keyImage, Vector3.zero, Quaternion.identity, transform);
            newImageObject.GetComponent<RectTransform>().anchoredPosition = Vector3.right * newPosX;
            KeyButton newImageKeyButtonComp = newImageObject.GetComponent<KeyButton>();
            newImageKeyButtonComp.UpdateKeyValue(gc.keysToPress[i]);
            newImageKeyButtonComp.gc = gc;
        }
    }

    private void Start() {
        gc.keyUpdate += KeyUpdate;
    }
}
