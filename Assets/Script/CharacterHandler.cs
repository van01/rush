using UnityEngine;
using System.Collections;

public class CharacterHandler : MonoBehaviour {
	public GameObject weaponR;
	public GameObject weaponL;

	public Sprite[] weaponRSprite;
	public Sprite[] weaponLSprite;

	public int weponRNumber;
	public int weponLNumber;

	private Transform weaponRPosition;
	private Transform weaponLPosition;

	private SpriteRenderer useWeaponR;
	private SpriteRenderer useWeaponL;

	void Start(){
		useWeaponR = weaponR.GetComponentInChildren<SpriteRenderer>();
		useWeaponL = weaponL.GetComponentInChildren<SpriteRenderer>();

		UseWeaponInialize();
	}

	void UseWeaponInialize(){
		if (weaponRSprite.Length == 0){
			weaponR.SetActive(false);
			print ("Null WeaponR");
		}
		else{
			useWeaponR.sprite = weaponRSprite[weponRNumber];
		}
		if (weaponLSprite.Length == 0){
			weaponL.SetActive(false);
			print ("Null WeaponL");
		}
		else{
			useWeaponL.sprite = weaponLSprite[weponLNumber];
		}
	}
}
