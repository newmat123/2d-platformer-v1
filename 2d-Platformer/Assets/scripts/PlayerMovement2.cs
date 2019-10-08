using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{

    public float speed;             //Spillerens hastighed
    public float jumpForce;         //Spillerens hoppe styrke
    private float moveInput;        //Spillerens input

    private Rigidbody2D rb;

    private bool isGrounded;        //Checker om spilleren står på jorden
    public Transform groundCheck;   //Position som bruges til at tjekke om spilleren står på jorden
    public float checkRadius;       //Radius som bruges til at tjekke om spilleren står på jorden
    public LayerMask whatIsGround;  //Finder ud af hvilket lag der er jorden

    private int extraJumps;
    public int extraJumpsValue;     //Spillerens antal hop


    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Checker om spilleren står på jorden
        //Ud fra en cirkels position, radius, og om den rammer det rigtige lag
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Hoizontal1");                        //gør sådan at vi kan bruge A og D til at bevæge vores player
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);    //Får spilleren til at bevæge sig
    }

    private void Update()
    {
        if (isGrounded == true && rb.velocity.y == 0)   //Hvis spilleren står på jorden og ikke bevæger sig opad
        {
            extraJumps = extraJumpsValue; //Nulstilles antallet af hop
        }
        if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0)   //Hvis spilleren trykker på "W" og har flere hop
        {
            rb.velocity = Vector2.up * jumpForce;    //Sørger for at spilleren kan hoppe
            extraJumps--;                            //Trækker et jump fra
        }
    }
}
