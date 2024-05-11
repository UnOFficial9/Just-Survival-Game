using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleZones : MonoBehaviour
{
    private Enemy enemy;

    private void Start()
    {
        enemy = transform.GetComponentInParent<Enemy>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            enemy.isSeeingPlayer = true;
            
            //enemy.player = other.GetComponent<Player>().gameObject.transform;
        }
    }
}
