using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    [SerializeField]
    Transform player;

    [SerializeField]
    Transform castPoint;

    public float aggroRange;
    public float moveSpeed;

    Rigidbody2D rb2d;
    bool isFacingRight;
    bool isAggro = false;
    bool isSearching;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

      if (CanSeePlayer(aggroRange))
      {
          //aggro enemy
          isAggro = true;
          ChasePlayer();
      }
      else
      {
          if(isAggro)
          {
              
              if(!isSearching)
              {
                  isSearching = true;
                  Invoke("StopChasingPlayer", 5);
              }
              
          }
          
      }

      if(isAggro)
      {
          ChasePlayer();
      }
      //distance to player
      /*float distToPlayer = Vector2.Distance(transform.position, player.position);

      if(distToPlayer < aggroRange)
      {
          //code to chase player
          ChasePlayer();
      } 
      else
      {
          //stop chasing player
          StopChasingPlayer();
      } 

      Debug.Log("distToPlayer"+ distToPlayer);*/ 
    }
    
    bool CanSeePlayer(float distance)
    {
        bool val = false;
        float castDist = distance;

        if (isFacingRight == true)
        {
            castDist = -distance;
        }

        Vector2 endPos = castPoint.position + Vector3.right * castDist;
        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if(hit.collider != null)
        {
            if(hit.collider.gameObject.CompareTag("Player"))
            {
                //Aggro Enemy
                val = true;
            }
            else
            {
                val = false;
            }
            Debug.DrawLine(castPoint.position, hit.point, Color.green);

        }else
        {
            Debug.DrawLine(castPoint.position, endPos, Color.red);
        }

        return val;
    }

    void ChasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            //enemy is to the left side of the player, so move right
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(1, 1); //turn right
            isFacingRight = false;
        }
        else
        {
            //enemy is to the right side of the player, so move left
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1); //turn left
            isFacingRight = true;
        }
    }

    void StopChasingPlayer()
    {
        //enemy stops when out of range
        isAggro = false;
        isSearching = false;
        rb2d.velocity = new Vector2(0, 0);
    }
}
