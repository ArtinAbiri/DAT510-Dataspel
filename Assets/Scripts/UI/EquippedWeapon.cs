using System;
using Player;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Weapons;

namespace UI
{
    public class EquippedWeapon: MonoBehaviour
    {
        [SerializeField] private PlayerWeaponManager _weaponManager;
        private SpriteRenderer uiWepSpriteRenderer;
        private void Awake()
        {
            uiWepSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            uiWepSpriteRenderer.sprite = _weaponManager.CurrentWeapon.sprite;
        }
        
    }
}