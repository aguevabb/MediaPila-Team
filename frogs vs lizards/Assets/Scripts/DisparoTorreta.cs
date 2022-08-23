using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoTorreta : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float shotForce;
    public float shotRate;
    private float shotRateTime = 0;
    [Range(0.1f, 2f)]
    [SerializeField] float destroyTime;

    
    private void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            if (Time.time>shotRateTime)
            {
                GameObject newBullet;
                newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
                newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward*shotForce);
                shotRateTime = Time.time + shotRate;
                Destroy(newBullet, destroyTime);
            }
        }
    }
    /// <summary>
    /// Variable que limita la cantidad de balas activas en el mapa.
    /// </summary>
    public float DestroyTime
    {
        get
        {
            return destroyTime;
        }
        set
        {
            destroyTime = value;
        }
    }
}

