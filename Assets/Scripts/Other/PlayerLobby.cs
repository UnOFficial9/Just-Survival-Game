using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLobby : MonoBehaviour
{
    void Update()
    {
        Move();
        Cursor.lockState = CursorLockMode.None;
    }
    void Move()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))* 5 * Time.deltaTime);
    }
}
