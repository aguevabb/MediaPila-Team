using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public Camera camarin;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && camarin.fieldOfView > 10)
        {
            GetComponent<Camera>().fieldOfView--;
            GetComponent<Camera>().fieldOfView--;
            Debug.Log("Suma");
            //GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y - .8f, transform.position.z + .55f);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && camarin.fieldOfView < 60)
        {
            GetComponent<Camera>().fieldOfView++;
            GetComponent<Camera>().fieldOfView++;
            Debug.Log("Resta");
            //GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y + .8f, transform.position.z - .55f);
        }
    }
}
