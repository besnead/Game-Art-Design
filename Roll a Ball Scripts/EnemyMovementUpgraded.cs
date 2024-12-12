using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementUpgraded : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;

    // Delay in seconds before the enemy starts moving
    public float startDelay = 2.0f; // Adjust this value as needed

    // Toggle for distance-based following
    [Header("Follow Settings")]
    public bool followWithinDistance = true; // Toggle to enable/disable following
    public float followDistance = 10.0f; // Distance within which the enemy will follow the player

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        StartCoroutine(StartMovementAfterDelay());
    }

    private IEnumerator StartMovementAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(startDelay);

        // Start following the player
        while (true)
        {
            if (player != null)
            {
                // Check if the player is within the follow distance
                float distanceToPlayer = Vector3.Distance(transform.position, player.position);

                if (!followWithinDistance || (followWithinDistance && distanceToPlayer <= followDistance))
                {
                    navMeshAgent.SetDestination(player.position);
                }
                else
                {
                    // Optionally, stop moving if the enemy is not following
                    navMeshAgent.ResetPath();
                }
            }
            yield return null; // Wait for the next frame
        }
    }
}
