using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAttack : MonoBehaviour
{
    private QueueSystem queue;
    private Transform cannonBase;
    private Transform shellSpawn;
    public bool canAttack = false;
    public Shell shell;
    private Vector3 target;
   
    void Start()
    {
        Transform[] a = gameObject.GetComponentsInChildren<Transform>();
        cannonBase = a[1];
        shellSpawn = a[2];

        queue = gameObject.GetComponentInParent<QueueSystem>();
        transform.parent = null;
    }

    public float recharge = 5;

    private void Update()
    {
        target = queue.GetTarget();
        Targeting();

        if (canAttack & isTimerReady())
        {
            Atack();
            resetTimer(recharge);
        }
    }

    private float rotationSpeed = 4;
    private void Targeting()
    {
        if (target != Vector3.zero)
        {
            Vector3 targetDirection = transform.position - target;
            Quaternion newDirection = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, new Vector3(targetDirection.x, 0, targetDirection.z), rotationSpeed * Time.deltaTime, 0.0f));


            float changeY = transform.rotation.eulerAngles.y - newDirection.eulerAngles.y;
            if (changeY < 1 && changeY > -1) canAttack = true;
            else canAttack = false;

            transform.rotation = newDirection;
        }
        else canAttack = false;
    }

    public float damage = 50;
    
    private void Atack()
    {
        Shell a = Instantiate(shell, shellSpawn.position, Quaternion.identity);
        a.enemy = queue.GetEnemy();
        a.damage = damage;
    }

    
    private float timer = 0;
    private bool isTimerReady()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            return false;
        }
        else return true;   
    }

    private void resetTimer(float recharge)
    {
        timer = recharge;
    }
}
