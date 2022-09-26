using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class ScrollBackground : MonoBehaviour
{
  private Vector2 background_size;
  private Vector2 starting_pos;
  private float offsetx_from_starting_pos;
  private SpriteRenderer spriteRenderer = null;
  public float scroll_speed = 5.0f;

  private void Start()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
    background_size = spriteRenderer.bounds.size;
    starting_pos = transform.position;
    offsetx_from_starting_pos = 0.0f;
  }

  private void Update()
  {
    Vector2 current_pos = transform.position;
    transform.Translate( Vector2.left * (scroll_speed  * Time.deltaTime ));
    Vector2 new_pos = transform.position;
    offsetx_from_starting_pos += (current_pos - new_pos).x;

    if (Mathf.Abs(offsetx_from_starting_pos) >= background_size.x * .5f)
    {
      offsetx_from_starting_pos = 0.0f;
      transform.position = starting_pos;
    }
  }
}
