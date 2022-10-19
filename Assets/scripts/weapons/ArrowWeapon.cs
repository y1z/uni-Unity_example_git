using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowWeapon : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        Vector2 arrow_pos = transform.position;
        Vector2 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimer_direction = mouse_pos - arrow_pos;
        transform.right = aimer_direction;
    }
}
