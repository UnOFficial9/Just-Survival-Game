using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Debug.Log("x:" + Input.GetTouch(0).position.x + "y:" + Input.GetTouch(0).position.y);
            if(Input.GetTouch(0).position.x < 500)
            {
                transform.Rotate(new Vector3(0, 5, 0));
            }
            else if(Input.GetTouch(0).position.x > 500)
            {
                transform.Rotate(new Vector3(0, -5, 0));
            }
        }
    }
}

