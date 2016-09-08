using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    bool facingRight = true;
    public float maxSpeed = 10f;
    Animator anim;
    Rigidbody2D body;
    bool grounded = true;
    bool climb = false;
    bool doubleJump = true;
    bool duck = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public LayerMask whatIsLadder;
    public LayerMask whatIsKill;
    public float jumpForce = 300f;
	
    // Use this for initialization
	void Start () {
        body = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        	
	}


    void FixedUpdate(){
        climb = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsLadder);
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        onDie();

        anim.SetBool("Ground", grounded);
        if (!grounded || !climb) 
            anim.SetBool("Climb", climb);
        onClimb();
        onJump();
        onMove();
    }


    void Flip(){
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    void onClimb()
    {
        if (Input.GetAxis("Vertical") > 0) { 
            grounded = false;
            //body.gravityScale = 0;
        }
    }

    void onJump(){
        if (Input.GetButtonDown("Jump") && grounded && !climb){
            body.AddForce(new Vector2(0, jumpForce));
            doubleJump = true;
            grounded = false;
        } else if (Input.GetButtonDown("Jump") && doubleJump){
            body.AddForce(new Vector2(0, jumpForce));
            doubleJump = false;
            grounded = false;
        }
    }

    void onMove(){

        float move;

        if (climb){
            move = Input.GetAxis("Vertical");
            anim.SetFloat("VerticalSpeed", Mathf.Abs(move));
            body.velocity = new Vector2(body.velocity.x, move * maxSpeed);
        }
        
        //movimentar esquer e direita
        move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));

        if (!duck)
            body.velocity = new Vector2(move * maxSpeed, body.velocity.y);

        if (move > 0 && facingRight == false)
            Flip();
        if (move < 0 && facingRight == true)
            Flip();
        

    }


    void onDie() {
        //if (Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsKill))
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
