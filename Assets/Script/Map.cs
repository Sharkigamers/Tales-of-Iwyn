using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{
    [SerializeField] GameObject mapDisplay;
    private bool isActive = false;

    void Update() {
        if (Input.GetKeyDown(KeyCode.M)) {
            isActive = !isActive;            
            if (!isActive) {
                mapDisplay.SetActive(false);
                Time.timeScale = 1f;
            } else {
            mapDisplay.SetActive(true);
            Time.timeScale = 0f;
            }
        }
    }
}
