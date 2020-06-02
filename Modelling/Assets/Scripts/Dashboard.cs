using UnityEngine;
 using System.Collections;
 
 public class Dashboard : MonoBehaviour {
     
     Camera cam;  
 
     void Start () {
         if (cam == null)
             cam = Camera.main;
     }
     
     void Update () {
         if (Input.GetMouseButtonDown(0)) {
             float distance = transform.position.z - cam.transform.position.z;
             Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
             position = cam.ScreenToWorldPoint(position);
             Debug.Log(position);
             transform.position = position;

         }
         
     
     }
 }