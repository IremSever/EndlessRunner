
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed=7;
    [SerializeField] float jumpForce;
    SpriteRenderer spRenderer;
    Animator anim;
    Rigidbody2D rg;
    int wholeNumber = 10;
    float decimalNumber = 4.5f;
    string text = "blabla";

    private bool jump = false;

    public bool isGround = true;
    public bool gameOver = false;
    private void Start()
    {
        spRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rg = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
        Jump();
    }
    private void Move()
    {
        var movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0) * Time.fixedDeltaTime * moveSpeed;
        if(movement != new Vector3 (0,0,0))
        {
            if (Input.GetAxis("Horizontal") < 0)
                spRenderer.flipX = true;
            else
                spRenderer.flipX = false;
            
            transform.position += movement;

            if (jump)
                anim.SetInteger("action", 1);
            else if (jump)
                anim.SetInteger("action", 0);
        }
    }
    private void Jump()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rg.AddForce(Vector3.up * 5, ForceMode2D.Impulse);
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 7, 0);
            anim.SetInteger("action", 2);
            isGround = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        { 
            jump = true;
            isGround = true;
        }
        else if (collision.tag == "Spike")
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(0);
            gameOver = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        { 
            jump = false;
        }
    }
}
