﻿/*This class holds the instance variables for the 
 * characteristics for each weapon. This class is called by
 * the Fire class when mouse is clicked to shoot
 * 
 */

using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour{
	
	public GameObject currentWeapon;
	public int weaponDamage;
	//fireSpeed is time it takes in between fire (lower values mean faster fire rate)
	public float fireSpeed;
	public float bulletSpeed;
	public float reloadTime;
	public int ammo;
	public int maxAmmoCapacity;
	public float range;

	bool isAuto = false;
	bool reloading = false;
	float timeStartReload;


	// Update is called once per frame
	public void initWeaponInfo () {

		//gets the active weapon from the pickUpWeapon script
		pickUpWeapon weaponScript = GetComponent<pickUpWeapon> ();
		print (weaponScript.activeWeapon);
		currentWeapon = weaponScript.activeWeapon;


		//assigns the instance variables depending on the weapon
		if (currentWeapon != null) {
			switch (currentWeapon.name) {

			case "handgun":
				fireSpeed = 0.2f;
				reloadTime = 1.5f;
				isAuto = false;
				maxAmmoCapacity = 12;
				range = 40;
				weaponDamage = 12;
				bulletSpeed = 100;
				break;

			case "Rifle":
				fireSpeed = .07f;
				reloadTime = 2.0f;
				isAuto = true;
				maxAmmoCapacity = 25;
				range = 80;
				weaponDamage = 20;
				bulletSpeed = 200;
				break;
			}

			ammo = maxAmmoCapacity;


		}
	}


	void Update(){
		
		if (reloading) {
			if (Time.time - timeStartReload >= reloadTime) {
				reloading = false;
				ammo = maxAmmoCapacity;
			}
		}
	}

	public void reload(){
		reloading = true;
		timeStartReload = Time.time;
	}
	public bool hasAmmo(){
		if (ammo > 0)
			return true;
		else
			return false;
	}

	public bool isReloading(){
		if (reloading)
			return true;
		else
			return false;
	}

	public bool isAutomatic(){
		return isAuto;
	}




}
