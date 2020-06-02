using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;
using SimpleJSON;
using TMPro;

[Serializable]//to parse JSON
public class Temperature : MonoBehaviour {

    TextMeshProUGUI temperatureVal;
    string islamabadTemp;
    string comsatsTemp;
     
    
    void Start(){
        temperatureVal = gameObject.GetComponent<TextMeshProUGUI>();
        islamabadTemp = "http://api.openweathermap.org/data/2.5/weather?q=Islamabad&units=metric&APPID=de0243118f79c30c13d9de88e5de14a2";
        comsatsTemp = "http://api.openweathermap.org/data/2.5/weather?lat=33.6518&lon=73.1566&units=metric&APPID=de0243118f79c30c13d9de88e5de14a2";
        GetTemperature();
    }

       
    public void GetTemperature() {
        StartCoroutine(GetText());
    }
 
    IEnumerator GetText() {
        UnityWebRequest www = UnityWebRequest.Get(comsatsTemp);
        yield return www.SendWebRequest();
 
        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            string response = www.downloadHandler.text;
            // Debug.Log(response);
            var N = JSON.Parse(response);
            string temperature = N["main"]["temp"].Value;
            Debug.Log("And temperature is: " + temperature + " degree Celsius");
            // temperatureVal.text = temperature;
            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }

    public void DisplaySorry(){
        Debug.Log("Functionality not yet implemented.");
    }
}