using UnityEngine;
using System;
using System.Collections;

public class Item_TimeClock : Item
{

    #region Fields
    private bool _timeSlowed = false;
    [SerializeField] private AudioClip _slowMode;
    #endregion
    #region Unity Callbacks

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            Destroy(gameObject);
        if (_timeSlowed) 
            return;
        if (collision.gameObject.CompareTag("Player"))
        {
            _timeSlowed = true;
            StartCoroutine(SlowMode());
        }
    }
    #endregion


            




    private IEnumerator SlowMode()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        
        Time.timeScale = 0.5f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        AudioSource.PlayClipAtPoint(_slowMode, transform.position);

        yield return new WaitForSecondsRealtime(3f);

        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        Recolected();
    }
}



