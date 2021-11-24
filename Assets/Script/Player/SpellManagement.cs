using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManagement : MonoBehaviour
{
    public GameObject FireBallPrefab;
    public ParticleSystem Heal;
    public float FirePower;

    private Transform playerPosition;

    void Awake() {
        playerPosition =  GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Heal.Play();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            for (int i=0; i< Inventory.instance.items.Count; i++) {
                if (Inventory.instance.items[i].ItemName == "Crystal Shard") {
                    // Yes
                    CastFireBall();
                    break; //don't need to check the remaining ones now that we found one
                }
            }
        }        
    }

    private void CastFireBall() {
        Vector3 fireBallPos = new Vector3(playerPosition.position.x, (playerPosition.position.y + 1), playerPosition.position.z);
        GameObject FireBall = Instantiate(FireBallPrefab, fireBallPos, Quaternion.identity);
        FireBall.GetComponent<Rigidbody>().velocity = playerPosition.TransformDirection(Vector3.forward * FirePower);
    }
}
