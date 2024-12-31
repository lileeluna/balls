using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class BossDoor : MonoBehaviour
{
    public AudioSource musicSource;
    public GameObject boss;
    public Transform spawnPoint;
    private Rigidbody2D rb;
    private bool bossSpawned = false;
    [SerializeField] private GameObject wall;

    private void Start()
    {
        gameObject.SetActive(true);
        wall.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && !bossSpawned)
        {
            Instantiate(boss, spawnPoint.position, spawnPoint.rotation);
            bossSpawned = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            wall.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void bossDead()
    {
        wall.SetActive(false);
        gameObject.SetActive(true);
    }
}