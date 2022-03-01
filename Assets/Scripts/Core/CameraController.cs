using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private bool allowYMovement;

    [SerializeField] private float lowestY;
    // Update is called once per frame
    void Update()
    {
        if (allowYMovement)
        {
            transform.position = new Vector3(player.position.x, Mathf.Clamp(player.position.y, lowestY, 1000), transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);   
        }
    }
}
