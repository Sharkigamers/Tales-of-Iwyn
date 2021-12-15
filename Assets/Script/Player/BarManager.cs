﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarManager : MonoBehaviour
{
    public Image healthBar;
    public Image manaBar;
 
    void Update()
    {
        healthBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, PlayerPrefs.GetFloat("Health") * 2);
        manaBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, PlayerPrefs.GetFloat("Mana") / 1.25f);        
    }
}
