using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyGun : MonoBehaviour
{
    public int ammoGun;
    private int ammo;
    public Text[] text;
    private int child;

    private void Start()
    {
        
    }
    public void DestroyG(bool Active, int Child)
    {
        if (Active)
        {
            transform.GetChild(Child).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(Child).gameObject.SetActive(false);
        }
        
    }
    private void Update()
    {
    }
    public void GetChild(int child, Text text)
    {
        int childAmmo = transform.GetChild(child).GetComponent<Gun>().ammo;
        text.text = childAmmo.ToString();

    }
    public void GetChildIndex(string name)
    {
        
        for (int i = 0; i < transform.childCount;) 
        {
            if(transform.GetChild(i).name == name)
            {
                child = i;
                ReturnChild();
                break;
            }
            else
            {
                i++;
            }
        }
    }
    public int ReturnChild()
    {
        return child;
        child = 0;
    }
    
}
