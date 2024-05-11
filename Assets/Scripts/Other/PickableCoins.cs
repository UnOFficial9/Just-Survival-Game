using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableCoins : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().AddCoins(3);
            
            Destroy(gameObject);
        }
    }
}
