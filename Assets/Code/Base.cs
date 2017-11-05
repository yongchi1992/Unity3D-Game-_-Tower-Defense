using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    private float _baseHealth = 100;
    private float _currentHealth;
    public Image healthBar;

    void Start()
    {
        _currentHealth = _baseHealth;
    }

    void Damage(float amount)
    {
        _currentHealth -= amount;
        healthBar.fillAmount = _currentHealth / _baseHealth;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Enemy>())
        {
            Destroy(other.gameObject);
            Damage(10);
        }
    }
}
