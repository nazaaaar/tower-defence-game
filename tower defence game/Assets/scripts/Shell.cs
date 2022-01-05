using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public Enemy enemy;
    public float damage;
    private Vector3 direction;
    private float speed = 20;
    private Rigidbody rb;
    void Start()
    {
        

        rb = gameObject.GetComponent<Rigidbody>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy") enemy.GetDamage(damage);
        Destroy(gameObject);
    }
    void FixedUpdate()
    {
        if (enemy)
        {
            Vector3 heading = enemy.transform.position - transform.position - new Vector3(0, 0.5f);
            float distance = heading.magnitude;
            direction = heading / distance;
        }
        rb.velocity = direction * speed;
    }
}
