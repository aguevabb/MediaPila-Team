using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponUI : MonoBehaviour
{
    public TMP_Text currentBullets;

    public void OnEnable()
    {
        EventManager.current.UpdateBulletsEvent.AddListener(UpdateCurrent);
    }

    private void OnDisable()
    {
        
    }


    private void UpdateCurrent(int newCurrentBullets)
    {
        currentBullets.text = newCurrentBullets.ToString();
    }
}
