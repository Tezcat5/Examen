using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rBody;

    public GroundSensor sensor;

    public SpriteRenderer render;

    public Animator anim;

    AudioSource source;

    public Vector3 newPosition = new Vector3 (58, 5, 0);

    public float movementSpeed = 5;
    public float jumpForce = 10;
    private float inputhorizontal;
    public bool jump = false;

    public AudioClip jumpsound;

    void Awake ()
{

    rBody = GetComponent<Rigidbody2D>();
    render = GetComponent<SpriteRenderer>();
    anim = GetComponent<Animator>();
    source = GetComponent<AudioSource>();
}

    void Start()
    {
        
    }

    void Update()
    {
        inputhorizontal = Input.GetAxis("Horizontal");

        

        if(Input.GetButtonDown("Jump") && sensor.isGrounded == true)
        {
            
                rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                anim.SetBool("IsJumping", true);
                source.PlayOneShot(jumpsound);
        }

        if (inputhorizontal < 0)
        {
            render.flipX = true;
            anim.SetBool("IsRunning", true);
        }
        else if(inputhorizontal > 0)
        {
            render.flipX = false;
            anim.SetBool("IsRunning", true);
        }
        else
        {
             anim.SetBool("IsRunning", false);
        }
    }

    void FixedUpdate()
    {
        rBody.velocity = new Vector2(inputhorizontal * movementSpeed, rBody.velocity.y);
    }
 
}
