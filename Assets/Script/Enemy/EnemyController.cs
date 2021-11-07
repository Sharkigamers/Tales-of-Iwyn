using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Animator enemyAnimator;
    public float StartAnimTime = 0.3f;

    private Transform target;
    private Vector3 startPosition;

    public bool inCombat;
    public bool backing;
    public float wanderTime;
    public float patrolRadius = 5f;
    public float movementSpeed = 0.03f;
    public float chasingSpeed = 0.06f;
    public float backingSpeed = 0.08f;
    public float attackRange = 10;
    public float chaseRange = 20;
    public float desiredRotationSpeed = 1f;


    void Awake() {
        enemyAnimator = GetComponentInChildren<Animator>();
        target = GameObject.Find("Player").GetComponent<Transform>();
        startPosition = transform.position;
    }
    void Update()
    {
        if (backing) {
            backToStartPosition();
        }
        else if (!inCombat) {
            Patrol();
        }
        else {
            ChasePlayer();
        }
    }

    private Quaternion getDirection(Vector3 position) {
        var lookPos = position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        return (Quaternion.Slerp(transform.rotation, rotation, desiredRotationSpeed));
    }

    private void backToStartPosition() {
        transform.rotation = getDirection(startPosition);
        transform.Translate(Vector3.forward * backingSpeed);
        if (Vector3.Distance(transform.position, startPosition) <= 1) {
            backing = false;
        }
    }
    private void ChasePlayer() {
        if (Vector3.Distance(transform.position, startPosition) >= chaseRange) {
            inCombat = false;
            backing = true;
        }
        transform.rotation = getDirection(target.position);
        transform.Translate(Vector3.forward * chasingSpeed);
    }

    private void Patrol() {
        if (Vector3.Distance(transform.position,target.position) < attackRange) {
            inCombat = true;
        }
        if (Vector3.Distance(transform.position, startPosition) >= patrolRadius) {
            transform.rotation = getDirection(startPosition);
            transform.Translate(Vector3.forward * movementSpeed);
        }
        if (wanderTime > 0) {
            enemyAnimator.SetFloat("Run", 1f, StartAnimTime, Time.deltaTime);
            transform.Translate(Vector3.forward * movementSpeed);
            wanderTime -= Time.deltaTime;
        }
        else {
            wanderTime = Random.Range(3.0f, 5.0f);
            transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
        }
    }
}
