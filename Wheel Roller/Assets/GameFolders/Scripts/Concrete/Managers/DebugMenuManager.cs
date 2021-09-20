using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugMenuManager : MonoBehaviour
{
    public static DebugMenuManager Instance { get; private set; }


    [SerializeField] Slider _cameraSlider;
    [SerializeField] Slider _moveSpeedSlider;
    [SerializeField] Slider _obstacleSlider;


   
    public PlayerController _playerController;
    public RandomObstacleSpawner _randomObstacleSpawner;


    float _fieldOfView;
    float _cameraDistance;
    float _moveSpeedIndex;
    float _obstacleNumber;

    private void Awake()
    {
        SingletonThisGameObject();
       
       _obstacleSlider.value= PlayerPrefs.GetFloat("obstacleNumber", _obstacleNumber);
       _fieldOfView = PlayerPrefs.GetFloat("cameraDistance", _cameraDistance);
       _playerController._moveSpeed = PlayerPrefs.GetFloat("moveSpeed", _moveSpeedIndex);
    }
    

    private void Update()
    {
        Camera.main.fieldOfView = _fieldOfView;
    }
    public void SingletonThisGameObject()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SettingButtonClicked()
    {
        Time.timeScale = 0f;
       
    }
    public void DebugMenuExitButton()
    {
        Time.timeScale = 1f;
        CameraPosition();
        GameManager.Instance.lateOpen();
        
        
    }

    public void CameraPosition()
    {
        _fieldOfView = _cameraSlider.value;
        PlayerPrefs.SetFloat("cameraDistance", _fieldOfView);
        PlayerPrefs.Save();
    }
    
    public void MoveSpeed()
    {
        float speed;
        speed = _moveSpeedSlider.value;
        _playerController._moveSpeed = speed;
        PlayerPrefs.SetFloat("moveSpeed", speed);
        PlayerPrefs.Save();

    }
    public void ObstacleNumber()
    {
        float sliderValue;
        if(_obstacleSlider.value==5)
        {
            _randomObstacleSpawner._obstacleNumber = 5;
            _randomObstacleSpawner._obstaclesDistance = 12;
        }
        if (_obstacleSlider.value == 6)
        {
            _randomObstacleSpawner._obstacleNumber = 6;
            _randomObstacleSpawner._obstaclesDistance = 10;
        }
        if (_obstacleSlider.value == 7)
        {
            _randomObstacleSpawner._obstacleNumber = 7;
            _randomObstacleSpawner._obstaclesDistance =8;
        }
        sliderValue = _obstacleSlider.value;
        PlayerPrefs.SetFloat("obstacleNumber", sliderValue);
        PlayerPrefs.Save();
    }
}
