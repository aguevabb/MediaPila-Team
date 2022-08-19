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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time>shotRateTime)
            {
                GameObject newBullet;
                newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
                newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward*shotForce);
                shotRateTime = Time.time + shotRate;
                Destroy(newBullet, 2);
            }
        }
    }
}

