using UnityEngine;
using UnityEngine.AI;
public class Villager : MonoBehaviour
{
    private NavMeshAgent agent;
    public int maxHealth;
    public int health;
    public Transform home;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        health = maxHealth;
    }
    void Update()
    {
        
    }

    void Health()
    {
        if(health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet" ||  other.gameObject.tag == "EnemyBullet")
        {
            health = health - other.GetComponent<Bullet>().damage;
            agent.destination = home.position;
            agent.speed = agent.speed * 1.5f;
            if(agent.remainingDistance <= 1)
            {
                agent.isStopped = true;
            }
        }
    }
}
