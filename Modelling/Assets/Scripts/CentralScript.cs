using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using SimpleJSON;

public class CentralScript : MonoBehaviour
{
	public float speed, currAltitude, minAltitude, maxAltitude;
    public GameObject drone, propellers, menu, dashboard, cam1, cam2;
    public Transform p1,p2,p3,p4;
    float rotationVelocity;
    public bool instruction;
    // Vector3 dashboardPosition;
    // 200x300 px window will apear in the center of the screen.
     private Rect windowRect;
     // Only show it if needed.
     private bool show;
     bool mainCamActive;
     private float newPosX;
     private float newPosY;
     private float newPosZ;
     private float targetX, targetY, targetZ;
     private bool autoPilotMode;
     private Vector3 homePosition;
     private bool updatePosition;
    
    void Start()
    {
        speed = 40f;
        minAltitude = 2f;
        maxAltitude = 300f;
        rotationVelocity = 1000f;
        currAltitude = transform.position.y;
        drone = GameObject.Find("Drone");
        cam1 = drone.transform.Find("CameraOnDrone").gameObject;
        cam2 = drone.transform.Find("CameraFar").gameObject;
        propellers = drone.transform.Find("Propellers").gameObject; 
        p1 = propellers.transform.Find("p1");
        p2 = propellers.transform.Find("p2");  
        p3 = propellers.transform.Find("p3");  
        p4 = propellers.transform.Find("p4");
        instruction = true;    
        menu = GameObject.Find("MainMenu");
        menu.SetActive(false);
        // dashboardPosition = new Vector3(400,70,50);
        // dashboard = GameObject.Find("Dashboard");
        // dashboard.transform.position = Camera.main.ScreenToWorldPoint(dashboardPosition);
        windowRect = new Rect ((Screen.width - 370)/2, (Screen.height - 300)/2, 400, 100);
        show = false;
        mainCamActive = true;
        autoPilotMode = false;
        homePosition = new Vector3(533,-1,1842);
        // newPosX = 533;
        // newPosY = -1;
        // newPosZ = 1842;
        newPosX = 0;
        newPosY = 0;
        newPosZ = 0;
        updatePosition = false;

        targetX = GetLOCHelper.targetX;
        targetY = GetLOCHelper.targetY;
        targetZ = GetLOCHelper.targetZ;

        //new code
        // StartCoroutine(onCouroutine());

    }

    void Update()
    {
        GetLOCHelper.GetCoordinates(coordinates =>{});
    	RotatePropellers(instruction);
        TranslateDrone(instruction);
        currAltitude = transform.position.y;

        if (Input.GetKey(KeyCode.Escape))
        {
            toggleMenu();
            
        }

        if (Input.GetKey(KeyCode.C))
        {
            switchCamera();
        }

        if (updatePosition == true){
        	GetCurrentPosition();
        	updatePosition = false;
        }


        if (autoPilotMode == true){
            

            // GetLOCHelper.GetCoordinates(coordinates =>{});
            targetX = GetLOCHelper.targetX;
            targetY = GetLOCHelper.targetY;
            targetZ = GetLOCHelper.targetZ;
            Debug.Log("X: "+targetX+", "+"Y: "+targetY+", "+"Z: "+targetZ);

        	drone.transform.position = new Vector3(newPosX,newPosY,newPosZ);
        	//533, -1, 1842
            if (newPosY <= targetY){
	        	newPosY = newPosY + 1;
			}
			if (newPosY >= targetY && newPosZ>=targetZ){
				newPosZ = newPosZ - 1;
			}
			else if (newPosZ < targetZ){
	        	newPosZ = newPosZ + 1;
			}
			if (newPosZ <= targetZ && newPosX>=targetX){
				newPosX = newPosX - 1;
			}
			if (newPosX < targetX){
	        	newPosX = newPosX + 1;
			}
        }

        
        
        // var N = JSON.Parse(response);
        // var x = N["x"].Value;
        // Debug.Log("X is: " + x );

    }

