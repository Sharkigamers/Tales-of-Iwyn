using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    private Animator enemyAnimator;
    public float StartAnimTime = 0.3f;

    private Transform target;
    private Vector3 startPosition;
    private NavMeshAgent agent;
    private bool moving = false;
    private Vector3 patrolDestination = new Vector3(0, 0, 0);
    private bool inCombat = false;
    private bool backing = false;

    public float movementSpeed = 0.03f;
    public float chasingSpeed = 0.06f;
    public float backingSpeed = 0.08f;
    public float patrolRadius = 5f;
    public float attackRange = 10;
    public float chaseRange = 20;

    public int attackDamage = 20;



    void Awake() {
        enemyAnimator = GetComponentInChildren<Animator>();
        target = GameObject.Find("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
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

    private void backToStartPosition() {
        agent.speed = backingSpeed;
        agent.SetDestination(startPosition);
        if (Vector3.Distance(transform.position, startPosition) < 0.5f) {
            backing = false;
            moving = false;
        }
    }

    private void ChasePlayer() {
        if (Vector3.Distance(transform.position, startPosition) >= chaseRange) {
            inCombat = false;
            backing = true;
        }
        agent.speed = chasingSpeed;
        agent.SetDestination(target.position);
    }

    private Vector3 GetRandomPoint(Vector3 center, float maxDistance) {
        Vector3 randomPos = Random.insideUnitSphere * maxDistance + center;
        NavMeshHit hit;

        NavMesh.SamplePosition(randomPos, out hit, maxDistance, NavMesh.AllAreas);
        return hit.position;
    }

    private void Patrol() {
        enemyAnimator.SetFloat("Run", 1f, StartAnimTime, Time.deltaTime);
        agent.speed = movementSpeed;
        
        if (Vector3.Distance(transform.position,target.position) < attackRange) {
            inCombat = true;
        }

        if (!moving) {
            patrolDestination = GetRandomPoint(startPosition, patrolRadius);
            moving = true;
            agent.SetDestination(patrolDestination);
        }
        else {
            if (Vector3.Distance(transform.position, patrolDestination) < 0.5f) {
                moving = false;
            }
        }
    }

    private void OnCollisionEnter(Collision hit) {
        if (hit.gameObject.tag == "Player") {
            hit.gameObject.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }
    }

}
