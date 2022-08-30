using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class blueprintTorreta {

    public GameObject prefab;
    public int coste;

    public GameObject prefabUpgrade;
    public int costeUpgrade;

    public int GetCosteVenta ()
    {

        return coste / 2;
    }

}
