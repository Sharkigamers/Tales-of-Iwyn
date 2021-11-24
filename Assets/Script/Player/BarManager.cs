using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarManager : MonoBehaviour
{
    public float health = 100;
    public float mana = 100;
    public Image healthBar;
    public Image manaBar;
 
    void Update()
    {
        healthBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, health * 2);
        manaBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, mana * 2);        
    }
}
