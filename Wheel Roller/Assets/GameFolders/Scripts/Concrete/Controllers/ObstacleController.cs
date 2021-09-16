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
        if (_period == 0f) // so the cycles will not be divided by 0
        {
            return;
        }

        float cycles = Time.time / _period; // continually growing over time

        const float tau = Mathf.PI * 2; // constant value of 6.283...
        float rawSinWave = Mathf.Sin(cycles * tau); // Going from -1 to 1

        _movementFactor = (rawSinWave + 1f) / 2f; // recalculated to go from 0 to 1 so it's cleaner

        Vector3 offset = _movementVector * _movementFactor;
        transform.position = _startingPosition + offset;
    }
}
