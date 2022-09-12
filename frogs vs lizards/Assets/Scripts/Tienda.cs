using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tienda : MonoBehaviour{

    public blueprintTorreta torretaStandar;
    public blueprintTorreta misiles;
    public blueprintTorreta RayoLaser;
    public blueprintTorreta HongoPlata;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instancia;
    }

    public void SeleccionarTorreta ()
    {
        Debug.Log("Torreta Comprada");
        buildManager.SeleccionarTorretaAConstruir(torretaStandar);
    }
    public void SeleccionarMisisles()
    {
        Debug.Log("Otra Torreta Comprada");
        buildManager.SeleccionarTorretaAConstruir(misiles);
    }

    public void SeleccionarRayoLaser()
    {
        Debug.Log("Otra Torreta mas Comprada");
        buildManager.SeleccionarTorretaAConstruir(RayoLaser);
    }

    public void SeleccionarHongoPlata()
    {
        Debug.Log("Otra Torreta mas Comprada");
        buildManager.SeleccionarTorretaAConstruir(HongoPlata);
    }
}
