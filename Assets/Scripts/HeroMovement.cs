using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class HeroMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _speed = 10f;
    private float _jumpForce = 2f;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            transform.Translate(_speed * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
    }
}
