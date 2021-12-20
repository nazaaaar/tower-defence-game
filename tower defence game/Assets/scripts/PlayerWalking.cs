using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalking : MonoBehaviour
{
    public List<Transform> pointsTransform;
    public float speed = 2;
    private Vector3[] points;
    private int currentPointIndex = 0;

    Vector3 heading;
    float distance;
    Vector3 direction;
    void Start()
    {
        int lenght = pointsTransform.Count;
        points = new Vector3[lenght];
        for (int i = 0; i<lenght; i++)
        {
            points[i] = pointsTransform[i].position;
        }

        heading = points[currentPointIndex] - transform.position;
        distance = heading.magnitude;
        direction = heading / distance;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if ((transform.position - points[currentPointIndex]).sqrMagnitude < 0.5) {
            currentPointIndex++;
            heading = points[currentPointIndex] - transform.position;
            distance = heading.magnitude;
            direction = heading / distance;
        }
    }
}
