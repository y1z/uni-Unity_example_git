using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	[SerializeField] public GameObject _minimum_marker = null;
	[SerializeField] public GameObject _maximum_marker = null;
	[SerializeField] private PlayerController _playerController = null;

	void Start()
	{
		Debug.Assert(_minimum_marker != null, "Needs to set the maximum limit to the level");
		Debug.Assert(_maximum_marker != null, "Needs to set the maximum limit to the level");
		_playerController = FindObjectOfType<PlayerController>();
		Debug.Assert(_playerController != null);
	}

	void Update()
	{
		Vector3 minimum = _minimum_marker.transform.position;
		if (_playerController.transform.position.x < minimum.x)
		{
			
			Vector3 temp = _playerController.transform.position;
			_playerController.transform.position = new Vector3(minimum.x, temp.y, temp.z);
			return;
		}
		
		Vector3 maximum = _maximum_marker.transform.position;
		if (_playerController.transform.position.x > maximum.x)
		{
			Vector3 temp = _playerController.transform.position;
			_playerController.transform.position = new Vector3(maximum.x, temp.y, temp.z);
			return;
		}
		
	}
}