using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class nodo : MonoBehaviour
{
    public Color hoverColor;
    public Color DineroInsuficienteColor;
    public Vector3 posittionOffSet;

    [Header("Optional")]
    public GameObject torreta;
    [Header("Optional")]
    public blueprintTorreta BlueprintTorreta;
    [Header("Optional")]
    public bool estaMejorada = false;

    private Renderer rend;
    private Color colorInicial;
    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        colorInicial = rend.material.color;
        buildManager = BuildManager.instancia;
    }

    public Vector3 GetBuildPosition ()
    {
        return transform.position + posittionOffSet;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (torreta != null)
        {
            buildManager.SeleccionarNodo(this);
            return;
        }
        if (!buildManager.PuedeConstruir)
            return;

        BuildTorreta(buildManager.ConseguirTorretaAConstruir());

    }

    void BuildTorreta (blueprintTorreta blueprint)

    {
        if (Stats.Dinero < blueprint.coste)
        {
            Debug.Log("dinero insuficiente");
            return;
        }

        Stats.Dinero -= blueprint.coste;

        GameObject _torreta = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        torreta = _torreta;

        BlueprintTorreta = blueprint;

        Debug.Log("Torreta construida, dinero restante: " + Stats.Dinero);
    }

    public void UpgradeTorreta ()
    {
        if (Stats.Dinero < BlueprintTorreta.costeUpgrade)
        {
            Debug.Log("dinero insuficiente para mejorar");
            return;
        }

        Stats.Dinero -= BlueprintTorreta.costeUpgrade;

        //Destruye torreta sin mejorar
        Destroy(torreta);

        //Crea torreta mejorada
        GameObject _torreta = (GameObject)Instantiate(BlueprintTorreta.prefabUpgrade, GetBuildPosition(), Quaternion.identity);
        torreta = _torreta;

        estaMejorada = true;

        Debug.Log("Torreta Mejorada, dinero restante: " + Stats.Dinero);
    }

    public void VenderTorreta ()
    {
        Stats.Dinero += BlueprintTorreta.GetCosteVenta();

        Destroy(torreta);
        BlueprintTorreta = null;

    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.PuedeConstruir)
            return;
        if (buildManager.TieneDinero)
        {
        rend.material.color = hoverColor;
        } else
        {
            rend.material.color = DineroInsuficienteColor;
        }

    }

    void OnMouseExit()
    {
        rend.material.color = colorInicial;
    }
}
