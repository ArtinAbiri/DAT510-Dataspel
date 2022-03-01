using System;
using UnityEngine;
using UnityEngine.UI;
using Weapons;

namespace Player
{   
    
    public class PlayerWeaponManager : MonoBehaviour
    {
        [SerializeField] public Weapon CurrentWeapon;
        private PlayerMeleeAttack _playerMeleeAttack;
        private void Awake()
        {
            _playerMeleeAttack = gameObject.GetComponent<PlayerMeleeAttack>();
            _playerMeleeAttack.weapon = CurrentWeapon;
            if (CurrentWeapon.GetType() != typeof(Fists))
                _playerMeleeAttack.wepSprite.sprite = CurrentWeapon.sprite;
        }

        public void ChangeWeapon(Weapon wep)
        {
            CurrentWeapon = wep;
            _playerMeleeAttack.weapon = wep;
            _playerMeleeAttack.wepSprite.sprite = null;
            if (CurrentWeapon.GetType() != typeof(Fists))
                _playerMeleeAttack.wepSprite.sprite = wep.sprite;
            Debug.Log("change weapon to: " + wep);
        }
    }
}