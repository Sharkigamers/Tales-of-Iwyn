using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audio : MonoBehaviour
{
    public static audio audioInstance;
    private void Awake() {
        if (audioInstance != null && audioInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        audioInstance = this;
        DontDestroyOnLoad(this);
    }
}
