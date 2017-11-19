using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
	private float SpawnTime = 4f; // Spawn every 3 seconds
	//private const int MaxEnemyCount = 8; // Only 8 enemies allowed on screen at a time
	public  int WaveNumber = 5;
	private const int enemyNumber = 3;
	private static Object _enemyPrefab;
	private float _lastspawn;
	private Transform _holder;
	private Color[] render = new Color[]{Color.black , Color.blue ,Color.gray , Color.green , Color.red};


	internal void Start ()
	{
		_enemyPrefab = Resources.Load("Enemy");
		_holder = transform;
		Enemy.Manager = this;
	}

	internal void Update () {
		if (WaveNumber < 0) {
			return;
		}

		if (MenuManager.instance.WinLoseShowing)
		{
			return;
		}
		SpawnTime = (float)(14 - 2 * WaveNumber);
		if ((Time.time - _lastspawn) < SpawnTime) return;
		_lastspawn = Time.time;
		StartCoroutine(Spawn(WaveNumber - 1));

	}

	IEnumerator Spawn (int index) {
		//if (_holder.childCount >= MaxEnemyCount) { return; }
		for (int i = 0; i < enemyNumber; i++) {
			SpawnEnemy (index);
			yield return new WaitForSeconds(0.5f);
		}
		WaveNumber--;
	}
	private void SpawnEnemy(int index){
		Vector3 pos = new Vector3 (0, 1, 0);
		Quaternion rotation = new Quaternion (-45, 0, 0, 0);
		GameObject enemyObject = (GameObject) Object.Instantiate(_enemyPrefab, pos, rotation, _holder);

		Renderer r = enemyObject.GetComponent<Renderer>();
		r.material.color = render [WaveNumber - 1];

		Enemy enemy = enemyObject.GetComponent<Enemy> ();
		enemy._health = (21 - WaveNumber) * 20;
		enemy.tag = "Enemy";

	}

}

