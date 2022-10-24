using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ArrowWeapon : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    public Transform start_shot_point;
    public float arrow_force;
    
    void Start()
    {
    }

    void Update()
    {
        Vector2 arrow_pos = transform.position;
        Vector2 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimer_direction = mouse_pos - arrow_pos;
        transform.right = aimer_direction;

        if (Input.GetMouseButtonDown((int)MouseButton.LeftMouse))
        {
            shoot();
        }
        
    }

    void shoot()
    {
        GameObject go = Instantiate(arrow, start_shot_point);
        var body = go.GetComponent<Rigidbody2D>();
        body.AddForce(new Vector2(arrow_force,0.0f),ForceMode2D.Impulse );
    }
}
