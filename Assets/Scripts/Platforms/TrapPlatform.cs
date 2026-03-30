using UnityEngine;
using System;

public class TrapPlatform : MonoBehaviour
{




    #region Unity Callbacks
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Destroy(gameObject);
    }


    #endregion



}
