using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float followRange;
    [SerializeField] private float dist;

    private Rigidbody enemyRB;
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        dist = Vector3.Distance(player.transform.position, transform.position);

        if(dist <= followRange)
        {
            enemyRB.AddForce(lookDirection * speed);
        }
    }
}
