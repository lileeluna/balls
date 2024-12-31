using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            PlayerMovement playerMvmt = collider.gameObject.GetComponent<PlayerMovement>();
            playerMvmt.setDouble(true);
            gameObject.SetActive(false);
        }
    }
}
