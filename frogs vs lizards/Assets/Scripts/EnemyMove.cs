using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float velocidad = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        target = Waypoints.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * velocidad * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();

        }
    }
    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

}
