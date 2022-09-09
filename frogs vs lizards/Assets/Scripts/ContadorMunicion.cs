using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class ContadorMunicion : MonoBehaviour { 

    public Text MunicionTexto;
    void Update() {
        MunicionTexto.text = "Ammo" + DisparoTorreta.currentAmmo.ToString();
    }
}
