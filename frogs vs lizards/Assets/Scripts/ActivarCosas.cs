using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarCosas : MonoBehaviour
{
    public bool TiendaActivada = false;
    public bool TorretaActivada;
    [SerializeField] GameObject _tienda;
    [SerializeField] GameObject _torreta;
    void Start()
    {
        _torreta.SetActive(false);
        TorretaActivada = false;
    }
    public void activarTienda()
    {
        if (TiendaActivada == false)
        {
            _tienda.SetActive(false);
            TiendaActivada = true;
        }
        else
        {
            _tienda.SetActive(true);
            TiendaActivada = false;
        }
        Debug.Log(TiendaActivada);
    }
    public void activarTorreta()
    {
        if (TorretaActivada == true)
        {
            _torreta.SetActive(false);
            TorretaActivada = false;
        }
       else
        {
            _torreta.SetActive(true);
            TorretaActivada = true;
        }
        Debug.Log(TorretaActivada);
    }
}
