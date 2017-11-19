using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class EnemyManager : MonoBehaviour
{
	private const float SpawnTime = 3f; // Spawn every 3 seconds
	private const int MaxEnemyCount = 8; // Only 8 enemies allowed on screen at a time
	private static Object _enemyPrefab;
	private float _lastspawn;
	private Transform _holder;
    
	internal void Start ()
	{
	    _enemyPrefab = Resources.Load("Enemy");
		_holder = transform;
		Enemy.Manager = this;
	}
    
	internal void Update () {

        if (MenuManager.instance.WinLoseShowing)
        {
            return;
        }

		if ((Time.time - _lastspawn) < SpawnTime) return;
		_lastspawn = Time.time;
		Spawn();
	}

	private void Spawn () {
		if (_holder.childCount >= MaxEnemyCount) { return; }
		Vector3 pos = new Vector3 (0, 1, 0);
		Quaternion rotation = new Quaternion (-45, 0, 0, 0);
		GameObject tmpEnemy = (GameObject) Object.Instantiate(_enemyPrefab, pos, rotation, _holder);
		tmpEnemy.tag = "Enemy";
	}

}
	
