using System.Collections;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour
{
    #region Properties
    public bool IsInvulnerable()
    {
        return _isInvulnerable;
    }
    #endregion
    #region Fields
    [Header("References")]
    [SerializeField] private SpriteRenderer _sprite;

    [Header("Blink Settings")]
    [SerializeField] private float _blinkDuration = 1.5f;
    [SerializeField] private float _blinkInterval = 0.1f;

    private bool _isInvulnerable = false;
    #endregion

    #region Public Methods
    public void TakeDamage()
    {
        if (_isInvulnerable) return;
        StartCoroutine(Blink());
    }

        


    #endregion
    
    private IEnumerator Blink()
    {
        _isInvulnerable = true;

        float timer = 0f;

        while (timer < _blinkDuration)
        {
            _sprite.enabled = !_sprite.enabled;

            yield return new WaitForSeconds(_blinkInterval);
            timer += _blinkInterval;
        }

        _sprite.enabled = true;
        _isInvulnerable = false;
    }

    
    
}
