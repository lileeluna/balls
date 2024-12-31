using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDistance : MonoBehaviour
{
    private Vector2 lastPosition; // Stores the last position of the player
    private float totalDistanceMoved = 0f; // Total distance the player has moved

    void Start()
    {
        // Initialize the last position to the player's starting position
        lastPosition = transform.position;
    }

    void Update()
    {
        float distanceMoved = Vector2.Distance(transform.position, lastPosition);
        totalDistanceMoved += distanceMoved;
        lastPosition = transform.position;
    }

    public float GetTotalDistanceMoved()
    {
        return totalDistanceMoved;
    }
}
