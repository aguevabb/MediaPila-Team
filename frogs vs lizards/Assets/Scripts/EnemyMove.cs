using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMove : MonoBehaviour
{
    public float velocidad = 10f;

    public float vidaInicial = 100f;
    private float vida = 0f;

    public int value = 50;

    public Image BarraVida;

    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        target = Waypoints.points[0];
        vida = vidaInicial;
    }

    public void TakeDamage (float amount)
    {
        vida -= amount;

        BarraVida.fillAmount = vida / vidaInicial;

        if (vida <= 0f)
        {
            Die();
        }
    }

    void Die ()
    {
        Stats.Dinero += value;
        Destroy(gameObject);
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
            BaseFinal();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];

    }

    void BaseFinal()
    {
        Stats.Vida--;
        Destroy(gameObject);
    }

}

