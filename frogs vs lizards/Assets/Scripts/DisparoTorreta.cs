using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoTorreta : MonoBehaviour
{
    //VARIABLES//
    //Disparo y daño//
    public float damage = 10f;
    public float range = 100f;
    public float nextshotRate = 0f;
    public float shotRateTime = 15f;
    public Camera turretCam;
    public Vector3 raycastHits;


    //Munición y recarga//
    public float maxAmmo;
    public float currentAmmo;
    public float reloadTime;
    
    private void Awake()
    {
        currentAmmo = maxAmmo;
    }
    private void FixedUpdate()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextshotRate)
        {
            nextshotRate = Time.time + 1f / shotRateTime;
            tryShot();
            //Shoot();//
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(turretCam.transform.position, turretCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            raycastHits = hit.point;

            Enemy Enemy = hit.transform.GetComponent<Enemy>();
            if (Enemy != null)
            {
                Enemy.TakeDamage(damage);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(turretCam.transform.position, raycastHits);
    }
    
    //RECARGA//
    //Comprobando si hay municion//
    private bool tryShot()
    {
        if (currentAmmo>=1)
        {
            Shoot();
            currentAmmo -= 1;
            return true;
        }

        return false;
    }
    
    //Retardo para la recarga//
    IEnumerator Reload()
    {
        Debug.Log("Recargando.....");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        Debug.Log("Recarga Finalizada");
    }
}

