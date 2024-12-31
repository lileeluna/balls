using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Actors : MonoBehaviour
{
    protected Rigidbody2D rb;
    public float hp;
    public virtual int maxHP => 100;
    public float speed;
    // Start is called before the first frame update
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hp = maxHP;
    }

    public virtual void takeDamage(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public virtual float getHealth()
    {
        return hp;
    }

    public virtual void setHealth(float add)
    {
        hp += add;
    }
}