using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _enemySpeed = 5f;
    public float _health = 10000000f;
	private float _currentHealth;
    private Transform _nextpoint;
    private int pointIndex = 0;

	public static EnemyManager Manager;
    
	void Start ()
	{
	    _nextpoint = Pathfinding.points[0];
	    _currentHealth = _health;
	}
	
	void Update ()
	{
	    Vector3 direction = _nextpoint.position - transform.position;
        transform.Translate(direction.normalized * _enemySpeed * Time.deltaTime, Space.World);

	    if (Vector3.Distance(transform.position, _nextpoint.position) <= 0.1f)
	    {
	        GetNextPoint();
	    }
    }

    void GetNextPoint()
    {
        if (pointIndex >= Pathfinding.points.Length - 1)
        {
            Destroy(gameObject);
        }

        else
        {
            pointIndex++;
            _nextpoint = Pathfinding.points[pointIndex];
        }
    }

	public void TakeDamage (float amount)
	{
		_currentHealth -= amount;



		if (_currentHealth <= 0)
		{
			Debug.Log ("dsfsdewqweqeeff");
			Destroy(gameObject);
		}
	}
     
}
