using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAttack : MonoBehaviour
{
    private QueueSystem queue;
    private Transform cannonBase;
    void Start()
    {
        cannonBase = gameObject.GetComponentInChildren<Transform>();
        queue = gameObject.GetComponentInParent<QueueSystem>();
        transform.parent = null;
    }

    void Update()
    {
        Targeting();
    }
    private float rotationSpeed = 3;
    private void Targeting()
    {
        if (queue.GetTarget() != Vector3.zero)
        {
            Vector3 targetDirection = transform.position-queue.GetTarget();
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, new Vector3( targetDirection.x, 0, targetDirection.z), rotationSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}
