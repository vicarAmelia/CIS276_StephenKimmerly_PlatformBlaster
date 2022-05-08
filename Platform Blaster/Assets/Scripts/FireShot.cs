using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShot : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
      rb.velocity = transform.right * speed;  
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyAI enemy = hitInfo.GetComponent<EnemyAI>();
        if (enemy != null)
        {
          enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    
}
