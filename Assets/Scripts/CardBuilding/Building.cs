using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Building : MonoBehaviour
{
    [SerializeField] private Vector2 _buildingSize;
    public Renderer _renderer;
    public float health;

    public Vector2 BuildingSize { get => _buildingSize; set {; } }

    public void SetColor(bool isAvailableToBuild)
    {
        if (isAvailableToBuild)
            _renderer.material.color = Color.green;
        else
            _renderer.material.color = Color.red;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void ResetColor()
    {
        _renderer.material.color = Color.white;
    }
}