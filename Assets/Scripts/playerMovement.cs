using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [Header("Values For Player")]
    //the most appropriate values follow 8 for velocity and 13 for force with 2.5 gravity scale in rb2D
    [SerializeField] private float velocity;
    [SerializeField] private float force;
    // [SerializeField] private GameObject lLeg;
    // [SerializeField] private GameObject rLeg;
    [HideInInspector] public bool isFacingRight;

    [Header("References")]
    [SerializeField] private LayerMask groundMask;

    private Rigidbody2D rb;
    private Animator animator;
    private BoxCollider2D boxCollide;

    //specify which direction player will turn

    private float moveInput;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>();
        boxCollide = GetComponent<BoxCollider2D>();

        // StartDirectionCheck();

    }

    private void Update()
    {
        jump();
        
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");


        // if (moveInput > 0 || moveInput < 0)
        // {
        //     TurnCheck();
        // }
        //Movement of player
        rb.velocity = new Vector2 (moveInput * velocity, rb.velocity.y);
        animator.SetBool("isWalk", moveInput != 0);


        
        flipObject();


    }

    private void jump()
    {
        animator.SetBool("isJump", !isGrounded());
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.velocity = force * Vector2.up;
            animator.SetTrigger("jump");
        }
    }


    //adjust the exact direction when we turn player 
    private void flipObject()
    {
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    // private void StartDirectionCheck()
    // {
    //     if (rLeg.transform.position.x > lLeg.transform.position.x)
    //     {
    //         isFacingRight = true;
    //     } else {
    //         isFacingRight = false;
    //     }

    // }

    private void TurnCheck() {
        if (UserInput.instance.moveInput.x > 0 && !isFacingRight)
        {
            Turn();
        }
        else if (UserInput.instance.moveInput.x < 0 && isFacingRight)
        {
            Turn();
        }

    }
    private void Turn()
    {
        if (isFacingRight)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            isFacingRight = !isFacingRight;
        }
        else {

            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            isFacingRight = !isFacingRight;
        }

    }

    //Use to create a box collide for player
    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollide.bounds.center, boxCollide.bounds.size, 0, Vector2.down, .1f, groundMask);
        return hit.collider != null;
    }
}
