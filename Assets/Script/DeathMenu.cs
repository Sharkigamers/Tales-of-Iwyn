using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;


public class DeathMenu : MonoBehaviour
{
    [SerializeField] GameObject deathMenu;
    public Animator _playerAnimator;
    public GameObject player;

    public void Revive() {
        Vector3 respawn = new Vector3(PlayerPrefs.GetFloat("positionX"), PlayerPrefs.GetFloat("positionY"), PlayerPrefs.GetFloat("positionZ"));
        Debug.Log(respawn);
        Debug.Log(player.transform.position);
        player.transform.position = respawn;
        PlayerPrefs.SetFloat("Health", 100);
        _playerAnimator.Play("attack01");
        deathMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Home() {
        Time.timeScale = 1f;
        UnitySceneManager.LoadScene(0);
    }
}