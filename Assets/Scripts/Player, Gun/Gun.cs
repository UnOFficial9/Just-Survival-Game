using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class Gun : MonoBehaviour
{
    public Transform shotPoint;
    public GameObject bullet;
    public GameObject shotPrefab;
    public int ammo = 30;
    private AudioSource audioSource;
    public int damage;
    public bool isAutomat;
    public bool isSpeedPistol;
    public int FOV;
    public int gunId;


    private void Start()
    {

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("volume");
        if(isAutomat)
        {
            StartCoroutine(Automat(0.25f));
        }
        if (PlayerPrefs.GetInt("ammo" + gunId.ToString()) != 0)
            ammo = PlayerPrefs.GetInt("ammo" + gunId.ToString());
        else ammo = 30;
        Debug.Log("ammo" + gunId.ToString());
    }
    void Update()
    {
        Shot();
        Save();
        
    }
    public void Shot()
    {
        if (Input.GetButtonDown("Fire1") && ammo > 0)
        {
            GameObject explosionInst = Instantiate(bullet, shotPoint.position, shotPoint.rotation) as GameObject;
            explosionInst.GetComponent<Bullet>().damage = damage;
            Instantiate(shotPrefab, shotPoint.position, shotPoint.rotation);
            audioSource.Play();
            ammo--;
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Fire2");
            transform.GetComponentInParent<Camera>().fieldOfView = FOV;


        }
        if (Input.GetButtonUp("Fire2"))
        {
            transform.GetComponentInParent<Camera>().fieldOfView = 60;
        }
        if(isAutomat || isSpeedPistol)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                audioSource.Stop();
            }
        }
        if(isSpeedPistol)
        {
            if(Input.GetButton("Fire1") && ammo > 0)
            {
                GameObject explosionInst = Instantiate(bullet, shotPoint.position, shotPoint.rotation) as GameObject;
                explosionInst.GetComponent<Bullet>().damage = damage;
                Instantiate(shotPrefab, shotPoint.position, shotPoint.rotation);
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                ammo--;
            }
            
        }
    }
    IEnumerator Automat(float delay)
    {
        yield return new WaitForSeconds(delay);
        if(Input.GetButton("Fire1") && ammo > 0)
        {
            GameObject explosionInst = Instantiate(bullet, shotPoint.position, shotPoint.rotation) as GameObject;
            explosionInst.GetComponent<Bullet>().damage = damage;
            Instantiate(shotPrefab, shotPoint.position, shotPoint.rotation);
            ammo--;
            if(audioSource.isPlaying == false)
            {
               audioSource.Play();
            }

        }
        
        StartCoroutine(Automat(delay));
    }
    void Save()
    {
        PlayerPrefs.SetInt("ammo" + gunId.ToString(), ammo);
    }
}
