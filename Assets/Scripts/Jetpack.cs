using UnityEngine;
using System;


public class Jetpack : MonoBehaviour
{
    

    #region Properties
    public float Energy
    {
        get
        {
            return _energy;
        }
        set
        {
            _energy = Mathf.Clamp(value, 0, _maxEnergy);
        }
    }
    
    public float EnergyFlyingRatio
    {
        get 
        {
            return _energyFlyingRatio;
        }
        set 
        { 
            _energyFlyingRatio = value; 
        }
    } 
        
        
    #endregion

    #region Fields							     
    
    [SerializeField] private float _energy;
    [SerializeField] private float _maxEnergy;
    [SerializeField] private float _energyFlyingRatio;
    [SerializeField] private float _energyRegenerationRatio;
    

    #endregion

    #region Unity Callbacks
    
    
    void Start()
    {
        Energy = _maxEnergy;
    }



    

    #endregion

    #region Public Methods


    public void Regenerate()
    {
        Energy += _energyRegenerationRatio * Time.deltaTime;
    }
    
    public void AddEnergy(float energy)
    {
        Energy += energy;
    }
    public void ConsumeEnergy() 
    {
        Energy -= _energyFlyingRatio;
    }


    #endregion

   
}
