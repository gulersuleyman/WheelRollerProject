using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    Vector3 _startingPosition;
    [SerializeField] Vector3 _movementVector;
    float _movementFactor;
    [SerializeField] float _period = 2f;

    void Start()
    {
        _startingPosition = transform.position;
    }

    void Update()
    {
        if (_period == 0f) 
        {
            return;
        }

        float cycles = Time.time / _period; 

        const float tau = Mathf.PI * 2; 
        float rawSinWave = Mathf.Sin(cycles * tau); 

        _movementFactor = (rawSinWave + 1f) / 2f; 

        Vector3 offset = _movementVector * _movementFactor;
        transform.position = _startingPosition + offset;
    }
}



