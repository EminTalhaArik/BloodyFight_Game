using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D myRigidbody;
    Animator myAnimator;

    //Hareket Etmek
    public string horizontalData;
    public float speed;
    float moveInput;

    //Zıplamak
    int jumpCount;
    public float jumpPower;
    public bool canJump;
    public bool player1;


    //Zemin Kontrol
    [SerializeField]
    GameObject overlapPoint;
    [SerializeField]
    float overlapRadius;
    [SerializeField]
    LayerMask overlapLayer;

    public bool faceRight;

    AudioSource jumpSound;

    void Start()
    {
        faceRight = true;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        jumpSound = GetComponent<AudioSource>();
    }

    void Update()
    {

        if (player1)
        {
            JumpPlayer1();
        }
        else
        {
            JumpPlayer2();
        }
        
    }

    private void FixedUpdate()
    {   
        Move();  
    }


    //Hareket Fonksiyonu
    void Move()
    {
        moveInput = Input.GetAxisRaw(horizontalData);

        if (moveInput < 0)
        {
            faceRight = false;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (moveInput > 0)
        {
            faceRight = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        myAnimator.SetFloat("karakterHizi", Mathf.Abs(moveInput));
        myRigidbody.velocity = new Vector2(speed * moveInput, myRigidbody.velocity.y);
    }


    //Zıplama Fonksiyonu
    void JumpPlayer1()
    {
        LayerControl();

        if (canJump && Input.GetKeyDown(KeyCode.E) || jumpCount < 1 && Input.GetKeyDown(KeyCode.E))
        {
            myAnimator.SetBool("isJump", true);
            myRigidbody.AddForce(new Vector2(0f, jumpPower));
            jumpSound.Play();

            jumpCount++;

        }
    }
    
    void JumpPlayer2()
    {
        LayerControl();

        if (canJump && Input.GetKeyDown(KeyCode.L) || jumpCount < 1 && Input.GetKeyDown(KeyCode.L))
        {
            myAnimator.SetBool("isJump", true);
            myRigidbody.AddForce(new Vector2(0f, jumpPower));
            jumpSound.Play();

            jumpCount++;
        }
    }


    //Zemin Kontrol Fonksiyonu
    void LayerControl()
    {
        canJump = Physics2D.OverlapCircle(overlapPoint.transform.position, overlapRadius, overlapLayer);

        if (canJump)
        {
            jumpCount = 0;
            myAnimator.SetBool("isJump", false);
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
        }
        
    }
}
