using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject _player;

    private Vector3 _offset;

	void Start()
	{
		_offset = transform.position - _player.transform.position;
	}
	void LateUpdate()
	{
		transform.position = new Vector3(transform.position.x, _player.transform.position.y + _offset.y, _player.transform.position.z + _offset.z);
	}
}
