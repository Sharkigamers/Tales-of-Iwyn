using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Animator _playerAnimator;
    public float hitCooldown = 2.5f;
    public bool hit = false;

    void Start() {
        PlayerPrefs.SetInt("Health", 100);
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
            PlayerPrefs.SetInt("Health", PlayerPrefs.GetInt("Health") - damage);

            _playerAnimator.SetBool("Damage", true);
            _playerAnimator.Play("GetHit");

            if (PlayerPrefs.GetInt("Health") <= 0) {
                _playerAnimator.Play("die");
                //DED
            }
        }
    }
}
