using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100;
    private float maxHealth;
    private Transform healthBar;
    private float x, y, z;
    void Start()
    {
        healthBar = gameObject.GetComponentsInChildren<Transform>()[1];
        x = healthBar.lossyScale.x;
        y = healthBar.lossyScale.y;
        z = healthBar.lossyScale.z;
        //healthBar.parent = null;

        maxHealth = health;
    }

    public void GetDamage(float damage)
    {
        health -= damage;
        if (health <= 0) Die();

        healthBar.localScale = new Vector3(x / maxHealth * health, y, z);
    }

    public void Die()
    {
        QueueSystem.Remove();
        Destroy(gameObject);
    }
}
