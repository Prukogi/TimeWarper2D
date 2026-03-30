using UnityEngine;
using System;
using Unity.VisualScripting;

public class MovingPlatform : MonoBehaviour
{
    #region Fields


    
    [SerializeField] private float _movementSpeed = 3.0f;
    [SerializeField] private int _startingPoint;
    [SerializeField] private Transform[] _points;

    private int _i;


    #endregion

    #region Unity Callbacks
    private void Start()
    {
        transform.position = _points[_startingPoint].position;
    }


    private void Update()
    {
        if (Vector2.Distance(transform.position, _points[_i].position) < 0.02f) 
        {
            _i++;
            if(_i == _points.Length)
                _i = 0;
        }
        transform.position = Vector2.MoveTowards(transform.position, _points[_i].position, _movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.transform.SetParent(transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.transform.SetParent(null);
    }
    #endregion



}
