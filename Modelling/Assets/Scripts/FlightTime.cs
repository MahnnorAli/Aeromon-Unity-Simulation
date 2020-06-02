using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class FlightTime : MonoBehaviour
{
    TextMeshProUGUI time;
    float speed = 2.0f;
    String mins = "";
	String secs = "";
	List<float> altitudeValues;
	float lastAltitude, currAltitude;
	GameObject  drone;
	CentralScript script;
	float timer, minutes, seconds;
	private float nextActionTime;
	public float period;

    void Start()
    {
        time = gameObject.GetComponent<TextMeshProUGUI>();
       	drone = GameObject.Find("Drone");
       	script = drone.GetComponent<CentralScript>();
       	lastAltitude = 0f;
       	currAltitude = script.currAltitude;
    	altitudeValues = new List<float>();

    }
    	

    void Update()
    {
        // time.text = System.DateTime.Now.ToString("H:mm");
    	// String timeString = Time.realtimeSinceStartup.ToString();float minutes = Mathf.Floor(timer / 60);
		timer = Time.realtimeSinceStartup - 6;
		minutes = Mathf.Floor(timer / 60);
		seconds = Mathf.RoundToInt(timer % 60);
		lastAltitude = currAltitude;
		currAltitude = script.currAltitude;


		// Debug.Log("Timer: "+timer);
		
		 
		if(minutes < 10) {
	    	mins = "0" + minutes.ToString();
	 	}
	 	else{
	 		mins = minutes.ToString();
	 	}	
	 	
	 	if(seconds < 10) {
	    	secs = "0" + Mathf.RoundToInt(seconds).ToString();		 
	    }
	    else{
	 		secs = seconds.ToString();
	 	}

		time.text = mins + ":" + secs;

		if (seconds > 30){//50% battery is consumed
			if (isOdd(seconds)){
				time.color = new Color32(255, 215, 0, 255);
			}
			else{
				time.color = new Color32(59, 88, 159, 255);
			}
		}

		if (seconds > 50 || minutes > 0){//70% battery is consumed
			if (isOdd(seconds)){
				time.color = new Color32(255, 0, 0, 255);
			}
			else{
				time.color = new Color32(59, 88, 159, 255);
			}
		}

		if (!isOdd(seconds)){
			if (lastAltitude != currAltitude){
				altitudeValues.Add(currAltitude);
				// Debug.Log("Curr altitude: " + currAltitude);
				
			}
		}

		if (seconds == 9){
			print ("9 seconds over");
			foreach (float item in altitudeValues) { 
				print ("Altitude was: " + item); 
			}
		}

		// InvokeRepeating("AddAltitude", 5.0f, 5.0f);
		
    }

    public bool isOdd(float val){
    	return val % 2 == 0;
    }

	 
}
