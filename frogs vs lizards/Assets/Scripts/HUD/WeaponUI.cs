using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponUI : MonoBehaviour
{
    public TMP_Text currentBullets;

    private void OnEnable()
    {
        EventManager.current.updateBulletsEvent.AddListener(updateCurrent);
    }

    private void OnDisable()
    {
        
    }


    public void updateCurrent(float newCurrentBullets)
    {
        currentBullets.text = newCurrentBullets.ToString();
    }
}
