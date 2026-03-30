using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class InGameController : MonoBehaviour
{    




	#region Unity Callbacks
	
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) 
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
	#endregion



   
}
