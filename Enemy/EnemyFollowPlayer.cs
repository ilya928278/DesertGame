using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowPlayer : MonoBehaviour
{
    private NavMeshAgent agent;

    private EnemyParameters enemyParameters;

    private enum State
    {
        idle,
        chase,
        patrol
    } 

    private State state;
    private GameObject player;

    void Start()
    {
        enemyParameters = GetComponent<EnemyParameters>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = enemyParameters.patrolSpeed;

        state = State.patrol;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        //Debug.Log(distanceToPlayer);

        if (Mathf.Abs(distanceToPlayer) > enemyParameters.chasingDistance)
        {
            state = State.patrol;
            agent.speed = enemyParameters.patrolSpeed;
        }

        if (state == State.chase)
        {
            agent.destination = player.transform.position;
        }
        else if (state == State.patrol)
        {
            Patrol();
        }
    }

    void Patrol()
    {
        Debug.Log("----------------------------------");
        Debug.Log($"agent.remainingDistance {agent.remainingDistance}\nagent.stoppingDistance {agent.stoppingDistance}");
        Debug.Log(agent.remainingDistance <= agent.stoppingDistance);
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            float patrolDistance = enemyParameters.patrolDistance;
            agent.destination = new Vector3(
                transform.position.x + Random.Range(-patrolDistance, patrolDistance),
                transform.position.y + Random.Range(-patrolDistance, patrolDistance), 0f);
            Debug.Log(agent.destination);
            Debug.Log($"agent.remainingDistance {agent.remainingDistance}\nagent.stoppingDistance {agent.stoppingDistance}");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            state = State.chase;
            agent.speed = enemyParameters.chasingSpeed;
        }
    }
}
