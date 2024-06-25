using UnityEngine;
using UnityEngine.UI;
using VartraAbyss.Entity.Player;

namespace VartraAbyss.UI
{
	public class PlayerHealthAndBloodUI : MonoBehaviour
	{
		[SerializeField] private PlayerBehaviour m_player;
		[SerializeField] private GameObject m_healthUI;
		[SerializeField] private GameObject m_bloodUI;

		private void OnEnable()
		{
			EventManager.OnHealthChanged += UpdateHealthUI;
			EventManager.OnBloodChanged += UpdateBloodUI;
		}

		private void OnDisable()
		{
			EventManager.OnHealthChanged -= UpdateHealthUI;
			EventManager.OnBloodChanged -= UpdateBloodUI;
		}

		private void UpdateHealthUI()
		{
			Image image = m_healthUI.GetComponent<Image>();
			float amount = Mathf.Clamp01(m_player.Stat.Health / m_player.Stat.MaximumHealth);
			image.fillAmount = amount;
		}

		private void UpdateBloodUI()
		{
			Image image = m_bloodUI.GetComponent<Image>();
			float amount = Mathf.Clamp01(m_player.Stat.Blood / m_player.Stat.MaximumBlood);
			image.fillAmount = amount;
		}
	}
}
