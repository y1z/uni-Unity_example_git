using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)),RequireComponent(typeof(BoxCollider2D))]
public sealed class Arrow : MonoBehaviour
{
    private Rigidbody2D _rb;
    private BoxCollider2D _box;
    public LayerMask _mask;
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _mask =  1 << LayerMask.NameToLayer("Ground");
        _box = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        handle_collision();
    }

    private void FixedUpdate()
    {
        float angle = Mathf.Atan2(_rb.velocity.y, _rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, new  Vector3(0.0f,0.0f,1.0f) );
    }


    private void handle_collision()
    {
        
        float angle = 0.0f;
        Vector3 vector_angle = Vector3.zero;
        transform.rotation.ToAngleAxis(out angle, out vector_angle);
        //Physics2D.OverlapArea(_box.bounds.min, _box.bounds.max, _mask);
        if (!Physics2D.OverlapBox(_box.transform.position, _box.size, angle, _mask)) return;
        
        Destroy(gameObject);
    }
}
