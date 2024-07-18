using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    private GameObject player;

    [SerializeField] private float distanceToStartFollow;
    [SerializeField] private AnimationCurve followSpeedOverDistance;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        float distance = transform.position.magnitude - player.transform.position.magnitude - transform.position.z;
        if (Mathf.Abs(distance) >= distanceToStartFollow) 
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z), followSpeedOverDistance.Evaluate(distance) * Time.deltaTime);
            transform.position = newPosition;
        }
        Debug.Log(distance);
    }
}
