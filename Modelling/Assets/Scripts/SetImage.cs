using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetImage : MonoBehaviour
{
    Image myImageComponent;
 	public Sprite myFirstImage;
    
    void Start()
    {
	    myImageComponent = GetComponent<Image>();
    }

    public void SetImage1() //method to set our first image
 	{
 		myImageComponent.sprite = myFirstImage;
 	}

    
}
