using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SalesMan : MonoBehaviour
{
    private Player player;
    public Canvas canvas;
    public bool isTrading;
    public GameObject tradeCanvas;
    
    private void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        
        player = other.GetComponent<Player>();
        
        if (player != null)
            Debug.Log("Player found!");
        if(other.gameObject.tag == "Player" && Input.GetKey(KeyCode.T) && !isTrading)
        {
            canvas.gameObject.SetActive(false);
            isTrading = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            player.enabled = false;
            Create();
            
        }
        if (isTrading)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                player.enabled = true;
                canvas.gameObject.SetActive(true);
                isTrading = false;
               
                
            }
        }
    }
    void Create()
    {
        GameObject inst = Instantiate(tradeCanvas);
        inst.GetComponent<DestroySalesCanvas>().GetPlayer(player, transform.position);
    }

}
