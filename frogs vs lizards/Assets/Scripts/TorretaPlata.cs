using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretaPlata : MonoBehaviour
{
    public int Ganancia = 50;
    public int Segundos = 3;

    void Start()
    {
        StartCoroutine(Esperar());

        transform.Rotate(-90, 0, 180);
    }

    IEnumerator Esperar() 
    {
        yield return new WaitForSeconds(Segundos);
        Stats.Dinero += Ganancia;
        StartCoroutine(Esperar());
    }
}
