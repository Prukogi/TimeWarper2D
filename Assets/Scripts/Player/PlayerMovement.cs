using System;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    #region Enums
    public enum Direction
    {
        Left,
        Right
    }
    #endregion
    #region Properties
    public bool IsFlying
    {
        get
        {
            return _isFlying;
        }
        set
        {
            _isFlying = value;
        }
    }

    public bool IsGrounded
    {
        get
        {
            return _isGrounded;
        }
        set
        {
            _isGrounded = value;
        }
    }


    #endregion

    #region Fields
    [Header("Jetpack Settings")]
    [SerializeField] private Jetpack _jetpack;
    [SerializeField] private float _horizontalForce;
    [SerializeField] private float _flyForce;
    [SerializeField] private float _maxFlySpeed = 8f;
    [SerializeField] private bool _isFlying;
    
    private Rigidbody2D _rb;

    [Header("Audio Settings")]
    [SerializeField] private PlayerSound _audio;
    [SerializeField] private bool _wasGrounded;

    [Header("Ground Check Settings")]
    [SerializeField] private bool _isGrounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    #endregion

    #region Unity Callbacks

    private void Awake()
    {
        //_audio = GetComponent<PlayerSound>();
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        
    }



    void Update()
    {
        CheckGround();

        if (!_wasGrounded && _isGrounded)
        {
            _audio.PlayFallIfNeeded(_isGrounded, _rb.linearVelocity.y);
        }
        _wasGrounded = _isGrounded;


        if (_isFlying)
        {
            _audio.SetJetpackActive(IsFlying);
            FlyUp();
        }
        else
            _audio.SetJetpackActive(IsFlying = false);

        if (_isGrounded && _rb.linearVelocity.x == 0)
            _jetpack.Regenerate();
    }
    #endregion

    #region Public Methods



    public void MoveAir(Direction direction)
    {

        if (_isFlying)
        {
            if (direction == Direction.Left)
            {
                transform.localScale = new Vector3(-2, 2, 2);
                _rb.linearVelocity = new Vector2(-_horizontalForce, _rb.linearVelocity.y);
            }
            else
            {
                transform.localScale = new Vector3(2, 2, 2);
                _rb.linearVelocity = new Vector2(_horizontalForce, _rb.linearVelocity.y);
            }
        }
        else
            MoveGround(direction);
    }
    public void FlyUp()
    {
        if (_isFlying && _jetpack.Energy > 0)
        {
            if (_rb.linearVelocityY < _maxFlySpeed)
            {
                
                _rb.AddForce(Vector2.up * _flyForce);
                _jetpack.Energy -= _jetpack.EnergyFlyingRatio;
            }
        }
    }
       
            




    public void MoveGround(Direction direction)
    {

        if (_isGrounded)
        {
            if (direction == Direction.Left)
            {
                transform.localScale = new Vector3(-2, 2, 2);
                _rb.linearVelocity = new Vector2(-_horizontalForce, _rb.linearVelocityY);
            }
            else
            {
                transform.localScale = new Vector3(2, 2, 2);
                _rb.linearVelocity = new Vector2(_horizontalForce, _rb.linearVelocityY);
            }
        }
    }

   
    public void PlayFootstep()
    {
        _audio.PlayFootstep();
    }




    #endregion

    #region Private Methods
    private void CheckGround()
    {
        if (Physics2D.Raycast(groundCheck.position, Vector2.down, groundDistance, groundLayer))
            _isGrounded = true;
        else
            _isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (_isFlying)
            _audio.JetpackHit();
    }

    #endregion
}





