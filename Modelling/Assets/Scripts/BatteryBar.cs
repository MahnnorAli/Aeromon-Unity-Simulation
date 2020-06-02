using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class BatteryBar : MonoBehaviour
{
 	Slider slider;
	float targetProgress = 0;
	float FillSpeed = 0.05f;
    float timer, minutes, seconds;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        slider.value += FillSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.realtimeSinceStartup - 6;
		minutes = Mathf.Floor(timer / 60);
		seconds = Mathf.RoundToInt(timer % 60);

        if (timer <= 30){//less than 16%
        	IncrementProgress(0.50f);
        }
        if (timer > 30 && timer <= 60){//between 10-20%
        	IncrementProgress(0.25f);
        }
        if (timer > 60 && timer <= 90){//between 20-30%
        	IncrementProgress(0.00f);
        }
        if (timer > 90 && timer <= 120){//between 30-40%
        	IncrementProgress(0.70f);
        }
        if (timer > 120 && timer <= 150){//between 40-50%
        	IncrementProgress(0.60f);
        }
        if (timer > 150 && timer <= 180){//between 50-60%
        	IncrementProgress(0.50f);
        }
        if (timer > 180 && timer <= 210){//between 60-70%
        	IncrementProgress(0.40f);
        }
        if (timer > 210 && timer <= 240){//between 70-80%
        	IncrementProgress(0.30f);
        }
        if (timer > 240 && timer <= 270){//between 80-90%
        	IncrementProgress(0.20f);
        }
        if (timer > 270 && timer <= 300){//between 90-100%
        	IncrementProgress(0.10f);
        }
        
    }
    public void IncrementProgress(float newProgress)
    {
        targetProgress = slider.value - newProgress;
        // slider.value += FillSpeed * Time.deltaTime;
        slider.value = Mathf.Lerp(slider.value, targetProgress, Time.deltaTime * FillSpeed);

    }

}
