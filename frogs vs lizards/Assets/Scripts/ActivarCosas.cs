using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarCosas : MonoBehaviour
{
    public bool TiendaActivada = false;
    public bool TorretaActivada;
    public bool MunicionActivada;
    public bool HabilidadesActivada;
    [SerializeField] GameObject _tienda;
    [SerializeField] GameObject _torreta;
    [SerializeField] GameObject _municion;
    [SerializeField] GameObject _habilidades;
    void Start()
    {
        MunicionActivada = false;
        _municion.SetActive(false);
        TorretaActivada = false;
        _torreta.SetActive(false);

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
    public void activarMunicion()
    {
        if (MunicionActivada == true)
        {
            _municion.SetActive(false);
            MunicionActivada = false;
        }
        else
        {
            _municion.SetActive(true);
            MunicionActivada = true;
        }
        Debug.Log(MunicionActivada);
    }
    public void activarHabilidades()
    {
        if (HabilidadesActivada == true)
        {
            _habilidades.SetActive(false);
            HabilidadesActivada = false;
        }
        else
        {
            _habilidades.SetActive(true);
            HabilidadesActivada = true;
        }
        Debug.Log(HabilidadesActivada);
    }
}
