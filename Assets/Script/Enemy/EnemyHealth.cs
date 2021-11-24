using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;

    private Animator enemyAnimator;
    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage) {
        health -= damage;

        enemyAnimator.SetBool("Damage", true);
        enemyAnimator.Play("GetHit");

        if (health <= 0) {
            enemyAnimator.Play("Die");
            Destroy(gameObject, enemyAnimator.GetCurrentAnimatorStateInfo(0).length);
        }
    }
}
