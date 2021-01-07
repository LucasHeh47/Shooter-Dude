using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Enemy enemy;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(0, 2), Random.Range(0, 2)), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        target = PlayerMovement.Instance.transform;
        if (Vector3.Distance(target.position, transform.position) > 0.9)
        {
            transform.position += (target.position - transform.position).normalized * enemy.MovementSpeed * Time.fixedDeltaTime;
        }
    }
}
