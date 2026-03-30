using UnityEngine;
using System;
using Random = UnityEngine.Random;


public class PlayerSound : MonoBehaviour
{


    #region Fields
    [Header("Audio Sources")]
    [SerializeField] private AudioSource _footstepsSource;
    [SerializeField] private AudioSource _jetpackSource;
    [SerializeField] private AudioSource _sfxSource;
    [SerializeField] private AudioSource _jetpackHitSource;
    [SerializeField] private AudioSource _enemyHitSource;

    [Header("Enemy")]
    [SerializeField] private AudioClip _enemyHitClip;

    [Header("Jetpack")]
    [SerializeField] private AudioClip _jetpackClip;
    [SerializeField] private AudioClip _hitClip;
    [SerializeField] private bool _jetpackActive;
    
    [Header("Footsteps")]
    [SerializeField] private AudioClip _footstepClip;
    [SerializeField] private Vector2 _footstepPitchRange = new Vector2(0.9f, 1.1f);
    [Header("Falling")]
    [SerializeField] private AudioClip _fallClip;


    #endregion
    private void Awake()
    {
        GetComponent<AudioSource>();
    }


    #region Public Methods
    public void PlayFootstep()
    {
        _footstepsSource.PlayOneShot(_footstepClip);
        _footstepsSource.pitch = Random.Range(_footstepPitchRange.x, _footstepPitchRange.y);
    }


    public void SetJetpackActive(bool isActive)
    {
        if (isActive == _jetpackActive) return;

        _jetpackActive = isActive;

        if (isActive)
        {
            _jetpackSource.clip = _jetpackClip;
            _jetpackSource.loop = true;
            _jetpackSource.Play();
        }
        else
        {
            _jetpackSource.Stop();
        }
    }


    public void JetpackHit() 
    {
        _jetpackHitSource.clip = _hitClip;
        _jetpackHitSource.PlayOneShot(_hitClip);
    }

    public void EnemyHit() 
    {
        _enemyHitSource.clip = _enemyHitClip;
        _enemyHitSource.PlayOneShot(_enemyHitClip);
    }


    public void PlayFallIfNeeded(bool isGrounded, float velocityY)
    {

        if (isGrounded && velocityY < -10f)
        {

            float volume = Mathf.InverseLerp(-5f, -20f, velocityY);
            _sfxSource.PlayOneShot(_fallClip, volume);
        }
    }
    #endregion



}
