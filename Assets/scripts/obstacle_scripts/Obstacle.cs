using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Obstacle : MonoBehaviour
{
  public float speed = 1.0f;
  [SerializeField] private LayerMask _mask;
  [SerializeField] private BoxCollider2D _box;
    void Start()
    {
      _mask = 1 << LayerMask.NameToLayer("Arrow");
      _box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(Vector3.left *(speed * Time.deltaTime));

      Collider2D col = Physics2D.OverlapBox(transform.position, _box.size, 0.0f, _mask);
      if (col)
      {
        col.gameObject.SetActive(false);
        gameObject.SetActive(false);
      }
      
    }
}
