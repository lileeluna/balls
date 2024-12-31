using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float currentX;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform player;

    private void Start()
    {
        Camera.main.aspect = (float)Screen.width / (float)Screen.height;
    }

    private void Update()
    {
        // Camera follows room
        // transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentX, transform.position.y, transform.position.z), ref velocity, speed);
        if (player != null)
        {
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
    }

    public void MoveRoom(Transform _newRoom)
    {
        currentX = _newRoom.position.x;
    }

}