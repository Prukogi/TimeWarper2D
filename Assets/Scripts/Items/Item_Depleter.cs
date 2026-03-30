using UnityEngine;
using System;

public class Item_Depleter : Item
{
    #region Fields
    [SerializeField] private float _depleteAmount = -15f;
    [SerializeField] private AudioClip _depleteSound;
    #endregion

    #region Unity Callbacks

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            Destroy(gameObject);
        if (collision.gameObject.CompareTag("Player"))
        {
            Jetpack jetpack = collision.gameObject.GetComponent<Jetpack>();
            PlayerDamaged playerDamaged = collision.gameObject.GetComponent<PlayerDamaged>();
            jetpack.AddEnergy(_depleteAmount);
            playerDamaged?.TakeDamage();
            AudioSource.PlayClipAtPoint(_depleteSound, transform.position);
            Destroy(gameObject);
        }
    }
    #endregion



}
