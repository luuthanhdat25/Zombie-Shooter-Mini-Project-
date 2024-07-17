using AbstractClass;
using Enum;
using Manager;
using Projectile;
using ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Player
{
    public class TapHoldShoot : AbsShoot
    {
        public override void ResetShootValue(GunSO gunSO)
        {
            base.ResetShootValue(gunSO);
            firingTimer = 0;
        }

        public override void ShootHold(Vector3 initalDirection, Vector3 initalPosition)
        {
            firingTimer += Time.fixedDeltaTime;

            if(firingTimer >= FireRateToTimeDelayShoot(currentGunSO.FireRate))
            {
                SpawnProjetile(initalDirection, initalPosition);
                firingTimer = 0;
            }
        }

        public override void ShootRelease(Vector3 releasePosition, Vector3 initalPosition)
        {}

        private void SpawnProjetile(Vector3 initalDirection, Vector3 initalPosition)
        {
            Debug.Log("Shoot: " + currentGunSO.Prefab.name);
            GameObject newProjectile = Instantiate(currentGunSO.ProjectileSO.Prefab, initalPosition, Quaternion.identity);
            AbsController absController = newProjectile.GetComponent<AbsController>();
            if(absController == null)
            {
                Debug.LogError(currentGunSO.Prefab.name + " doesn't have controller!");
            }
            absController.AbsMovement.Move(initalDirection, currentGunSO.ProjectileSO.SpeedMove);
        }
    }
}

