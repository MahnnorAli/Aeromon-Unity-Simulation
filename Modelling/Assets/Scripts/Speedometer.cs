using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{

    private const float MAX_SPEED_ANGLE = -20;
    private const float ZERO_SPEED_ANGLE = 210;
    private Transform needleTransform;
    private Transform SpeedLabelTransform;

    private float speedMax;
    private float speed;


    private void Awake()
    {
        needleTransform = transform.Find("Needle");
        speed = 0f;
        speedMax = 200f;
        SpeedLabelTransform = transform.Find("SpeedLabel");
        SpeedLabelTransform.gameObject.SetActive(false);
        GetSpeedRotation();
        CreateSpeedLabels();
    }
    private void Update()
    {
        speed += 30f * Time.deltaTime;

        if (speed > speedMax) speed = speedMax;
        needleTransform.eulerAngles = new Vector3(0, 0, GetSpeedRotation());


    }
    private float GetSpeedRotation()
    {
        float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;
        float speedNormalized = speed / speedMax;
        return ZERO_SPEED_ANGLE - speedNormalized * totalAngleSize;

    }

    private void CreateSpeedLabels()
    {
        int labelAmount = 10;
        float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;
        for (int i = 0; i <= labelAmount; i++)
        {
            Transform speedLabelTransform = Instantiate(SpeedLabelTransform, transform);
            float labelSpeedNormalized = (float)i / labelAmount;
            float speedLabelAngle = ZERO_SPEED_ANGLE - labelSpeedNormalized * totalAngleSize;
            speedLabelTransform.eulerAngles = new Vector3(0, 0, speedLabelAngle);
            speedLabelTransform.Find("LabelText").GetComponent<Text>().text = Mathf.RoundToInt(labelSpeedNormalized * speedMax).ToString();

            speedLabelTransform.gameObject.SetActive(true);
        }
    }
}
