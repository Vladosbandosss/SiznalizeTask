using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int playerSpeed;

    private Rigidbody2D _rb;
    private float inputX;
    private float move;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
     
        if (Input.GetKey(KeyCode.D))
        {
            float inputX = Input.GetAxis("Horizontal");
            float move = playerSpeed * inputX;
           _rb.velocity = new Vector3(move, 0);
        }

       else if (Input.GetKey(KeyCode.A))
        {
             inputX = Input.GetAxis("Horizontal");
             float move = playerSpeed * inputX;
            _rb.velocity = new Vector3(move, 0);
        }
    }
}
