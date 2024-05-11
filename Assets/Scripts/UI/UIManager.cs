using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseUI;
    private bool isCreated;
    public Player pl;
    private void Start()
    {
        
    }
    private void Update()
    {
        Pause();
    }
    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            if (!isCreated) 
            {
                GameObject pause = Instantiate(pauseUI, transform.position, transform.rotation);
                pause.transform.SetParent(transform);
            }
            else
            {
                transform.GetChild(1).gameObject.SetActive(true);
            }
                pl.enabled = false;
                transform.GetChild(0).gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                isPaused = true;

        }
        if(!isPaused)
        {
            pl.enabled = true;
        }

    }
}
