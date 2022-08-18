using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tienda : MonoBehaviour{

    public blueprintTorreta torretaStandar;
    public blueprintTorreta misiles;

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

}
