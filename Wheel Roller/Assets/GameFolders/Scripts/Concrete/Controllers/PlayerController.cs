using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] float _rotationSpeed = 5f;
    public GameObject _wheel;

    bool _running;
    float _currentPositionOfFirstTouch;
    float _currentPositionOfPlayer;

    CharacterAnimation _characterAnimation;
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
