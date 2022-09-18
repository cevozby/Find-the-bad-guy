using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    float horizontalDir, verticalDir;

    public static bool gameOver;

    Rigidbody2D playerRB;
    Animator playerAnim;
    SpriteRenderer playerSR;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        playerSR = GetComponent<SpriteRenderer>();
        gameOver = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gameOver)
        {
            CharacterMove();
        }
        
    }

    void CharacterMove()
    {
        horizontalDir = Input.GetAxisRaw("Horizontal");
        verticalDir = Input.GetAxisRaw("Vertical");

        if(horizontalDir != 0)
        {
            playerRB.velocity = new Vector2(horizontalDir * speed, 0);
            playerAnim.SetBool("IsMovement", true);
            playerAnim.SetFloat("Horizontal", horizontalDir);
            playerAnim.SetFloat("Vertical", verticalDir);
            if (horizontalDir < 0)
            {
                playerSR.flipX = true;
            }
            else
            {
                playerSR.flipX = false;
            }
        }
        else if(verticalDir != 0)
        {
            playerRB.velocity = new Vector2(0f, verticalDir * speed);
            playerAnim.SetBool("IsMovement", true);
            playerAnim.SetFloat("Horizontal", horizontalDir);
            playerAnim.SetFloat("Vertical", verticalDir);
        }
        if(horizontalDir == 0 && verticalDir == 0)
        {
            playerRB.velocity = Vector2.zero;
            playerAnim.SetBool("IsMovement", false);
        }
    }

}
