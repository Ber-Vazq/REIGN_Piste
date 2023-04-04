using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLimit = 60f;
    public TextMeshProUGUI timerText;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0f){
            timer = 0f;
            Debug.Log("duhduhdud DUHDUHDHDU DHUDHUDHU Your time is up my time is now. DUHH DUHDUHDUHDUHDU *John Cena noises*");
        }
        timerText.text = timer.ToString("F2");
    }
}
