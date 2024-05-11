using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    public bool isSeeingPlayer = false;
    public Transform[] points;
    public bool moveToPoints;
    public int delay;
    public Transform player;
    public GameObject explosionPrefab;
    public Transform shotPoint;
    public GameObject bullet;
    public float delayShoot;
    private AudioSource audioSource;
    public Vector3 destination;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }
    private void Update()
    {
        if(isSeeingPlayer)
        {
            destination = player.transform.position;   
        }
    }
    private void Start()
    {
        StartCoroutine(Check(delay));
        StartCoroutine(Shot(delayShoot));
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("volume");
        destination.x = Random.Range(1000, -1000);
        destination.z = Random.Range(1000, -1000);
        destination.y = 7;
    }
    public IEnumerator Check(int delayCheck)
    {
        yield return new WaitForSeconds(delayCheck);
        
        
            if (moveToPoints)
            {
                destination = points[Random.Range(0, points.Length)].transform.position;
                agent.destination = destination;    
                Debug.Log("Couratine");
            }
         
            if (!moveToPoints)
            {
                agent.destination = destination;
                if(agent.remainingDistance <= 0 && !isSeeingPlayer)
                {
                    destination.x = Random.Range(1000, -1000);
                    destination.z = Random.Range(1000, -1000);
                    destination.y = 7;
                }
            }

            
            StartCoroutine(Check(delay));
        
        
    }
    IEnumerator Shot(float delayShooting)
    {
        yield return new WaitForSeconds(delayShooting);
        if (isSeeingPlayer)
        {
            Instantiate(bullet, shotPoint.position, shotPoint.rotation);
            audioSource.Play();
        }
        StartCoroutine(Shot(delayShoot));
        
    }   
    
    

    
}
