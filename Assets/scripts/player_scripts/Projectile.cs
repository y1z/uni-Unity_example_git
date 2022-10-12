using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	private const float _DEFAULT_SPEED = 10.0F;
	[SerializeField] private float speed = 0.0f;
  [SerializeField] bool _go_right = true;

  private PlayerController _player_ref = null;
  // Start is called before the first frame update
    void Start()
    {
	     _player_ref = FindObjectOfType<PlayerController>();
	    if (speed < 0.0001f)
	    {
		    speed = _DEFAULT_SPEED;
	    }
	    _go_right = _player_ref.isGoingRight();
    }
    // Update is called once per frame
    void Update()
    {
	    float direction = (_go_right) ? 1.0f : -1.0f;
      transform.Translate(speed * direction * Time.deltaTime ,.0f,.0f);
    }

    public void set_direction(bool go_right)
    {
	    _go_right = go_right;
    }
}
