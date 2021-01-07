using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public Enemy enemy;
    private Transform target;

    private float nextTimeToAttack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = PlayerMovement.Instance.transform;
        if (Vector3.Distance(target.position, transform.position) <= 1 && Time.time >= nextTimeToAttack)
        {
            nextTimeToAttack = Time.time + 1f * enemy.AttackRate / 2;
            PlayerHealth.Instance.TakeDamage(enemy.Damage);
        }
    }
}
