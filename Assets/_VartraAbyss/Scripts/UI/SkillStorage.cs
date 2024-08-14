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
			Debug.Log("Dash unlocked event received.");
			UnlockAbility(3);
		}

		private void OnBloodProjectileUnlocked()
		{
			Debug.Log("Blood Projectile unlocked event received.");
			UnlockAbility(4);
		}

		private void OnBiteUnlocked()
		{
			Debug.Log("Bite unlocked event received.");
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
			Debug.Log($"Ability at index {index} has been unlocked and set active.");
		}
	}
}