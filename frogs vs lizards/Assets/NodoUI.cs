using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodoUI : MonoBehaviour
{
    private nodo objetivo;

    public GameObject ui;

    public void SetObjetivo (nodo _objetivo)
    {
        objetivo = _objetivo;

        transform.position = objetivo.GetBuildPosition();

        ui.SetActive(true);
    }

    public void Esconder ()
    {
        ui.SetActive(false);
    }
}
