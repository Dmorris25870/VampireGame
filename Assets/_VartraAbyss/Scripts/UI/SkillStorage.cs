using UnityEngine;

namespace VartraAbyss
{
	public class SkillStorage : Storage
	{
		private void Awake()
		{
			EventManager.OnDashAbilityUnlocked += OnDashUnlocked;
			EventManager.OnBloodProjectileAbilityUnlocked += OnBloodProjectileUnlocked;
			EventManager.OnBiteAbilityUnlocked += OnBiteUnlocked;
		}

		private void OnDestroy()
		{

			EventManager.OnDashAbilityUnlocked -= OnDashUnlocked;
			EventManager.OnBloodProjectileAbilityUnlocked -= OnBloodProjectileUnlocked;
			EventManager.OnBiteAbilityUnlocked -= OnBiteUnlocked;
		}

		private void OnDashUnlocked()
		{
			UnlockAbility(3);
		}

		private void OnBloodProjectileUnlocked()
		{
			UnlockAbility(4);
		}

		private void OnBiteUnlocked()
		{
			UnlockAbility(5);
		}

		private void UnlockAbility(int index)
		{
			if(slots == null)
			{
				Debug.LogError($"Slot array is either null.");
				return;
			}

			if(slots[index] == null)
			{
				Debug.LogError($"Slot at index {index} is null.");
				return;
			}

			slots[index].gameObject.SetActive(true);
		}
	}
}