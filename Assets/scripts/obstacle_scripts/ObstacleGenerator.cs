using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{

    private PlayerController _controller = null;
    public GameObject prefab = null;
    public GameObject spawn_position = null;
    public List< GameObject > obj_to_delete = null;
    public float time_until_next_spawn = 3.0f;
    public float time_passed = 0.0f;
    void Start()
    {
        _controller = FindObjectOfType<PlayerController>();
        Debug.Assert(prefab != null);
        Debug.Assert(_controller!= null);
        spawn_position = GameObject.FindGameObjectWithTag("Spawn Pos");

    }

    void Update()
    {
        time_passed += Time.deltaTime;

        if (!_controller.isDead())
        {
         
            if (time_passed >= time_until_next_spawn)
            {
                obj_to_delete.Add(Instantiate(prefab,spawn_position.transform.position, Quaternion.identity) );
                remove_obstacles_player_dodged();
                time_passed = 0;
            }   
        }
        
    }


    void remove_obstacles_player_dodged()
    {
        List<int> marked_to_delete = new List<int>();
        for (int i = 0; i < obj_to_delete.Count; i++)
        {
            if (_controller.transform.position.x > obj_to_delete[i].transform.position.x)
            {
               marked_to_delete.Add(i); 
            }
            
        }

        if (marked_to_delete.Count > 0)
        {
            foreach (var index in marked_to_delete)
            {
             Destroy(obj_to_delete[index] );
             obj_to_delete.RemoveAt(index);
            }
        }
        
    }
}
