using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    float timeBtwNewKeys = 5f;
    public float maxTimeB4KO = 10f;
    public float timeB4KO;

    const float missingKeyPenalty = -1f;
    const float excessKeyPenalty = -1f;
    const float regenRate = 2f;
    const float timeUntilRegen = .5f;
    float lastDmgTime;

    char lastKeyPushedDown;

    public List<char> keysToPress = new List<char>();

    public event Action keyUpdate;

    public float score;
    public TextMeshProUGUI scoreUIObject;

    private void Update() {
        timeB4KO += CalculateHealth() * Time.deltaTime;
        timeB4KO = Mathf.Clamp(timeB4KO, 0, maxTimeB4KO);
    }

    float CalculateHealth() {
        float healthBarChange = 0;
        
        // Take damage for each missed key and each excess key
        foreach (char key in KeyMap.charToKeycode.Keys) {
            healthBarChange += (keysToPress.Contains(key)) ? (!Input.GetKey(KeyMap.charToKeycode[key]) ? missingKeyPenalty : 0) : ((Input.GetKey(KeyMap.charToKeycode[key])) ? excessKeyPenalty : 0);
        }

        // Determine if recharging health
        if (healthBarChange != 0) { lastDmgTime = Time.time; }
        if (lastDmgTime + timeUntilRegen <= Time.time) {
            healthBarChange += regenRate;
        }

        return healthBarChange;
    }

    // Adds a new key to the keysToPress list, avoiding duplicate letters
    IEnumerator PressNewKey() {
        while(true) {
            char newKey = 'a';  // Arbitrary inital value
            bool keyNotUnique = true;

            while (keyNotUnique) {
                newKey = KeyMap.charToKeycode.ElementAt(UnityEngine.Random.Range(0, KeyMap.charToKeycode.Count)).Key;
                keyNotUnique = keysToPress.Contains(newKey);
            }
            if (keysToPress.Count >= 5) { keysToPress.RemoveAt(0); }

            // Add newKey to list and send action invocation to relevant classes
            keysToPress.Add(newKey);
            keyUpdate?.Invoke();

            yield return new WaitForSeconds(timeBtwNewKeys);
        }
    }

    private void Start() {
        timeB4KO = maxTimeB4KO;
        StartCoroutine(PressNewKey());
        ResetScore();
        keyUpdate += UpdateScore;
    }

    public void ResetScore()
    {
        score = 0;
        scoreUIObject.text = $"Score: {score}";
    }

    public void UpdateScore()
    {
        score += 1;
        scoreUIObject.text = $"Score: {score}";
    }
}
