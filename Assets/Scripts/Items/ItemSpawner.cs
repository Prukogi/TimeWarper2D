using UnityEngine;
using System;
using NUnit.Framework;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class ItemSpawner : MonoBehaviour
{
	#region Properties
	#endregion

	#region Fields
	[SerializeField] private float _minSpawnTime=1f;
	[SerializeField] private float _maxSpawnTime=5f;
	[SerializeField] private List<Item> _spawnList;
	private float _cronoTime = 0;
    private float _nextSpawnTime;
    #endregion

    #region Unity Callbacks
    // Start is called before the first frame update
    void Start()
    {
		ResetTime();
    }


    // Update is called once per frame
    void Update()
    {
		_cronoTime += Time.deltaTime;
        if (_cronoTime > _nextSpawnTime)
        {
            Spawnitem();
            ResetTime();
        }
        
    }

    
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void ResetTime()
    {
        _cronoTime = 0;
        _nextSpawnTime = Random.Range(_minSpawnTime, _maxSpawnTime);
    }
    private void Spawnitem()
    {
        //Randomly select an item from spawn list.
        int index = Random.Range(0, _spawnList.Count);
        //Randomly select an x position for the item to spawn.
        float xPos = Random.Range(-7f,10f);
        Vector2 itemPosition = new Vector2(xPos, transform.position.y);
        //Spawn the item
        Item newItem = Instantiate(_spawnList[index], itemPosition, Quaternion.identity);

        //Add a random rotation to the item.
        float torqueForce = Random.Range(-70F, 70F);
        newItem.GetComponent<Rigidbody2D>().AddTorque(torqueForce);

        //Dificulty progression.
        if(_maxSpawnTime > _minSpawnTime)
        _maxSpawnTime -= 0.1f;
    }
    #endregion

}
