using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodoUI : MonoBehaviour
{
    private nodo objetivo;

    public GameObject ui;

    public Text costeUpgrade;
    public Button botonUpgrade;

    public void SetObjetivo (nodo _objetivo)
    {
        objetivo = _objetivo;

        transform.position = objetivo.GetBuildPosition();

        if (!objetivo.estaMejorada)
        {
            costeUpgrade.text = "$" + objetivo.BlueprintTorreta.costeUpgrade;
            botonUpgrade.interactable = true;
        }
        else
        {
            costeUpgrade.text = "MEJORADA";
            botonUpgrade.interactable = false;
        }

        ui.SetActive(true);
    }

    public void Esconder ()
    {
        ui.SetActive(false);
    }

    public void Upgrade ()
    {
        objetivo.UpgradeTorreta();
        BuildManager.instancia.DeseleccionarNode();
    }
}
