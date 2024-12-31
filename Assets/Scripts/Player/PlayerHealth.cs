using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerHealth : Actors
{
    public int dmg = 3;
    public bool isCollide;
    public HealthManager healthManager;
    void Start()
    {
        isCollide = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            Boss boss = collision.gameObject.GetComponent<Boss>();
            if (boss != null)
            {
                boss.takeDamage(dmg);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        isCollide = true; // Set to true when a collision starts
    }

    private void OnCollisionExit(Collision collision)
    {
        isCollide = false; // Set to false when collision ends
    }
    public bool isColliding()
    {
        return isCollide;
    }

    public void takeDamage(int dmg)
    {
        base.takeDamage(dmg);

        if (healthManager != null)
        {
            healthManager.lossHealth(dmg);
        }
    }

    public void setDamage(int add)
    {
        dmg += add;
    }

    public void Die()
    {
        base.Die();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Game over! You lose :(");
    }
}