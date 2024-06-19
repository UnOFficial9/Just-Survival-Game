using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private Color colorOld;
    public Color colorNew;
    private bool setting;
    private void Start()
    {
        if(transform.parent.gameObject.name == "Settings")
        {
            colorOld = GetComponent<Image>().color;
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void BackToGame()
    {
        gameObject.transform.parent.transform.parent.GetChild(0).gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameObject.transform.parent.transform.parent.GetComponent<UIManager>().isPaused = false;
        gameObject.transform.parent.gameObject.SetActive(false);
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
    public void SettingsSelect()
    {
        colorOld = GetComponent<Image>().color; 
        GetComponent<Image>().color = colorNew;
    }
    public void DeselectSettings()
    {
        GetComponent<Image>().color = colorOld;
    }
    public void Settings(GameObject menu)
    {
        setting = !setting;
        if(setting)
        {
            menu.SetActive(true);
        }
        else
        {
            menu.SetActive(false);
        }
    }
}
