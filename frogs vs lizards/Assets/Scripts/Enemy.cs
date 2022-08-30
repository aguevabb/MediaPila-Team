using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float velocidadInicial = 10f;
    [HideInInspector]
    public float velocidad;

    public float vidaInicial = 100f;
    private float vida = 0f;

    public int value = 50;

    public Image BarraVida;

    void Start()
    {
        vida = vidaInicial;
        velocidad = velocidadInicial;
    }
    public void TakeDamage (float amount)
    {
        vida -= amount;

        BarraVida.fillAmount = vida / vidaInicial;

        if (vida <= 0f)
        {
            Die();
        }
    }

    public void Slow (float pct)
    {
        velocidad = velocidadInicial * (1f - pct);
    }

    void Die ()
    {
        Stats.Dinero += value;

        GeneradorOleada.EnemigoVivos--;

        Destroy(gameObject);
    }

}

