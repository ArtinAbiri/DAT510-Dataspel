﻿using System;
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
        }

        private void Update()
        {
            
        }

        public void ChangeWeapon(Weapon wep)
        {
            CurrentWeapon = wep;
            _playerMeleeAttack.weapon = CurrentWeapon;
            Debug.Log("change weapon to: " + wep);
        }
    }
}