using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManagement : MonoBehaviour
{
    public GameObject FireBallPrefab;
    public ParticleSystem Heal;
    public float FirePower;
    public Animator _playerAnimator;
    public float castCooldown = 2.5f;
    public bool cast = false;

    private Transform playerPosition;
    private float manaRegenTimer = 0f;
    public float delayAmount = 1f;

    void Awake() {
        playerPosition =  GameObject.Find("Player").GetComponent<Transform>();
        PlayerPrefs.SetInt("Mana", 100);
    }
        
    void Update()
    {
        manaRegenTimer += Time.deltaTime;
    
        if (manaRegenTimer >= delayAmount)  {
            manaRegenTimer = 0f;
            if (PlayerPrefs.GetInt("Mana") < 100) {
                PlayerPrefs.SetInt("Mana", PlayerPrefs.GetInt("Mana") + 2);
            }
            else if (PlayerPrefs.GetInt("Mana") == 99) {
                PlayerPrefs.SetInt("Mana", PlayerPrefs.GetInt("Mana") + 2);
            }
        }

        if (cast) {
            castCooldown -= Time.deltaTime;
        }
        if (castCooldown <= 0) {
            cast = false;
            castCooldown = 2.5f;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (PlayerPrefs.GetInt("Mana") >= 25) {
                if (!cast) {
                    cast = true;
                    PlayerPrefs.SetInt("Mana", PlayerPrefs.GetInt("Mana") - 25);
                    Heal.Play();
                    _playerAnimator.SetBool("Cast", true);
                    _playerAnimator.Play("attack01");
                    if (PlayerPrefs.GetInt("Health") <= 80) {
                        PlayerPrefs.SetInt("Health", PlayerPrefs.GetInt("Health") + 20);
                    }
                    else if (PlayerPrefs.GetInt("Health") > 80 && PlayerPrefs.GetInt("Health") <= 99) {
                         PlayerPrefs.SetInt("Health", 100);
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
                for (int i=0; i< Inventory.instance.items.Count; i++) {
                    if (Inventory.instance.items[i].ItemName == "Crystal Shard") {
                        if (PlayerPrefs.GetInt("Mana") >= 30) {
                            if (!cast) {
                                cast = true;
                                PlayerPrefs.SetInt("Mana", PlayerPrefs.GetInt("Mana") - 30);
                                CastFireBall();
                                _playerAnimator.SetBool("Cast", true);
                                _playerAnimator.Play("attack01");
                            }
                        }
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
