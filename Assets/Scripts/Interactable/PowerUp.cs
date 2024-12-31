using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collider.gameObject.GetComponent<PlayerHealth>();
            playerHealth.setDamage(5);
            gameObject.SetActive(false);
        }
    }
}
