using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private Image image;
    public GameObject[] allGameObjects;
    public GameObject currentGameObject = null;
    public Sprite[] sprites;
    public bool isSpecialSlot;
    public int slot;
    private Inventory inv;
    public int iconNumber;
    public Transform create;
    private Text text;
    public bool isCreated;
    public DestroyGun destroy;
    private int Child;
    private Player pl;

    private void Awake()
    {
        text = transform.GetChild(1).GetComponent<Text>();
        text.text = "";
        inv = transform.GetComponentInParent<Inventory>();
        image = transform.GetChild(0).GetComponent<Image>();

        
        if(PlayerPrefs.GetInt("slot" + slot.ToString()) + 5 == 0)
        {
            currentGameObject = allGameObjects[0];
        }
        else
        {
            currentGameObject = null;
        }

        Debug.Log(PlayerPrefs.GetInt("slot" + slot.ToString()) + 5);
        if (currentGameObject != null)
            iconNumber = 0;
    }
    void Update()
    {
        if(!isSpecialSlot)
        destroy.GetChild(Child, text);

        Icons();

        Save();

        if (slot != inv.activeSlot)
        {
            destroy.DestroyG(false, Child);
        }
        if(slot == inv.activeSlot)
        {
            destroy.DestroyG(true, Child);
        }

        SpecialSlot();
        
        if(currentGameObject != null)
        {
            Debug.Log(slot + "Succeful");
        }

        
    }
    
    void Icons()
    {
        image.sprite = sprites[iconNumber];
          
    }
    public void Objects()
    {
        
        if (!isCreated && !isSpecialSlot)
        {
            GameObject gunInst = Instantiate(currentGameObject, create.position, create.rotation) as GameObject;
            gunInst.transform.parent = destroy.transform;
            isCreated = true;
            destroy.GetChildIndex(gunInst.name);
            Child = destroy.ReturnChild();
            
        }
        

    }
    void SpecialSlot()
    {
        if(isSpecialSlot)
        {
            pl = create.transform.parent.transform.parent.GetComponent<Player>();
            iconNumber = 0;
            text.text = pl.Money.ToString();
            Debug.Log(pl.Money.ToString());
            if (pl == null)
                Debug.Log("Error");
        }
    }
    void Save()
    {
        if(currentGameObject != null)
        {
            PlayerPrefs.SetInt("slot" + slot.ToString(), 0 - 5);
        }
        else
            PlayerPrefs.SetInt("slot" + slot.ToString(), 9);
    }


}
