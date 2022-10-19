using System;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;
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
	private bool _is_facing_right = true;

	public Rigidbody2D rigidbody = null;
	public Animator animator = null;
	private static readonly int SpeedID = Animator.StringToHash("speed");

	[SerializeField] private LayerMask _layerMask;
	[SerializeField] private Transform _groundCheck;
	public float horizontalInput = 0.0f;
	[SerializeField] private GameObject _projectile_check = null;
	[SerializeField] private SpriteRenderer _sprite_renderer = null;
	public Object projectile_prefab;

	private void Awake()
	{
		Transform trans = transform.Find("projectileCheck");
		if (trans != null)
		{
			_projectile_check = trans.gameObject;
		}

		Debug.Assert(projectile_prefab != null, "needs to assign projectile to the prefab");

		rigidbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		_sprite_renderer = GetComponent<SpriteRenderer>();
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

		if (Input.GetKeyDown("k"))
		{
			Instantiate(projectile_prefab, _projectile_check.transform.position, Quaternion.identity);
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
			
//	localScale.x = 1.0f;
//	transform.localScale = localScale;
			_sprite_renderer.flipX = false;
			_is_facing_right = true;
			_is_facing_right = !_sprite_renderer.flipX ;
		}
		else if (direction < -float.Epsilon)
		{
	//localScale.x = -1.0f;
	//transform.localScale = localScale;
			_sprite_renderer.flipX = true;
			_is_facing_right = !_sprite_renderer.flipX ;
		}
	}

	bool isGround()
	{
		return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _layerMask);
	}


	public bool isGoingRight()
	{
		return _is_facing_right;
	}
	
}