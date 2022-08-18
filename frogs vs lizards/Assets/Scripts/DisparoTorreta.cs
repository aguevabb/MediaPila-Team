using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoTorreta : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _timer = 0.25f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(_bullet, transform.position, transform.rotation);

        }
    }
}

