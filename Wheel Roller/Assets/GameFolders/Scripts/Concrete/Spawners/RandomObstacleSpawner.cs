using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _obstacles;

    float _zPoint;
    int _randomObstacleIndex;
    public int _obstaclesDistance = 10;
    public int _obstacleNumber = 6;

    private void Start()
    {
        

        for (int i = 0; i < _obstacleNumber ; i++)
        {
            _randomObstacleIndex = Random.Range(0, _obstacles.Length);
            Instantiate(_obstacles[_randomObstacleIndex], new Vector3(0, 0,_zPoint), Quaternion.identity);
            _zPoint += _obstaclesDistance;
        }
    }
}
