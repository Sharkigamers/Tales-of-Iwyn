using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SceneManager : MonoBehaviour
{
    public void SwitchMenuScene() {  
        UnitySceneManager.LoadScene("Menu Scene");
    }

    public void SwitchGameScene() {  
        UnitySceneManager.LoadScene("terrainV2");
    }

    public void SwitchSettingsScene() {  
        UnitySceneManager.LoadScene("Settings Scene");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
