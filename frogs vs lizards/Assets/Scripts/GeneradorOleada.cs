using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneradorOleada : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float tiempoEntreOleadas = 5f;
    private float cuentaRegresiva = 2f;

    public Text oleadaCountdownText;

    public int oleadaTotal = 0;
    
    private int oleadaNumero = 0;

    void Update()
    {
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
        Debug.Log("!!!Oleada en Camino!!!");

        oleadaTotal = oleadaNumero;

        oleadaNumero = oleadaTotal + 1;

        for (int i = 0; i < oleadaNumero; i++)
        {
            SpawnEnemigo();
            yield return new WaitForSeconds(0.5f);

        }
    }
    void SpawnEnemigo()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
