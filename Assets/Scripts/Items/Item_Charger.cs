using UnityEngine;
using System;

public class Item_Charger : Item
{
    #region Fields
    [SerializeField] private float _chargeAmount = 25f;
    [SerializeField] private AudioClip _chargeSound;
    #endregion

    #region Unity Callbacks

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            Destroy(gameObject);
        if (collision.gameObject.CompareTag("Player"))
        {
            Jetpack jetpack = collision.gameObject.GetComponent<Jetpack>();
            jetpack.AddEnergy(_chargeAmount);
            AudioSource.PlayClipAtPoint(_chargeSound, transform.position);
            Recolected();
        }
    }
    #endregion
}
        
        








