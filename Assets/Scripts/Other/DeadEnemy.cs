using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnemy : MonoBehaviour
{
   
    void Start()
    {
        Destroy(gameObject, 200);
    }
}
