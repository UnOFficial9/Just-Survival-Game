using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableGun : MonoBehaviour
{
    public Slot slot;
    public GameObject gun;
    private Player player;

    private void Start()
    {
        if(slot.currentGameObject != null)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            player = col.gameObject.GetComponent<Player>();
            player.PickUpSound();
            slot.iconNumber = 0;
            slot.currentGameObject = gun;
            Destroy(gameObject);
        }

    }
}
