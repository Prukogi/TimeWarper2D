using UnityEngine;
using System;
using Random = UnityEngine.Random;
using System.Collections;

public class Item_Glitch : Item
{
    #region Fields
    private bool _effectApplied = false;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip _drainSound;
    [SerializeField] private AudioClip _chargeSound;
    [SerializeField] private AudioClip _gravitySound;
    [SerializeField] private AudioClip _pushSound;


    
    #endregion







    #region Unity Callbacks

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            Destroy(gameObject);
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            Jetpack jetpack = collision.gameObject.GetComponent<Jetpack>();
            PlayerDamaged playerDamaged = collision.gameObject.GetComponent<PlayerDamaged>();
            int randomEffect = Random.Range(0, 4);
            switch (randomEffect)
            {
                case 0:
                    if (jetpack != null) 
                    { 
                        jetpack.AddEnergy(Random.Range(-20, -10));
                        
                        AudioSource.PlayClipAtPoint(_drainSound, transform.position);
                        playerDamaged?.TakeDamage();
                    }
                    break;
                case 1:
                    if (jetpack != null) 
                    { 
                        jetpack.AddEnergy(Random.Range(10, 30));
                        AudioSource.PlayClipAtPoint(_chargeSound, transform.position);
                    }
                    break;

                case 2:
                    if (playerRb != null)
                    {
                        AudioSource.PlayClipAtPoint(_gravitySound, transform.position);
                        if (_effectApplied) return;
                        playerDamaged?.TakeDamage();
                        StartCoroutine(GlitchGravity(playerRb));
                    }
                    return;
                case 3:
                    if (playerRb != null)
                    {
                        Vector2 dir = Random.insideUnitCircle.normalized;
                        playerRb.AddForce(dir * Random.Range(15f, 30f), ForceMode2D.Impulse);

                        AudioSource.PlayClipAtPoint(_pushSound, transform.position);
                        playerDamaged?.TakeDamage();
                    }
                    break;
            }
            Recolected();
        }
    }
                        




                        
                        
                    
                       
                    
                    
                        
                    

    #endregion
    IEnumerator GlitchGravity(Rigidbody2D playerRb)
    {
        _effectApplied = true;


        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        float originalGravity = playerRb.gravityScale;
        playerRb.gravityScale = Random.Range(0f, 5f);

        yield return new WaitForSecondsRealtime(3f);

        playerRb.gravityScale = originalGravity;

        _effectApplied = false;
        Recolected();
    }


}









