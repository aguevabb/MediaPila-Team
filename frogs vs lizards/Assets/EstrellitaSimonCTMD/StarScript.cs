using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class StarScript : MonoBehaviour
{
    public Transform followTarget;
    Vector3 offset;
    public GameObject starPrefab;
    public int numberStars;
    public float skyAltitude;
    public float maxDistance;

    private void Start()
    {
        offset = followTarget.transform.position;
        GenerateSky();
    }

    private void LateUpdate()
    {
        transform.position = followTarget.position + offset;
        
    }

    void GenerateSky()
    {
        float xPos, zPos;
        Vector3 pos;
        pos.y = skyAltitude;
        for (int i = 0; i < numberStars; i++)
        {
            pos = Random.onUnitSphere * maxDistance;
            if (pos.y<0)
            {
                pos.y = -pos.y;
            }

            GameObject s = Instantiate(starPrefab, pos, starPrefab.transform.rotation);
            s.transform.parent = transform;
            s.transform.LookAt(followTarget);
        }
    }
}
