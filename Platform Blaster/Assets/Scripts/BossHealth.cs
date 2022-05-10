using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
   public int health = 500; 

   public bool isInvulnerable = false;

   public void TakeDamage(int damage)
   {
       health -= damage;

       if (health <= 0)
       {
           Die();
       } 
   }

   void Die()
   {
       Destroy(gameObject);
   }
}
