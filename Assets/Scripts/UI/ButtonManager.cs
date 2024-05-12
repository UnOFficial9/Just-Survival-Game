using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;
using System.IO;

public class ButtonManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Settings()
    {
        SceneManager.LoadScene(2);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Back()
    {
        SceneManager.LoadScene(0);
    }
    public void BackToGame()
    {
        gameObject.transform.parent.transform.parent.GetChild(0).gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameObject.transform.parent.transform.parent.GetComponent<UIManager>().isPaused = false;
        gameObject.transform.parent.gameObject.SetActive(false);
    }
    public void Clear()
    {
        
    }
    public void Host()
    {
        NetworkManager.Singleton.StartHost();
    }
    public void Server()
    {
        NetworkManager.Singleton.StartServer();
    }
    public void Client()
    {
        NetworkManager.Singleton.StartClient();
    }
    public void LocalGame()
    {
        SceneManager.LoadScene(4);
    }
}
