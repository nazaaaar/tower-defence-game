using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueSystem : MonoBehaviour
{
    private static List<Transform> queue = new List<Transform>();

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy") queue.Add(collider.transform);
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Enemy") queue.Remove(collider.transform);
    }

    public Vector3 GetTarget()
    {
        if (queue.Count != 0) return queue[0].position;
        return Vector3.zero;
    }

    public Enemy GetEnemy()
    {
        return queue[0].GetComponent<Enemy>();
    }
    public static void Remove()
    {
        queue.RemoveAt(0);
    }
}
