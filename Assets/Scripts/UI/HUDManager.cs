using UnityEngine;
using UnityEngine.UI; 


public class HUDManager : MonoBehaviour
{
	public Text coinCounterText;
	private int coinCount = 0;

	public Text ammoCounterText;

	public Text dashCounterText;

	void Start()
	{
		coinCounterText.text = "Coins: " + coinCount;
	}


	void Update()
	{

	}

	public void AddCoin()
	{
		coinCount++;
		coinCounterText.text = "Coins: " + coinCount;
	}

	public void UpdateAmmoText(int currentAmmo, int maxAmmo)
	{
		ammoCounterText.text = "Ammo: " + currentAmmo + " / " + maxAmmo;
	}

	public void UpdateDashText(int MaxDashes, int Dashes)
	{
		dashCounterText.text = "Dashes: " + Dashes + " / " + MaxDashes;
	}

}
