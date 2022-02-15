using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    [SerializeField] private Text pickUpText;
    [SerializeField] private Transform player;
    private bool pickUpAllowed;
    private bool pickedUp;

    private void Start()
    {
        pickUpText.gameObject.SetActive(false);
    }

    private void Update()
    {   
        // pick up items conditions
        if (pickedUp)
            gameObject.transform.position = new Vector3(player.position.x + 0.3f * player.localScale.x, player.position.y, player.position.z - 0.1f);
        else if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
            PickUpItem();
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!pickedUp && col.gameObject.tag == "Player")
        {
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!pickedUp && other.gameObject.tag == "Player")
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }

    private void PickUpItem()
    {
        pickedUp = true;
        pickUpAllowed = false;
        pickUpText.gameObject.SetActive(false);
    }
}
