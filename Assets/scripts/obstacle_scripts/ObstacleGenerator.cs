using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ObstacleGenerator : MonoBehaviour
{
    
    private const uint DEFAULT_MAX_SPAWN = 9;

    private PlayerController _controller = null;
    public GameObject prefab = null;
    public GameObject spawn_position = null;
    public List< GameObject > obj_to_delete = null;
    public float time_until_next_spawn = 3.0f;
    public float time_passed = 0.0f;
    [SerializeField] private float _distance_between_obstacles = 0.5f;
    [SerializeField] private uint _how_many_to_spawn = 3u;
    [SerializeField] private uint _how_much_to_increament_spawn_amount = 3;
    [SerializeField] private uint _max_spawn;



    void Start()
    {
        if (_max_spawn == 0)
        {
            _max_spawn = DEFAULT_MAX_SPAWN;
        }
        _controller = FindObjectOfType<PlayerController>();
        Debug.Assert(prefab != null);
        Debug.Assert(_controller!= null);
        spawn_position = GameObject.FindGameObjectWithTag("Spawn Pos");
    }

    void Update()
    {
        time_passed += Time.deltaTime;

        if (!_controller.isDead() && _how_many_to_spawn <= _max_spawn)
        {
         
            if (time_passed >= time_until_next_spawn)
            {
                for (uint i = 0; i < _how_many_to_spawn; ++i)
                {
                    obj_to_delete.Add(Instantiate(prefab,spawn_position.transform.position + Vector3.right * (_distance_between_obstacles * i), Quaternion.identity) );
                }
                
                remove_obstacles_player_dodged();
                _how_many_to_spawn += _how_much_to_increament_spawn_amount;
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
