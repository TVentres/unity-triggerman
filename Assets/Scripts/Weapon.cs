using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public float Damage;
    public int MaxAmmo;
    public int CurrentAmmo;
    public float FireRate;
    public float ReloadTime;
    public Transform BulletSpawn;
    public GameObject Projectile;
    public Text AmmoText;
    private float FireTimer = 0f;
    private bool Reloading;
	HUDManager hudManager;


    void Start()
    {
		CurrentAmmo = MaxAmmo;
		hudManager = FindObjectOfType<HUDManager>();
		UpdateAmmoText();
	}

    void Update()
    {
		FireTimer += Time.deltaTime;
        //Debug.Log(FireTimer);

        if (FireTimer > FireRate)
        {
            if (CurrentAmmo > 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Shoot();
                    FireTimer = 0f;

                }
            }
            else
            {
                StartCoroutine(Reload());
            }
        }

        if (Input.GetKey("r"))
        {
            StartCoroutine(Reload());
        }
    }

    void Shoot()
    {
		Instantiate(Projectile, BulletSpawn.position, BulletSpawn.rotation);
		CurrentAmmo = CurrentAmmo - 1;
		hudManager.UpdateAmmoText(CurrentAmmo, MaxAmmo);
	}

	IEnumerator Reload()
	{
        if (!Reloading)
        {
            Reloading = true;
			yield return new WaitForSeconds(ReloadTime);
			CurrentAmmo = MaxAmmo;
			hudManager.UpdateAmmoText(CurrentAmmo, MaxAmmo);
			Reloading = false;
		}
		
	}

    void UpdateAmmoText()
    {
		hudManager.UpdateAmmoText(CurrentAmmo, MaxAmmo);
	}
}
