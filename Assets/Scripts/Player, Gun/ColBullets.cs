using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColBullets : MonoBehaviour
{
    private int bullets;
    private void Start()
    {
        bullets = Random.Range(5, 20);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Gun")
        {
            other.GetComponent<Gun>().ammo = other.GetComponent<Gun>().ammo + bullets;
            Destroy(gameObject);
        }
    }
}
