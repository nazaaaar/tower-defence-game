using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueSystem : MonoBehaviour
{
    private List<Transform> queue = new List<Transform>();

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy") queue.Add(collider.transform);
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Enemy") queue.RemoveAt(0);
    }
    private void Update()
    {
    }


    public Vector3 GetTarget()
    {
        if (queue.Count != 0) {
            if (!queue[0]) {
                queue.RemoveAt(0);
                return Vector3.zero;
            }
            return queue[0].position; 
        
        }
        return Vector3.zero;
    }

    public Enemy GetEnemy()
    {
        return queue[0].GetComponent<Enemy>();
    }
}
