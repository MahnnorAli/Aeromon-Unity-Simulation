using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeRotate : MonoBehaviour
{
    float rotation = 800.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,rotation * Time.deltaTime,0);
        //transform.Rotate(Vector3.up, fanSpeed * Time.deltaTime);
    }
}

