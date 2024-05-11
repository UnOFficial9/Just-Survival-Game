using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 20; 
    public GameObject deadPrefab;
    public GameObject coins;
    public GameObject bullets;
    private Rigidbody rb;
    private int damage;
    private Enemy enemy;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemy = GetComponent<Enemy>();
    }
    void Update()
    {
        if(health <= 0)
        {
            Die();
        }
        
    }
    void Die()
    {
        int random = Random.Range(0, 2);
        switch(random)
        {
            case 0:
                Instantiate(coins, transform.position - new Vector3(0, 1, 0), transform.rotation);
                break;
            case 1:
                Instantiate(bullets, transform.position - new Vector3(0, 1, 0), transform.rotation);
                break;
            case 2:
                Instantiate(coins, transform.position - new Vector3(0, 1, 0), transform.rotation);
                Instantiate(bullets, transform.position - new Vector3(0, 1, 0), transform.rotation);
                break;
        }
        Instantiate(deadPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Bullet")
        {
            rb.AddForce(new Vector3(1,0,1), ForceMode.Impulse);
            health = health - other.GetComponent<Bullet>().damage;
            Instantiate(enemy.explosionPrefab, transform.position, transform.rotation);
            enemy.isSeeingPlayer = true;
            damage = 0;
        }
    }
}
