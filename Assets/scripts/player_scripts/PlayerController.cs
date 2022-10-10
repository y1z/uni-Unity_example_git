using System;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
  private const float DEFAULT_SPEED = 5.0f;
  private const float DEFAULT_JUMP_FORCE = 2.0f;

  public float runningSpeed = DEFAULT_SPEED;
  public float jumpForce = DEFAULT_JUMP_FORCE;
  private bool _do_jump = false;
  private bool _is_dead = false;

  public Rigidbody2D rigidbody = null;
  public Animator animator = null;
  private static readonly int SpeedID = Animator.StringToHash("speed");

  [SerializeField] private LayerMask _layerMask;

  [SerializeField] private Transform _groundCheck;
  public float horizontalInput = 0.0f;

  private void Awake()
  {
    rigidbody = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
    _do_jump = false;
    _is_dead = false;
    horizontalInput = 0.0f;
  }


  void Update()
  {
    horizontalInput = Input.GetAxis("Horizontal");
    transform.Translate(Vector3.right * (horizontalInput * runningSpeed * Time.deltaTime));

    if (Input.GetButtonDown("Jump") && isGround())
    {
      _do_jump = true;
    }
    flip_sprite(horizontalInput);
    animator.SetFloat(SpeedID, Mathf.Abs(horizontalInput));
  }

  private void FixedUpdate()
  {
    if (!_do_jump) return;
    this.rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    _do_jump = false;
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    
    if (other.gameObject.CompareTag("Obstacle"))
    {
      print("|I Just died f in the chat BOIZ");
      //transform.position = new Vector3( 1337,1337,0);
      _is_dead = true;
      gameObject.SetActive(false);
    }
  }

  public bool isDead() => _is_dead;

  void flip_sprite(float direction)
  {
    Vector2 localScale = transform.localScale;
    if (direction > float.Epsilon)
    {
      localScale.x = 1.0f;
      transform.localScale = localScale;
    }
    else if (direction < -float.Epsilon)
    {
      localScale.x = -1.0f;
      transform.localScale = localScale;
    }

  }


  bool isGround()
  {
    return Physics2D.OverlapCircle(_groundCheck.position, 0.2f,_layerMask);
  }
}