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

        buildManager.ConstruirTorretaOn(this);

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
