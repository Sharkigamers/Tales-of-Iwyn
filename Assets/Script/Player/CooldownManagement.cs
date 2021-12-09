using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownManagement : MonoBehaviour
{
    public Image cooldownImage;
    public float coolDown = 2.5f;
    public bool isCoolDown = false;

    void Start() {
        cooldownImage.fillAmount = 0;
    }

    void Update()
    {
        if (isCoolDown) {
            cooldownImage.fillAmount += 1 / coolDown * Time.deltaTime;

            if (cooldownImage.fillAmount >= 1) {
                cooldownImage.fillAmount = 0;
                isCoolDown = false;
            }
        }
    }
}
