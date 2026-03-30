using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    

    #region Fields
    [SerializeField] private PlayerMovement _player;
	private Animator _anim;

  

    
    #endregion

    #region Unity Callbacks
    private void Awake()
    {
        
        _anim = GetComponent<Animator>();
    }

   
    void Update()
    {
        _anim.SetFloat("VerticalVelocity", _player.GetComponent<Rigidbody2D>().linearVelocity.y);
        _anim.SetBool("IsGrounded", _player.IsGrounded);
        _anim.SetBool("IsRunning", Mathf.Abs(_player.GetComponent<Rigidbody2D>().linearVelocityX) > 0.1f);
        _anim.SetBool("Flying", _player.IsFlying);
    }
        

        
	#endregion

	
   
}
