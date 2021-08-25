using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _playerSpeed;

    private  Rigidbody2D _rigidbody;

    private float _inputX;
    private float _move;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
     
        if (Input.GetKey(KeyCode.D))
        {
           
            _inputX = Input.GetAxis("Horizontal");
            _move = _playerSpeed * _inputX;
            Debug.Log(_move);
           _rigidbody.velocity = new Vector3(_move, 0);

        }

       else if (Input.GetKey(KeyCode.A))
        {

             _inputX = Input.GetAxis("Horizontal");
             float move = _playerSpeed * _inputX;
            _rigidbody.velocity = new Vector3(move, 0);

        }
    }
}
