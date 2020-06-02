using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedPosition : MonoBehaviour
{
    Camera cam;
    public RectTransform target;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        target = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = cam.WorldToScreenPoint(target.position);
        Debug.Log("target is " + screenPos.x + " pixels from the left");
    }
}
