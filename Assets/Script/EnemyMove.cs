using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMove : MonoBehaviour
{
    public float startSpeed = 10f;
    public float speed = 10.0f;

    public float starthealth = 100;
    public float health;
    public int value = 50;
    
    private bool IsDead = false;
    [Header("Unity")]
    public Image healthBar;

    void Start()
    {
        speed = startSpeed;
        health = starthealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health/starthealth;
        if(health <= 0 && !IsDead)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        IsDead = true;
        PlayerStarts.Money += value;

        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
    // Update is called once per frame
   
}
