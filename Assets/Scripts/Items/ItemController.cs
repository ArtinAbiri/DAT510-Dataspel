using Drunk;
using Player;
using UnityEngine;
using UnityEngine.UI;
using Weapons;

public class ItemController : MonoBehaviour
{
    [SerializeField] private Text pickUpText;
    [SerializeField] private Transform player;
    [SerializeField] private Weapon _weapon;
    private bool pickUpAllowed;
    private bool pickedUp;
    private PlayerWeaponManager playerWeaponManager;
    private Collider2D other;

    private void Start()
    {
        pickUpText.gameObject.SetActive(false);
        playerWeaponManager = player.GetComponent<PlayerWeaponManager>();
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
            other = col;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!pickedUp && other.gameObject.tag == "Player")
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
            other = null;
        }
    }

    private void PickUpItem()
    {
        pickedUp = true;
        pickUpAllowed = false;
        pickUpText.gameObject.SetActive(false);
        if (_weapon != null)
        {
            playerWeaponManager.ChangeWeapon(_weapon);
        }
        other.transform.GetComponent<Drunkness>().Drink(1);
    }
}
