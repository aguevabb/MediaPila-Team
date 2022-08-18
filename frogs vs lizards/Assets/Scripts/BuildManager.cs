using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instancia;

    void Awake()
    {
        if (instancia != null)
        {
            Debug.LogError("Mas de un CONSTRUCTOR en escena!!!");
            return;
        }
        instancia = this;
    }

    public GameObject TorretaStandarPrefab;
    public GameObject OtroTorretaStandarPrefab;


    private blueprintTorreta TorretaAConstruir;

    public bool PuedeConstruir { get { return TorretaAConstruir != null; } }

    public void ConstruirTorretaOn(nodo node)
    {
        if (Stats.Dinero < TorretaAConstruir.coste)
        {
            Debug.Log("dinero insuficiente");
            return;
        }

        Stats.Dinero -= TorretaAConstruir.coste;

        GameObject torreta = (GameObject)Instantiate(TorretaAConstruir.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.torreta = torreta;

        Debug.Log("Torreta construida, dinero restante: " + Stats.Dinero);
    }

    public void SeleccionarTorretaAConstruir(blueprintTorreta torret)
    {
        TorretaAConstruir = torret;
    }

}