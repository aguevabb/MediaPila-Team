using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneradorOleada : MonoBehaviour
{
    public static int EnemigoVivos = 0;

    public Oleada[] oleadas;

    public Transform spawnPoint;

    public float tiempoEntreOleadas = 5f;
    private float cuentaRegresiva = 2f;

    public Text oleadaCountdownText;

    private int oleadaTotal = 0;

    void Update()
    {
        if (EnemigoVivos > 0)
        {
            return;
        }

        if (cuentaRegresiva <= 0f)
        {
            StartCoroutine(SpawnOleada());
            cuentaRegresiva = tiempoEntreOleadas;
            return;
        }
        cuentaRegresiva -= Time.deltaTime;

        cuentaRegresiva = Mathf.Clamp(cuentaRegresiva, 0f, Mathf.Infinity);

        oleadaCountdownText.text = String.Format("{0:00.00}", cuentaRegresiva);
    }

    IEnumerator SpawnOleada()
    {
        //PlayerPrefs.Rounds++;

        Oleada oleada = oleadas[oleadaTotal]; 

        for (int i = 0; i < oleada.contador; i++)
        {
            SpawnEnemigo(oleada.enemy);
            yield return new WaitForSeconds(1f / oleada.rate);

        }

        oleadaTotal++;

        if (oleadaTotal == oleadas.Length)
        {
            Debug.Log("NIVEL COMPLETADO!");
            this.enabled = false;
        }
    }
    void SpawnEnemigo(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemigoVivos++;
    }
}
