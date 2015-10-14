using UnityEngine;
using System.Collections;

public class CharacterWeaponHandler : MonoBehaviour {
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

    private BoxCollider2D weaponRCollider;
    private BoxCollider2D weaponLCollider;

    private bool backupWeaponRCollider;
    private bool backupWeaponLCollider;
	
	void Awake(){
		useWeaponR = weaponR.GetComponentInChildren<SpriteRenderer>();
		useWeaponL = weaponL.GetComponentInChildren<SpriteRenderer>();

        weaponRCollider = weaponR.GetComponent<BoxCollider2D>();
        weaponLCollider = weaponL.GetComponent<BoxCollider2D>();
		
		UseWeaponInialize();
	}
	
	public void UseWeaponInialize(){
		if (weaponRSprite.Length == 0 || weponRNumber == -1)
        {
			weaponR.SetActive(false);
            weaponRCollider.enabled = false;
            backupWeaponRCollider = false;
		}
		else{
			useWeaponR.sprite = weaponRSprite[weponRNumber];
            backupWeaponRCollider = true;
		}
		if (weaponLSprite.Length == 0 || weponLNumber == -1)
        {
			weaponL.SetActive(false);
            weaponLCollider.enabled = false;
            backupWeaponLCollider = false;
		}
		else{
			useWeaponL.sprite = weaponLSprite[weponLNumber];
            backupWeaponLCollider = true;
		}
	}

    public void WeaponColliderOff()
    {
        weaponRCollider.enabled = false;
        weaponLCollider.enabled = false;
    }

    public void WeaponColliderReset()
    {
        weaponRCollider.enabled = backupWeaponRCollider;
        weaponLCollider.enabled = backupWeaponLCollider;
    }
}
