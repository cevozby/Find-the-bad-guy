using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    float horizontalDir, verticalDir;

    Rigidbody2D playerRB;
    Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CharacterMove();
    }

    void CharacterMove()
    {
        horizontalDir = Input.GetAxisRaw("Horizontal");
        verticalDir = Input.GetAxisRaw("Vertical");

        if(horizontalDir != 0)
        {
            playerRB.velocity = new Vector2(horizontalDir * speed, 0);
        }
        if(verticalDir != 0)
        {
            playerRB.velocity = new Vector2(0f, verticalDir * speed);
        }
        if(horizontalDir != 0 && verticalDir != 0)
        {
            playerRB.velocity = new Vector2(horizontalDir, verticalDir).normalized * speed;
            Debug.Log(new Vector2(horizontalDir, verticalDir).normalized);
        }
        if(horizontalDir == 0 && verticalDir == 0)
        {
            playerRB.velocity = Vector2.zero;
        }
    }

}
