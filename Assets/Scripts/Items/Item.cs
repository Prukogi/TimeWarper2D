using UnityEngine;
using System;
using Random = System.Random;

public class Item : MonoBehaviour, IRecolectable
{
  

    #region Enums
    public enum ItemTypes
    {
        None,
        BatteryCharger,
        BatteryDepleter,
        Glitch,
        TimeClock,
       
    }

    #endregion
    #region Properties
    [field: SerializeField] public ItemTypes Type { get; set; }

    #endregion

    #region Fields
    [SerializeField] private GameObject _particles;

    #endregion

    





    #region Public Methods
    public virtual void Recolected()
    {
        Destroy(gameObject);
        CreateParticles();
    }

    #endregion

    private void CreateParticles()
    {
        Instantiate(_particles, transform.position, Quaternion.identity);
    }
    #region Private Methods
    #endregion


}