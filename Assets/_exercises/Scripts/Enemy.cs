using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    private PlayerController player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        EnemyMovement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void EnemyMovement()
    {
        if (player != null)
        {
            Vector2 EnemyMovement = Vector2.MoveTowards(transform.position, player.transform.position, _speed * Time.deltaTime);
            transform.position = EnemyMovement;
        }
        //ShortCut
        //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, _speed * Time.deltaTime);
    }
}
