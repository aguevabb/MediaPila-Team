using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class DineroContador : MonoBehaviour {

    public Text DineroTexto;
    void Update() {
        DineroTexto.text = "$" + Stats.Dinero.ToString();
    }
}
