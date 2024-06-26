using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    public GameObject explosionRrefab;

    new private Rigidbody2D rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetSpeed(Vector2 direction)
    {
        rigidbody.velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        GameObject exp = ObjectPool.Instance.GetObject(explosionRrefab);
        exp.transform.position = transform.position;

        ObjectPool.Instance.PushObject(gameObject);

        //伤害系统
        IDamageable damageable = other.transform.GetComponent<IDamageable>();
        damageable?.TakeDamage(10);

    }
}