   public void RotatePropellers(bool instruction){
        if (instruction){
            p1.Rotate(0,rotationVelocity * Time.deltaTime,0);
            p2.Rotate(0,rotationVelocity * Time.deltaTime,0);
            p3.Rotate(0,rotationVelocity * Time.deltaTime,0);
            p4.Rotate(0,rotationVelocity * Time.deltaTime,0);
        }
   }

   public void TranslateDrone(bool instruction){
        if (instruction){
            if (Input.GetKey(KeyCode.UpArrow)){
                transform.position += Vector3.forward * (Time.deltaTime * speed);
                
            }
     
            if (Input.GetKey(KeyCode.DownArrow)){
               
                transform.position += -Vector3.forward * (Time.deltaTime * speed);
                
            }

            if (Input.GetKey(KeyCode.Q))
            {
                if (transform.position.y < maxAltitude){
                    transform.position += Vector3.up * (Time.deltaTime*speed);
                }
            }

            if (Input.GetKey(KeyCode.E))
            {
                if (transform.position.y > minAltitude){
                    transform.position += Vector3.down * (Time.deltaTime*speed); 
                    // Debug.Log("Altitude: " + transform.position.y);
                }
                else if (transform.position.y <= minAltitude)
                {
                    Open();
                }
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += Vector3.right * (Time.deltaTime*speed);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += Vector3.left * (Time.deltaTime*speed);
            }
        }
   }

   public void toggleMenu(){
        
        if (menu.activeSelf){
            this.instruction = true;
            menu.SetActive(false) ; 
        }
        else if (!menu.activeSelf){
            this.instruction = false;
            menu.SetActive(true) ;
        }
   }

   public void continueSimulation(){
        this.instruction = true;
        menu.SetActive(false) ; 
        Debug.Log("Menu: Continue Simulation");
   }

   public void endSimulation(){
        Debug.Log("Menu: End Simulation");
        Application.Quit();
   }

   void OnGUI () 
    {
        if(show)
            windowRect = GUI.Window (0, windowRect, DialogWindow, "End Simulation");
    }

    void DialogWindow (int windowID)
    {
        float y = 20;
        GUI.Label(new Rect(20,y+5, windowRect.width, 20), "Drone has landed; Do you want to end simulation?");

        // if(GUI.Button(new Rect(5,y+18, windowRect.width - 10, 20), "No"))
        if(GUI.Button(new Rect(310,y+40, 30, 20), "No"))
        {
           Debug.Log("Don't end simulation"); 
            show = false;
        }

        if(GUI.Button(new Rect(350,y+40, 30, 20), "Yes"))
        {
           Debug.Log("End Simulation");
           show = false;
           Application.Quit();
        }
    }

    // To open the dialogue from outside of the script.
    public void Open()
    {
        show = true;
    }

    public void DisplaySorry(){
        Debug.Log("Functionality is not yet implemented.");
    }

    public void switchCamera(){
        if (cam1.activeSelf){
            cam1.SetActive(false);
            cam2.SetActive(true);
        }
        else if (cam2.activeSelf){
            cam2.SetActive(false);
            cam1.SetActive(true);
        }
    }

    public void ToggleAutoPilotMode(){
    	updatePosition = true;

    	if (autoPilotMode == true){
    		autoPilotMode = false;
    	}
    	else if (autoPilotMode == false){
    		autoPilotMode = true;
    	}
    }

    public void GetCurrentPosition(){
    	newPosX = drone.transform.position.x;
    	newPosY = drone.transform.position.y;
    	newPosZ = drone.transform.position.z;
    }

    ///new code
    // IEnumerator onCouroutine(){
    //     while(true){
    //         GetLOCHelper.GetCoordinates(coordinates =>{});
    //         targetX = GetLOCHelper.targetX;
    //         targetY = GetLOCHelper.targetY;
    //         targetZ = GetLOCHelper.targetZ;
    //         Debug.Log("X: "+targetX+", "+"Y: "+targetY+", "+"Z: "+targetZ);
    //         yield return new WaitForSeconds(2f);
    //     }
    // }
    

}
