using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;


/// <inheritdoc><cref></cref>
/// </inheritdoc>
/// <summary>
/// Manager class for spawning and tracking all of the game's asteroids
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class EnemyManager : MonoBehaviour
{
	private const float SpawnTime = 3f;
	private const int MaxAsteroidCount = 8;
	private static Object _asteroidPrefab;
	private float _lastspawn;
	private Transform _holder;

	// ReSharper disable once UnusedMember.Global
	internal void Start () {
		_asteroidPrefab = Resources.Load("Enemy");
		_holder = transform;
		Enemy.Manager = this;
	}

	// ReSharper disable once UnusedMember.Global
	internal void Update () {
		if ((Time.time - _lastspawn) < SpawnTime) return;
		_lastspawn = Time.time;
		Spawn();
	}

	private void Spawn () {
		if (_holder.childCount >= MaxAsteroidCount) { return; }
		Vector3 pos = new Vector3 (0, 1, 0);
		Quaternion rotation = new Quaternion ();
		GameObject tmpEnemy = (GameObject) Object.Instantiate(_asteroidPrefab, pos, rotation, _holder);
		tmpEnemy.tag = "Enemy";
	}

}
	
