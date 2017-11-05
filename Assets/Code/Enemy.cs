using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _enemySpeed = 5f;
    private int _health = 10;
    private int _currentHealth;
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
     
}
