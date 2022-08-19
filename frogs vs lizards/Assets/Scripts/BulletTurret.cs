using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTurret : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timelife;

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
        if (other.tag=="Enemy")
        {
            Destroy(gameObject);
            
            Debug.Log("destruido");
        }
    }
}
