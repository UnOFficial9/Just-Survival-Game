using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public int deadZoneL;
    public int deadZoneR;
    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Debug.Log("x:" + Input.GetTouch(Input.touchCount - 1).position.x + "y:" + Input.GetTouch(0).position.y);
            if(Input.GetTouch(Input.touchCount - 1).position.x < Screen.width / 2 && Input.GetTouch(0).position.x > deadZoneR)
            {
                transform.Rotate(new Vector3(0, 5, 0));
            }
            else if(Input.GetTouch(0).position.x > Screen.width / 2 && Input.GetTouch(0).position.x < deadZoneL)
            {
                transform.Rotate(new Vector3(0, -5, 0));
            }
        }
    }
}

