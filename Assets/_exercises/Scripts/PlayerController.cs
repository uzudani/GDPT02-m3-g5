using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rb;
    float h;
    float v;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (_rb == null)
        {
            _rb = gameObject.AddComponent<Rigidbody2D>();
            _rb.gravityScale = 0f;
        }
    }
    private void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 PlayerDirection = new Vector2(h, v).normalized * (_speed * Time.fixedDeltaTime);
        _rb.MovePosition(_rb.position + PlayerDirection);
    }
}

