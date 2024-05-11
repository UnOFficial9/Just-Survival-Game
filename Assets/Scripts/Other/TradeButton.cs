using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradeButton : MonoBehaviour
{
    private Text priseText;
    private int price;
    private Image img;
    private Text name;
    public int items;
    public Sprite[] sprites;
    public int currentItem;
    private Player _player;
    private void Start()
    {
        GetComponents();
        Prices();
        
    }
    public void OnClick()
    {
        if(PlayerPrefs.GetInt("money") >= price)
        {
            switch (currentItem)
            {
                case 0:
                    PlayerPrefs.SetInt("ammo4", PlayerPrefs.GetInt("ammo4") + price / 2);
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - price);


                break;
                case 1:
                    PlayerPrefs.SetInt("ammo2", PlayerPrefs.GetInt("ammo2") + price / 5);
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - price);

                break;
                case 2:
                    PlayerPrefs.SetInt("ammo3", PlayerPrefs.GetInt("ammo3") + price / 10);
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - price);

                    break;
                case 3:
                    PlayerPrefs.SetInt("ammo6", PlayerPrefs.GetInt("ammo6") + price);
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - price);

                    break;
                case 4:
                    PlayerPrefs.SetInt("health", PlayerPrefs.GetInt("health") + price * 2);
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - price);

                    break;
                case 5:
                    PlayerPrefs.SetInt("ammo1", PlayerPrefs.GetInt("ammo1") + price);
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - price);
                    break;
            }
            
        }
        else
        {
            Debug.Log("Not enougth money!");
        }
    }
    void GetComponents()
    {
        priseText = transform.GetChild(1).GetComponent<Text>();
        name = transform.GetChild(2).GetComponent<Text>();
        img = transform.GetChild(0).GetComponent<Image>();
        
    }
    void Prices()
    {
        currentItem = Random.Range(0, items);
        img.sprite = sprites[currentItem];
        switch (currentItem)
        {
            case 0:
                name.text = "Submashine gun ammo";
                price = Random.Range(30, 40);
                priseText.text = price.ToString();


            break;
            case 1:
                name.text = "Rifle gun ammo";
                price = Random.Range(50, 75);
                priseText.text = price.ToString();
                break;
            case 2:
                name.text = "Sniper gun ammo";
                price = Random.Range(80, 100);
                priseText.text = price.ToString();
                break;
            case 3:
                name.text = "Speed pistol ammo";
                price = Random.Range(20, 40);
                priseText.text = price.ToString();
                break;
            case 4:
                name.text = "Heal";
                price = Random.Range(3, 15);
                priseText.text = price.ToString();
            break;
            case 5:
                name.text = "Pistol ammo";
                price = Random.Range(5, 18);
                priseText.text = price.ToString();
                break;

        }
        Debug.Log(_player.Money);
    }
}
