using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JesterAnimController : MonoBehaviour
{
    Animator anim;
    GameController gc;

    bool previousStepL;
    static public bool moving;

    private void Update() {
        if (Input.GetKeyDown(KeyMap.charToKeycode[gc.keysToPress[gc.keysToPress.Count - 1]])) {
            if (previousStepL) {
                anim.SetTrigger("StepR");
            } else {
                anim.SetTrigger("StepL");
            }
            previousStepL = !previousStepL;
        }

        anim.SetBool("Leaning", false);
        moving = true;
        foreach (char key in KeyMap.charToKeycode.Values) {
            if (gc.keysToPress.Contains(key)) {
                if (!Input.GetKey(KeyMap.charToKeycode[key])) {
                    anim.SetBool("Leaning", true);
                    moving = false;
                }
            }
        }
    }

    private void Start() {
        anim = GetComponent<Animator>();
        gc = FindObjectOfType<GameController>();
    }
}
