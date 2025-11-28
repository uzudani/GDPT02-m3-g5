using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float _speed;
    public Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (_rb == null)
        {
            _rb = gameObject.AddComponent<Rigidbody2D>();
            _rb.gravityScale = 0f;
        }
    }

    public void SetUp(Vector2 direction)
    {
        _rb.velocity = direction.normalized * _speed;
        //_rb.MovePosition(_rb.position + direction.normalized * (_speed * Time.deltaTime));
    }

    //Magari serve property?

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
