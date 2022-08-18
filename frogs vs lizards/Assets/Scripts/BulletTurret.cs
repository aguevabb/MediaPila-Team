using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTurret : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _timelife = 3f;

    private void Start()
    {
        Destroy(gameObject, _timelife);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward*Time.deltaTime*_speed);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            Destroy(gameObject);
        }
    }
}
