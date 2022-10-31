using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)),RequireComponent(typeof(BoxCollider2D))]
public sealed class Arrow : MonoBehaviour
{
    private Rigidbody2D _rb;
    private BoxCollider2D _box;
    public LayerMask _mask;
    [SerializeField] private bool _is_hit;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _mask = 0;
        _mask |= 1 << LayerMask.NameToLayer("Ground");
        _mask |= 1 << LayerMask.NameToLayer("Obstacle");
        _box = GetComponent<BoxCollider2D>();
        _is_hit = false;
    }
    private void Update()
    {
        handle_collision();
    }

    private void FixedUpdate()
    {
        if (!_is_hit)
        {
            
            float angle = Mathf.Atan2(_rb.velocity.y, _rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, new  Vector3(0.0f,0.0f,1.0f) );
        }
    }

    private void handle_collision()
    {
        float angle = 0.0f;
        Vector3 vector_angle = Vector3.zero;
        transform.rotation.ToAngleAxis(out angle, out vector_angle);
        if (!Physics2D.OverlapBox(_box.transform.position, _box.size, angle, _mask)) return;
        
        on_hit();
    }

    private void on_hit()
    {
        _is_hit = true;
        _rb.isKinematic = true;
        _rb.velocity = Vector2.zero;
        Destroy(gameObject);
    }
}
