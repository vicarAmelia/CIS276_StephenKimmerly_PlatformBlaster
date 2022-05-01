using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour
{
    Player player;
    bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
       player = GetComponent<Player> (); 
    }

    // Update is called once per frame
    void Update()
    {
      Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw ("Vertical"));
      player.SetDirectionInput (directionalInput);

      if (Input.GetKeyDown (KeyCode.Space))
      {
          player.OnJumpInputDown ();
      }  
      if (Input.GetKeyUp (KeyCode.Space))
      {
          player.OnJumpInputUp ();
      }

      if (directionalInput.x>0 && !facingRight)
      {
          Flip();
      }
      else if (directionalInput.x<0 && facingRight)
      {
          Flip();
      }
    }

    public void Flip () 
   {
       facingRight = !facingRight;

       transform.Rotate(0f, 180f, 0f);
   }
}
