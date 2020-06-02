using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AltitudeBar : MonoBehaviour
{
    private Slider slider;
    public float altitude;
    private float targetProgress = 0;

    public float FillSpeed = 0.05f;
    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    	altitude = GameObject.Find("Drone").GetComponent<CentralScript>().currAltitude;

    }

    // Update is called once per frame
    void Update()
    {
        // if (slider.value < targetProgress)
        //     slider.value += FillSpeed * Time.deltaTime;
        altitude = GameObject.Find("Drone").GetComponent<CentralScript>().currAltitude;
        // Debug.Log("Altitude hai: "+altitude);
        
        if (altitude <= 30){//less than 16%
        	IncrementProgress(0.10f);
        }
        if (altitude > 30 && altitude <= 60){//between 10-20%
        	IncrementProgress(0.20f);
        }
        if (altitude > 60 && altitude <= 90){//between 20-30%
        	IncrementProgress(0.30f);
        }
        if (altitude > 90 && altitude <= 120){//between 30-40%
        	IncrementProgress(0.40f);
        }
        if (altitude > 120 && altitude <= 150){//between 40-50%
        	IncrementProgress(0.50f);
        }
        if (altitude > 150 && altitude <= 180){//between 50-60%
        	IncrementProgress(0.60f);
        }
        if (altitude > 180 && altitude <= 210){//between 60-70%
        	IncrementProgress(0.70f);
        }
        if (altitude > 210 && altitude <= 240){//between 70-80%
        	IncrementProgress(0.80f);
        }
        if (altitude > 240 && altitude <= 270){//between 80-90%
        	IncrementProgress(0.90f);
        }
        if (altitude > 270 && altitude <= 300){//between 90-100%
        	IncrementProgress(1.00f);
        }
        
    }
    public void IncrementProgress(float newProgress)
    {
        targetProgress = slider.value + newProgress;
        // slider.value += FillSpeed * Time.deltaTime;
        slider.value = Mathf.Lerp(slider.value, newProgress, Time.deltaTime * FillSpeed);

    }

}
