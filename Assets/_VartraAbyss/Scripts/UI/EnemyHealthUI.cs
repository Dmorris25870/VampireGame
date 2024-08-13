using UnityEngine;
using UnityEngine.UI;
using VartraAbyss.Entity.Enemy;

namespace VartraAbyss
{
	public class EnemyHealthUI : MonoBehaviour
	{
		[SerializeField] private EnemyBehaviour m_enemy;
		[SerializeField] private GameObject m_healthUI;

		private void OnEnable()
		{
			EventManager.OnEnemyHealthChanged += UpdateHealthUI;
		}

		private void OnDisable()
		{
			EventManager.OnEnemyHealthChanged -= UpdateHealthUI;
		}

		private void UpdateHealthUI()
		{
			Image image = m_healthUI.GetComponent<Image>();
			float amount = Mathf.Clamp01(m_enemy.Stat.Health / m_enemy.Stat.MaximumHealth);
			image.fillAmount = amount;
		}
	}
}
