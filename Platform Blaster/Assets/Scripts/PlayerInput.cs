using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour
{
    Player player;
    public bool facingRight = true;
    
    // Start is called before the first frame update
    void Start()
    {
       player = GetComponent<Player> (); 
       DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
      Vector3 directionalInput = new Vector3 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw ("Vertical"));
      player.SetDirectionInput (directionalInput);

      if (Input.GetKeyDown (KeyCode.Space))
      {
          player.OnJumpInputDown ();
      }  
      if (Input.GetKeyUp (KeyCode.Space))
      {
          player.OnJumpInputUp ();
      }

      if (directionalInput.x > 0 && !facingRight)
      {
          Flip();
      }
      else if (directionalInput.x < 0 && facingRight)
      {
          Flip();
      }

    }

    void Flip()
    {
        facingRight = !facingRight;
        
        transform.Rotate(0f, 180f, 0f);
    }
}    