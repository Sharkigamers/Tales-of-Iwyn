using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManagement : MonoBehaviour
{
    public GameObject FireBallPrefab;
    public GameObject WaterBallPrefab;
    public ParticleSystem Heal;
    public float FirePower;
    public Animator _playerAnimator;
    public bool cast = false;

    private Transform playerPosition;
    private float manaRegenTimer = 0f;
    public float delayAmount = 1f;

    private float effectiveCooldown = 0f;
    void Awake() {
        playerPosition =  GameObject.Find("Player").GetComponent<Transform>();
        PlayerPrefs.SetFloat("Mana", 250);
        effectiveCooldown = CooldownManagement.coolDown;
    }
        
    void Update()
    {
        manaRegenTimer += Time.deltaTime;
    
        if (manaRegenTimer >= delayAmount)  {
            manaRegenTimer = 0f;
            if (PlayerPrefs.GetFloat("Mana") < 250) {
                PlayerPrefs.SetFloat("Mana", PlayerPrefs.GetFloat("Mana") + 5);
            }
            else if (PlayerPrefs.GetFloat("Mana") == 244) {
                PlayerPrefs.SetFloat("Mana", PlayerPrefs.GetFloat("Mana") + 5);
            }
        }

        if (cast) {
            effectiveCooldown -= Time.deltaTime;
        }
        if (effectiveCooldown <= 0) {
            cast = false;
            effectiveCooldown = CooldownManagement.coolDown;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            for (int i = 0; i < Inventory.instance.items.Count; i++)
            {
                if (Inventory.instance.items[i].ItemName == "Crystal Shard Nature")
                {
                    if (PlayerPrefs.GetFloat("Mana") >= 25)
                    {
                        if (!cast)
                        {
                            cast = true;
                            DisplayCoolDown(GameObject.FindGameObjectsWithTag("Cooldown"));
                            PlayerPrefs.SetFloat("Mana", PlayerPrefs.GetFloat("Mana") - 25);
                            Heal.Play();
                            _playerAnimator.SetBool("Cast", true);
                            _playerAnimator.Play("attack01");
                            if (PlayerPrefs.GetFloat("Health") <= 80)
                            {
                                PlayerPrefs.SetFloat("Health", PlayerPrefs.GetFloat("Health") + 20);
                            }
                            else if (PlayerPrefs.GetFloat("Health") > 80 && PlayerPrefs.GetFloat("Health") <= 99)
                            {
                                PlayerPrefs.SetFloat("Health", 100);
                            }
                        }
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
                for (int i=0; i< Inventory.instance.items.Count; i++) {
                    if (Inventory.instance.items[i].ItemName == "Crystal Shard") {
                        if (PlayerPrefs.GetFloat("Mana") >= 30) {
                            if (!cast) {
                                cast = true;
                                DisplayCoolDown(GameObject.FindGameObjectsWithTag("Cooldown"));
                                PlayerPrefs.SetFloat("Mana", PlayerPrefs.GetFloat("Mana") - 30);
                                CastFireBall();
                                _playerAnimator.SetBool("Cast", true);
                                _playerAnimator.Play("attack01");
                            }
                        }
                    break; //don't need to check the remaining ones now that we found one
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            for (int i=0; i< Inventory.instance.items.Count; i++) {
                if (Inventory.instance.items[i].ItemName == "Crystal Shard Water") {
                    if (PlayerPrefs.GetFloat("Mana") >= 30) {
                        if (!cast) {
                            cast = true;
                            DisplayCoolDown(GameObject.FindGameObjectsWithTag("Cooldown"));
                            PlayerPrefs.SetFloat("Mana", PlayerPrefs.GetFloat("Mana") - 30);
                            CastWaterBall();
                            _playerAnimator.SetBool("Cast", true);
                            _playerAnimator.Play("attack01");
                        }
                    }
                }
            }
        }
    }

    private void CastFireBall() {
        Vector3 fireBallPos = new Vector3(playerPosition.position.x, (playerPosition.position.y + 1), playerPosition.position.z);
        GameObject FireBall = Instantiate(FireBallPrefab, fireBallPos, Quaternion.identity);
        FireBall.GetComponent<Rigidbody>().velocity = playerPosition.TransformDirection(Vector3.forward * FirePower);
    }

    private void DisplayCoolDown(GameObject[] cooldowns) {
        foreach(GameObject obj in cooldowns) {
            obj.GetComponent<CooldownManagement>().isCoolDown = true;
        }
    }

    private void CastWaterBall() {
        Vector3 waterBallPos = new Vector3(playerPosition.position.x, (playerPosition.position.y + 1), playerPosition.position.z);
        GameObject WaterBall = Instantiate(WaterBallPrefab, waterBallPos, Quaternion.identity);
        WaterBall.GetComponent<Rigidbody>().velocity = playerPosition.TransformDirection(Vector3.forward * FirePower);
    }
}
