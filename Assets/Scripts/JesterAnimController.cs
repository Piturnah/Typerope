using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JesterAnimController : MonoBehaviour
{
    Animator anim;
    GameController gc;

    bool previousStepL;

    private void Update() {
        if (Input.GetKeyDown(KeyMap.charToKeycode[gc.keysToPress[gc.keysToPress.Count - 1]])) {
            Debug.Log("AIDS");
            if (previousStepL) {
                anim.SetTrigger("StepR");
            } else {
                anim.SetTrigger("StepL");
            }
            previousStepL = !previousStepL;
        }
    }

    private void Start() {
        anim = GetComponent<Animator>();
        gc = FindObjectOfType<GameController>();
    }
}
