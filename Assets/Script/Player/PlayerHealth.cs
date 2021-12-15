using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;


public class PlayerHealth : MonoBehaviour
{
    public Animator _playerAnimator;
    public float hitCooldown = 2.5f;
    public bool hit = false;
    [SerializeField] GameObject deathMenu;

    void Start() {
        PlayerPrefs.SetFloat("Health", 100);
    }

    void Update() {
        if (hit) {
            hitCooldown -= Time.deltaTime;
        }
        if (hitCooldown <= 0) {
            hit = false;
            hitCooldown = 2.5f;
        }
    }

    public void TakeDamage(int damage) {
        if (!hit) {
            hit = true;
            PlayerPrefs.SetFloat("Health", PlayerPrefs.GetFloat("Health") - damage);

            _playerAnimator.SetBool("Damage", true);
            _playerAnimator.Play("GetHit");

            if (PlayerPrefs.GetFloat("Health") <= 0) {
                _playerAnimator.Play("die");
                    deathMenu.SetActive(true);
                    Time.timeScale = 0f;
            }
        }
    }
}
