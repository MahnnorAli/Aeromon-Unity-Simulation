using System.Collections;
 using UnityEngine;
 using UnityEngine.SceneManagement;
 
 public class SceneChange : MonoBehaviour
 {
     public string NewScene= "DigitalTwin";

     void Start()
     {
         Invoke("ChangeScene",3f);
         
     }

     void ChangeScene(){
     	SceneManager.LoadScene(NewScene);
        Debug.Log("Change Scene!");
     }
 }