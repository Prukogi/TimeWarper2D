using UnityEngine;
using System;
using NUnit.Framework.Interfaces;


public class Enemy : MonoBehaviour
{


    #region Fields
    [Header("Enemy Patrol Settings")]
    [SerializeField] private float _movementSpeed = 3f;
    [SerializeField] private bool _isGoingRight = false;
    [SerializeField] private float _raycastDistance = 1f;
    [SerializeField] private LayerMask _groundLayer;

    
    [SerializeField] private Vector2 _respawnPoint;

    [SerializeField] private PlayerSound _audio;
    #endregion

    #region Unity Callbacks
    
    private void Start()
    {
        transform.localScale = new Vector3(_isGoingRight ? 4 : -4, 4, 4);
    }
    private void Update()
    {
        // Enemy patrol logic
        Vector3 direction = _isGoingRight ? Vector3.left : -Vector3.left;
        transform.Translate(direction * _movementSpeed * Time.deltaTime);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, _raycastDistance, _groundLayer);
        if (hit.collider != null)
        {
            _isGoingRight = !_isGoingRight;
            transform.localScale = new Vector3(_isGoingRight ? 4 : -4, 4, 4);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            _movementSpeed = 6f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _audio.EnemyHit();
            collision.gameObject.transform.position = _respawnPoint;
            _movementSpeed = 3f;
        }
    }


    #endregion

   

}






    







