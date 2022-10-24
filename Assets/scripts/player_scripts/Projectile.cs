using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Projectile : MonoBehaviour
{
	private const float _DEFAULT_SPEED = 10.0F;
	[SerializeField] private float speed = 0.0f;
  [SerializeField] bool _go_right = true;

  private PlayerController _player_ref = null;
  [SerializeField] private LayerMask _layerMask;
  [SerializeField] private CircleCollider2D _collider;

    // Start is called before the first frame update
    void Start()
    {
	     _player_ref = FindObjectOfType<PlayerController>();
	    if (speed < 0.0001f)
	    {
		    speed = _DEFAULT_SPEED;
	    }
	    _go_right = _player_ref.isGoingRight();
	    _layerMask = 1 << LayerMask.NameToLayer("Obstacle");
	    _collider = GetComponent<CircleCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
	    float direction = (_go_right) ? 1.0f : -1.0f;
      transform.Translate(speed * direction * Time.deltaTime ,.0f,.0f);
      Collider2D col = Physics2D.OverlapCircle(_collider.transform.position, _collider.radius * 0.5f, _layerMask);
      if ( col )
      {
	      col.gameObject.SetActive(false);
		    gameObject.SetActive(false);
		    print("I hit the thing");
		    Destroy(gameObject);
      }
      
    }

    public void set_direction(bool go_right)
    {
	    _go_right = go_right;
    }


}
