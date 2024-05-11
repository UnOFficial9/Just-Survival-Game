using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    private WindZone zone;
    void Start()
    {
        zone = GetComponent<WindZone>();
        StartCoroutine(WindControl(30));
    }

   
    IEnumerator WindControl(int delay)
    {
        yield return new WaitForSeconds(delay);
        zone.windMain = Random.Range(0f, 0.4f);
    }    
}
