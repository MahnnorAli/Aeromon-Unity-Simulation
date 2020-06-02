using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeRotate : MonoBehaviour
{
    float fanSpeed = 300.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0 , fanSpeed * Time.deltaTime , 0);
    }
}

