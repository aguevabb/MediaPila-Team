using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using EZCameraShake;

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
    public int maxAmmo;
    public static int currentAmmo;
    public float reloadTime;


    //Efectos//
    public VisualEffect MuzzleL;
    public VisualEffect MuzzleR;
    public bool Muzzling = false;


    public void Awake()
    {
        
        currentAmmo = maxAmmo;
    }

    private void FixedUpdate()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextshotRate)
        {
            nextshotRate = Time.time + 1f / shotRateTime;
            tryShot();

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
            CameraShaker.Instance.ShakeOnce(2f, 2f, 1f, 1f);

            Enemy Enemy = hit.transform.GetComponent<Enemy>();
            if (Enemy != null)
            {
                Enemy.TakeDamage(damage);
            }
            PlayScript PlayScript = hit.transform.GetComponent<PlayScript>();
            if (PlayScript != null)
            {
                PlayScript.startgame();
            }
        }
        Muzzling = !Muzzling;
        Muzzle();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(turretCam.transform.position, raycastHits);
    }
    
    //RECARGA//
    //Comprobando si hay municion//
    public bool tryShot()
    {

        if (currentAmmo>=1)
        {
            Shoot();
            currentAmmo -= 1;
            CameraShaker.Instance.ShakeOnce(2f, 2f, 1f, 1f);
            return true;

        }

        return false;
    }

    void Muzzle()
    {
        if (Muzzling)
        {
            MuzzleL.Play();
        }
        else
        {
            MuzzleR.Play();
        }
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

