using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private float speed = 10f;
    [Range(1, 10)]
    [SerializeField] private float lifeTime = 3f;

    public int damage = 2;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.takeDamage(damage);
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject)
        {
            Destroy(gameObject);
        }
    }
}