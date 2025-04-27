using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] Vector2 moveInput;
    float horizontalDir, verticalDir;

    public static bool gameOver;

    Rigidbody2D playerRB;
    Animator playerAnim;
    SpriteRenderer playerSR;

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

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
        if(moveInput.magnitude > 0)
        {
            playerRB.linearVelocity = new Vector2(moveInput.x * speed, moveInput.y * speed);
            playerAnim.SetBool("IsMovement", true);
            playerAnim.SetFloat("Horizontal", moveInput.x);
            playerAnim.SetFloat("Vertical", moveInput.y);
            if (moveInput.x < 0)
            {
                playerSR.flipX = true;
            }
            else
            {
                playerSR.flipX = false;
            }
        }
        else
        {
            playerRB.linearVelocity = Vector2.zero;
            playerAnim.SetBool("IsMovement", false);
        }

        //horizontalDir = Input.GetAxisRaw("Horizontal");
        //verticalDir = Input.GetAxisRaw("Vertical");

        //if(horizontalDir != 0)
        //{
        //    playerRB.linearVelocity = new Vector2(horizontalDir * speed, 0);
        //    playerAnim.SetBool("IsMovement", true);
        //    playerAnim.SetFloat("Horizontal", horizontalDir);
        //    playerAnim.SetFloat("Vertical", verticalDir);
        //    if (horizontalDir < 0)
        //    {
        //        playerSR.flipX = true;
        //    }
        //    else
        //    {
        //        playerSR.flipX = false;
        //    }
        //}
        //else if(verticalDir != 0)
        //{
        //    playerRB.linearVelocity = new Vector2(0f, verticalDir * speed);
        //    playerAnim.SetBool("IsMovement", true);
        //    playerAnim.SetFloat("Horizontal", horizontalDir);
        //    playerAnim.SetFloat("Vertical", verticalDir);
        //}
        //if(horizontalDir == 0 && verticalDir == 0)
        //{
        //    playerRB.linearVelocity = Vector2.zero;
        //    playerAnim.SetBool("IsMovement", false);
        //}
    }

}
