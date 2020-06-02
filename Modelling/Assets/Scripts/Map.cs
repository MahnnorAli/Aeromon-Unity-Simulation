using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Map : MonoBehaviour
{
    public string url = "";
    public float latVal;
    public float longVal;
    public LocationInfo li;
    
    // public IEnumerator Start()
    // {
  //   	li = new LocationInfo();
		// latVal = li.latitude; 
		// longVal = li.longitude;
		// url="http://maps.google.com/maps/api/staticmap?center="+latVal+","+longVal+"&zoom=14&size=800x600↦type=hybrid&sensor=true";
		
  //       using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(url))
  //       {
  //           yield return request.Send();
  //           Debug.Log("Server responded: " + request.downloadHandler.text);
  //           // GetComponent<Renderer>().material.mainTexture = request.texture;
  //           Debug.Log(DownloadHandlerTexture.GetContent(url));
  //       }
    // }
}
