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
    public GameObject LaserPrefab;
    public GameObject HongoPPrefab;
    public NodoUI nodeUI;

    private blueprintTorreta TorretaAConstruir;
    private nodo NodoSeleccionado;

    public bool PuedeConstruir { get { return TorretaAConstruir != null; } }
    public bool TieneDinero { get { return Stats.Dinero >= TorretaAConstruir.coste; } }

    public void SeleccionarNodo (nodo node)
    {
        if (NodoSeleccionado == node)
        {
            DeseleccionarNode();
            return;
        }
        NodoSeleccionado = node;
        TorretaAConstruir = null;
        nodeUI.SetObjetivo(node);
    }

    public void DeseleccionarNode()
    {
        NodoSeleccionado = null;
        nodeUI.Esconder();
    }
    public void SeleccionarTorretaAConstruir(blueprintTorreta torret)
    {
        TorretaAConstruir = torret;
        DeseleccionarNode();
    }

    public blueprintTorreta ConseguirTorretaAConstruir ()
    {
        return TorretaAConstruir;
    }
}