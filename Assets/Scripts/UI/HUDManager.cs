using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HUDManager : MonoBehaviour
{
	public Text coinCounterText;
	public int coinCount;

	private float MaxHealth = 100f;
	private float PlayerHealth = 100f;
	public Slider HealthSlider;

	public Text ammoCounterText;
	public Text dashCounterText;
	public Text waveCounterText;

	 public SpawnManager spawnManager;

	void Start()
	{
		HealthSlider.value = 50f;
		coinCounterText.text = "Coins: " + coinCount;
	}
	

	public void AddCoin()
	{
		coinCount++;
		coinCounterText.text = "Coins: " + coinCount;
		spawnManager.coinCount = coinCount;
	}

	public void Heal(float HealAmount)
	{
		PlayerHealth += HealAmount;

		if (PlayerHealth > MaxHealth)
		{
			PlayerHealth = MaxHealth;
		}
		HealthSlider.value = PlayerHealth / MaxHealth;
	}

	public void UpdateAmmoText(int currentAmmo, int maxAmmo)
	{
		ammoCounterText.text = "Ammo: " + currentAmmo + " / " + maxAmmo;
	}

	public void UpdateDashText(int MaxDashes, int Dashes)
	{
		dashCounterText.text = "Dashes: " + Dashes + " / " + MaxDashes;
	}

	public void UpdateWaveText(int CurrentWave, int MaxWaves)
	{
		waveCounterText.text = "Wave: " + CurrentWave + " / " + MaxWaves;
	}

	public void TakeDamage(float damageAmount)
	{
		PlayerHealth -= damageAmount; 
		Debug.Log($"Taking {damageAmount} damage");
		if (PlayerHealth <= 0)
		{
			PlayerHealth = 0;
			LoadGameOver();
		}

		HealthSlider.value = PlayerHealth / MaxHealth;
	}

	public void LoadGameOver()
	{
		SceneManager.LoadScene("GameOver");
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}
}

