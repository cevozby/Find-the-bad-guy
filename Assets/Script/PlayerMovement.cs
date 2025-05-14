using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float speedMultiplier;
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
            playerRB.linearVelocity = new Vector2(moveInput.x, moveInput.y) * speed * speedMultiplier;
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
    }

    public void ChangeSpeedMultiplier(float value, float time)
    {
        StartCoroutine(ChangeSpeed(value, time));
    }

    IEnumerator ChangeSpeed(float value, float time)
    {
        Debug.Log("Speed Multiplier: " + value);
        speedMultiplier = value;
        yield return new WaitForSeconds(time);
        speedMultiplier = 1;
    }

}
