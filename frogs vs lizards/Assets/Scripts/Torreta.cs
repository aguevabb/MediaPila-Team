using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Torreta : MonoBehaviour
{

	private Transform target;
	private Enemy targetEnemy;

	[Header("General")]

	public float rango = 15f;

	[Header("Usar Balas (Predeterminado)")]

	public GameObject balaPrefab;
	public float cadencia = 1f;
	private float contadorCadencia = 0f;

	[Header("Usar Laser")]

	public bool usarLaser = false;
	public int danoPorTiempo = 30;
	public float slowAmount = 0.5f;
	public LineRenderer lineRenderer;
	public ParticleSystem EfectoImpacto;

	[Header("Configuracion de Unity")]

	public string enemyTag = "Enemy";

	public Transform Rotador;
	public float velocidadDeGiro = 10f;

	public Transform firePoint;
	
	[Header("Municion y recarga")]
	public float maxAmmo;
	public float currentAmmo;
	//public float reloadTime;---->HAY QUE MODIFICAR ESTE SCRIPT//
	

	// Use this for initialization
	
	private void Awake()
	{
		currentAmmo = maxAmmo;
	}
	void Start()
	{
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}

	void UpdateTarget()
	{
		GameObject[] enemigos = GameObject.FindGameObjectsWithTag(enemyTag);
		float menorDistancia = Mathf.Infinity;
		GameObject enemigoMasCerca = null;
		foreach (GameObject enemigo in enemigos)
		{
			float distanciaDelEnemigo = Vector3.Distance(transform.position, enemigo.transform.position);
			if (distanciaDelEnemigo < menorDistancia)
			{
				menorDistancia = distanciaDelEnemigo;
				enemigoMasCerca = enemigo;
			}
		}

		if (enemigoMasCerca != null && menorDistancia <= rango)
		{
			target = enemigoMasCerca.transform;
			targetEnemy = enemigoMasCerca.GetComponent<Enemy>();
		}
		else
		{
			target = null;
		}

	}

    void Update()
    {
		if (target == null)
        {
			if (usarLaser)
            {
				if (lineRenderer.enabled)
                {
					lineRenderer.enabled = false;
					EfectoImpacto.Stop();
				}
					
            }
			return;
        }

		LockOnTarget();

		if (usarLaser)
        {
			Laser();
        }else
        {
			if (contadorCadencia <= 0f)
			{
				//Disparar();//
				tryShot();
				contadorCadencia = 1f / cadencia;
			}

			contadorCadencia -= Time.deltaTime;
		}

    }

	void LockOnTarget ()
    {
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotacion = Quaternion.Lerp(Rotador.rotation, lookRotation, Time.deltaTime * velocidadDeGiro).eulerAngles;
		Rotador.rotation = Quaternion.Euler(0f, rotacion.y, 0f);
	}

	void Laser()
    {
		targetEnemy.TakeDamage(danoPorTiempo * Time.deltaTime);
		targetEnemy.Slow(slowAmount);

		if (!lineRenderer.enabled)
        {
			lineRenderer.enabled = true;
			EfectoImpacto.Play();

		}
			

		lineRenderer.SetPosition(0, firePoint.position);
		lineRenderer.SetPosition(1, target.position);

		Vector3 dir = firePoint.position - target.position;

		EfectoImpacto.transform.position = target.position + dir.normalized;

		EfectoImpacto.transform.rotation = Quaternion.LookRotation(dir);
	}

	void Disparar ()
    {
		//Debug.Log("DISPARAR!!!");//

		GameObject balaGo = (GameObject)Instantiate(balaPrefab, firePoint.position, firePoint.rotation);
		Bala bala = balaGo.GetComponent<Bala>();

		if (bala != null)
			bala.Buscar(target);
    }
	//RECARGA//
	//Comprobando si hay municion//
	private bool tryShot()
	{
		if (currentAmmo>=1)
		{
			Disparar();
			currentAmmo -= 1;
			return true;
		}

		return false;
	}

    // Update is called once per frame

    void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, rango);
	}
}