using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthPlayer : MonoBehaviour
{
    public int health;
    public int maxHealth;

    private void Start()
    {
        
        health = PlayerPrefs.GetInt("health");
        if (health <= 0)
            health = 100;

    }
    private void Update()
    {
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        if(health < 0)
        {
            Die();
        }
        PlayerPrefs.SetInt("health", health);
    }
    void Die()
    {
        PlayerPrefs.DeleteAll();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(3);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EnemyBullet")
        {
            health = health - other.GetComponent<Bullet>().damage;
        }
    }
}
