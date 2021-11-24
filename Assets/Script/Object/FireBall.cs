using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public int Damage = 50;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider hit) {
        if (hit.gameObject.tag != "Player") {
            if (hit.gameObject.tag == "Enemy") {
                hit.gameObject.GetComponent<EnemyHealth>().TakeDamage(Damage);
            }
            Destroy(gameObject);
        }
    }
}
