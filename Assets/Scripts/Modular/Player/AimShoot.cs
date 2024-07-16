using AbstractClass;
using Enum;
using Projectile;
using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimShoot : AbsShoot
{
    private float aimTimer;

    public override void ResetShootValue(GunSO gunSO)
    {
        firingTimer = FireRateToTimeDelayShoot(gunSO.FireRate);
        aimTimer = 0;
    }

    public override void Shoot(ShootData shootData)
    {
        if (shootData.InitialDirection == Vector3.zero)
        {
            aimTimer = 0;
            return;
        }

        firingTimer += Time.fixedDeltaTime;
        aimTimer += Time.fixedDeltaTime;

        if (firingTimer >= FireRateToTimeDelayShoot(shootData.GunSO.FireRate))
        {
            if (aimTimer >= shootData.GunSO.AimDuration)
            {
                SpawnProjetile(shootData);
                Debug.Log("Aim shoot");
                firingTimer = 0;
                aimTimer = 0;
            }
        }
    }

    private void SpawnProjetile(ShootData shootData)
    {
        //Debug.Log("Shoot: " + gunSo.Prefab.name);
        //GameObject currentGun = gunObjectList[indexSelectGun];
        //Vector3 shootingPosition = currentGun.GetComponent<GunController>().ShootingPoition();
        //AbstractProjectileMovement projectile = Instantiate(gunSo.ProjectileSO.Prefab, shootingPosition, Quaternion.identity).GetComponent<AbstractProjectileMovement>();
        //projectile.Move(direction, currentGunSO.ProjectileSO.SpeedMove);
    }
}
