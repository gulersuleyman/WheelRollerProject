using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    [SerializeField] float _rotationSpeed = 5f;
    [SerializeField] GameObject _settingPanel;

    public ParticleSystem _explosionParticle;
    public GameObject _failPanel;
    public GameObject _gamePanel;
    public float _moveSpeed;
    public GameObject _wheel;
    public bool _cameraMovement = false;
    public bool _slotSceneActive = false;
    public bool _running;
   


    float _currentPositionOfFirstTouch;
    float _currentPositionOfPlayer;


   
    public CharacterAnimation _characterAnimation;


    Rigidbody _rigidbody;
    InputController _input;
   

    private void Awake()
    {        
        _characterAnimation = GetComponent<CharacterAnimation>();
        _rigidbody = GetComponent<Rigidbody>();
        _input = new InputController();

    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _settingPanel.gameObject.SetActive(false);
            _running = true;
            _characterAnimation.RunningAnimation(_running);
        }
        DragMouse();
    }

    private void FixedUpdate()
    {
        if(_running)
        {
            _rigidbody.velocity = (Vector3.forward * _moveSpeed * Time.deltaTime);
            _wheel.transform.Rotate(0,0, -1 * _rotationSpeed * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            _moveSpeed = 0f;
            _wheel.gameObject.SetActive(false);
            _explosionParticle.Play();
            _characterAnimation.FallingAnimation(true);
            _failPanel.gameObject.SetActive(true);
            _gamePanel.SetActive(false);
        }
        if (collision.CompareTag("Slot"))
        {
            Camera.main.transform.rotation = Quaternion.Euler(0, 90, 0);
            Camera.main.transform.position = new Vector3(29.85f, 7.25f, 42.7f);
            _moveSpeed = 0f;
            _cameraMovement = true;
            _slotSceneActive = true;

        }
    }

    private void DragMouse()
    {
        if (_running)
        {
            if (_input.FirstMouseClick)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0f, 10f));
                _currentPositionOfFirstTouch = mousePosition.x;
                _currentPositionOfPlayer = transform.position.x;
            }
            if (_input.MouseClick)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0f, 10f));
                float playerPosition = mousePosition.x - _currentPositionOfFirstTouch + _currentPositionOfPlayer;
                float playerPositionLimited = Mathf.Clamp(playerPosition, -2.3f, 2.3f);
                transform.position = new Vector3(playerPositionLimited, transform.position.y, transform.position.z);
            }
        }
    }
    
}
