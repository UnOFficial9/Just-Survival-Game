using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomSpawn : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 spawnPos;
    public GameObject spawnPrefab;
    public float delay = 0.025f;
    private void Start()
    {
        startPos = transform.GetChild(0).transform.position;
        endPos = transform.GetChild(1).transform.position;
        if(PlayerPrefs.GetString("enemies") == "True")
        StartCoroutine(Spawn(delay));
    }
    IEnumerator Spawn(float delay)
    {
        yield return new WaitForSeconds(delay);
        
            NavMeshHit hit;
            if (NavMesh.SamplePosition(spawnPos, out hit, 100f, NavMesh.AllAreas))
            {
                Instantiate(spawnPrefab, hit.position, Quaternion.identity);
            }
        StartCoroutine(Spawn(delay));
    }
    private void Update()
    {
        spawnPos.x = Random.Range(startPos.x, endPos.x);
        spawnPos.y = 20;
        spawnPos.z = Random.Range(startPos.z, endPos.z);
    }
}
