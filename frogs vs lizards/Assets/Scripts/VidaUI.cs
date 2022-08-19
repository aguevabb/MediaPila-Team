using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaUI : MonoBehaviour
{
    public Text VidaText;

    void Update()
    {
        VidaText.text = Stats.Vida.ToString() + "";
    }
}

