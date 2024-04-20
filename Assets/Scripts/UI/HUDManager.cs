using UnityEngine;
using UnityEngine.UI; 


public class HUDManager : MonoBehaviour
{
	public Slider healthBar; 
	public Text ammoCountText;
	public Text goldCountText;
	public Text waveCountText;
	public Text dashCountText;

	void Start()
	{
		UpdateHealth(100); // Set initial health
		UpdateAmmo(30); // Set initial ammo
		UpdateDash(3);
		UpdateGold(0);
		UpdateWave(0);
	}
	// Call this method to update health display
	public void UpdateHealth(int newHealth)
	{
		healthBar.value = newHealth;
	}
	// Call this method to update ammo display
	public void UpdateAmmo(int newAmmo)
	{
		ammoCountText.text = "Ammo: " + newAmmo;
	}

	public void UpdateDash(int newDash)
	{
		dashCountText.text = "Dashes: " + newDash;
	}

	public void UpdateGold(int newGold)
	{
		goldCountText.text = "Gold: " + newGold;
	}

	public void UpdateWave(int newWave)
	{
		waveCountText.text = "Wave: " + newWave; 
	}
}
