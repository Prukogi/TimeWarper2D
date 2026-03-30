using UnityEngine;
using System;

public class InputController : MonoBehaviour
{
    

    #region Fields
    [SerializeField] private PlayerMovement _player;


    #endregion

    #region Unity Callbacks



    void Update()
    {
        //Horizontal fly and movement
        if (Input.GetAxis("Horizontal") < 0)
            _player.MoveAir(PlayerMovement.Direction.Left);
        if (Input.GetAxis("Horizontal") > 0)
            _player.MoveAir(PlayerMovement.Direction.Right);

        //Vertical fly
        if (Input.GetAxis("Vertical") > 0) 
            _player.IsFlying = true;
        else
            _player.IsFlying = false;
        
        
    }



    #endregion

    

    
}











