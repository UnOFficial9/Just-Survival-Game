using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int lifeTime;
    public int damage;
    public AudioClip[] clips = new AudioClip[3];
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    void Update()
    {
        transform.Translate(new Vector3 (0, 1, 0) * speed * Time.deltaTime);

    }
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().clip = clips[Random.Range(0, clips.Length)];
        GetComponent<AudioSource>().Play();
        Destroy(gameObject);
    }
}
