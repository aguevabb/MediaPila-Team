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

    //FindObjectOfType<"clase">(); sirve para clases unicas, se usa mayormente en el "start", nunca poner en update//
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Enemy")
        {
            GameObject destruido = other.gameObject;
            Debug.Log(destruido);
            Destroy(destruido);
            Debug.Log("destruido");
        }
    }
}
