using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private Transform target;

    public float velocidad = 70f;
    public float RadioExplosion = 0f;
    public GameObject efectoImpacto;

    public void Buscar(Transform _target)
    {
        target = _target;
    }


    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisfFrame = velocidad * Time.deltaTime;

        if (dir.magnitude <= distanceThisfFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisfFrame, Space.World);
        transform.LookAt(target);

    }

    void HitTarget()
    {
        GameObject efectoIns = Instantiate(efectoImpacto, transform.position, transform.rotation);
        Destroy(efectoIns, 2f);

        if (RadioExplosion > 0f)
        {

            Explotar();

        }
        else
        {
            Dano(target);
        }

        Destroy(gameObject);
    }

    void Explotar()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, RadioExplosion);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Dano(collider.transform);
            }
        }
    }

    void Dano(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, RadioExplosion);

    }
}
