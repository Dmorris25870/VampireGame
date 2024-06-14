using UnityEngine;
using VartraAbyss.Managers;

namespace VartraAbyss.Abilities
{
	public class BloodProjectile : Ability, IAbility_Strategy
	{
		[SerializeField] private GameObject m_projectilePrefab;

		public void UseAbility()
		{
			GameObject projectileClone = Instantiate(m_projectilePrefab , (Vector3)( Global.OnGetPlayerEvent?.Invoke().transform.position ) , Quaternion.identity);
		}
	}
}