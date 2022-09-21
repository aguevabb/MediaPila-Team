using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;
    public float turnSpeed;
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();

        target = Waypoints.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.velocidad * Time.deltaTime, Space.World);

        Quaternion q = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, turnSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();

        }

        enemy.velocidad = enemy.velocidadInicial;

    }
    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            BaseFinal();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];

    }

    void BaseFinal()
    {
        Stats.Vida--;
        GeneradorOleada.EnemigoVivos--;
        Destroy(gameObject);
    }
}
