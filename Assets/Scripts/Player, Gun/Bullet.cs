using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int lifeTime;
    public int damage;
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    void Update()
    {
        transform.Translate(new Vector3 (0, 1, 0) * speed * Time.deltaTime);

    }
}
