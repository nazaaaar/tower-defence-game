using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueSystem : MonoBehaviour
{
    private List<Transform> queue = new List<Transform>();

    void OnTriggerEnter(Collider enemy)
    {
        queue.Add(enemy.transform);
    }
    void OnTriggerExit(Collider enemy)
    {
        queue.Remove(enemy.transform);
    }

    private void Update()
    { 
    }
    public Vector3 GetTarget()
    {
        if (queue.Count != 0) return queue[0].position;
        return Vector3.zero;
        
    }
}
