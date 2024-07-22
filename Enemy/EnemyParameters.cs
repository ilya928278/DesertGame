using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParameters : MonoBehaviour
{
    [SerializeField] internal float health;
    [SerializeField] internal float damage;
    [SerializeField] internal float attackSpeed;

    [SerializeField] internal float patrolSpeed;
    [SerializeField] internal float chasingSpeed;

    [SerializeField] internal float detectionRadius;
    [SerializeField] internal float chasingDistance;
    [SerializeField] internal float patrolDistance;

    void Start()
    {
        gameObject.AddComponent<CircleCollider2D>();
        CircleCollider2D circleCollider = gameObject.GetComponent<CircleCollider2D>();
        circleCollider.isTrigger = true;
        circleCollider.radius = detectionRadius;
    }
}
