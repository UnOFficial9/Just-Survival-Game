using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DestroySalesCanvas : MonoBehaviour
{
    public Player player;
    public Vector3 _pos;
    public void GetPlayer(Player pl, Vector3 pos)
    {
        player = pl;

        _pos = pos; 
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(gameObject);
        }
    }
}
