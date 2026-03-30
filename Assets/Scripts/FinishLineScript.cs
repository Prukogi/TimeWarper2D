using UnityEngine;
using System;

public class FinishLineScript : MonoBehaviour
{
    

    #region Fields
    [SerializeField] private Vector2 _startingPoint = new Vector2(6, 0);

    #endregion

    #region Unity Callbacks


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        { 
            collision.gameObject.GetComponent<Transform>();
            collision.gameObject.transform.position = _startingPoint;
        }
    }
    #endregion



}
