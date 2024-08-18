using UnityEngine;
using UnityEngine.UI;
using VartraAbyss.Entity.Boss;

namespace VartraAbyss
{
	public class BossHealthUI : MonoBehaviour
	{
		[SerializeField] private BossBehaviour bossBehaviour;
		[SerializeField] private GameObject healthUI;

		private void OnEnable()
		{
			EventManager.OnBossHealthChanged += UpdateHealthUI;
			EventManager.OnBossFight += EnableBossHealth;
			EventManager.OnBossFightClose += DisableBossHealth;
		}

		private void OnDisable()
		{
			EventManager.OnBossHealthChanged -= UpdateHealthUI;
			EventManager.OnBossFight -= EnableBossHealth;
			EventManager.OnBossFightClose -= DisableBossHealth;
		}

		private void EnableBossHealth()
        {
			healthUI.SetActive(true);
        }

		private void DisableBossHealth()
        {
			healthUI?.SetActive(false);
        }

		private void UpdateHealthUI()
		{
			Image image = healthUI.GetComponent<Image>();
			float amount = Mathf.Clamp01(bossBehaviour.Stat.Health / bossBehaviour.Stat.MaximumHealth);
			image.fillAmount = amount;
		}
	}
}
