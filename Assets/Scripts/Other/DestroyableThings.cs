using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableThings : MonoBehaviour
{
    public GameObject explosion;
    public int health;
    public int maxHealth;
    public AudioClip destroy;
    public AudioClip damage;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        health = maxHealth;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet" || other.gameObject.tag == "EnemyBullet")
        {
            Instantiate(explosion, other.transform.position, Quaternion.identity);
            health = health - other.GetComponent<Bullet>().damage;
            audioSource.clip = damage; 
            audioSource.Play();
            
        }
    }
    private void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
