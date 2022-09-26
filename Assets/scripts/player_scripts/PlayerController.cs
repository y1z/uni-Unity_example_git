using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
  private const float DEFAULT_SPEED = 5.0f;
  private const float DEFAULT_JUMP_FORCE = 2.0f;

  public float runningSpeed = DEFAULT_SPEED;
  public float jumpForce = DEFAULT_JUMP_FORCE;
  public bool isGrounded = true;
  private bool _do_jump = false;
  private bool _is_dead = false;

  public Rigidbody2D rigidbody = null;
  public Animator animator = null;
  private SpriteRenderer spriteRenderer = null;
  private static readonly int SpeedID = Animator.StringToHash("speed");

  public float horizontalInput = 0.0f;

  private void Awake()
  {
    rigidbody = GetComponent<Rigidbody2D>();
    spriteRenderer = GetComponent<SpriteRenderer>();
    animator = GetComponent<Animator>();
    _do_jump = false;
    _is_dead = false;
    horizontalInput = 0.0f;
  }


  void Update()
  {
    //horizontalInput = Input.GetAxis("Horizontal");
    transform.Translate(Vector3.right * (horizontalInput * runningSpeed * Time.deltaTime));

    if (Input.GetButton("Jump") && isGrounded)
    {
      _do_jump = true;
    }
    flip_sprite(horizontalInput);
    animator.SetFloat(SpeedID, Mathf.Abs(horizontalInput));
  }

  private void FixedUpdate()
  {
    if (_do_jump)
    {
      this.rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
      isGrounded = false;
      _do_jump = false;
    }
  }
  
  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Ground"))
    {
      isGrounded = true;
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    
    if (other.gameObject.CompareTag("Obstacle"))
    {
      print("|I Just died f in the chat BOIZ");
      transform.position = new Vector3( 1337,1337,0);
      _is_dead = true;
    }
  }

  public bool isDead() => _is_dead;

  void flip_sprite(float direction)
  {
    if (direction > 0.001f)
    {
      spriteRenderer.flipX = false;
    }
    else if (direction < -0.001f)
    {
      spriteRenderer.flipX = true;
    }

  }
}