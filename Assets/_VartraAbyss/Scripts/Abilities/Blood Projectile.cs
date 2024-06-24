using UnityEngine;
using VartraAbyss.Entity;

namespace VartraAbyss.Abilities
{
	public class BloodProjectile : Ability, IAbility_Strategy
	{
		[SerializeField] private GameObject m_projectilePrefab;
		[SerializeField] private int m_projectileSpeed;

		public void UseAbility(Actor self)
		{
			GameObject projectile = Instantiate(m_projectilePrefab ,
					self.GetComponentInChildren<Spawner>().transform.position ,
					self.GetComponentInChildren<Spawner>().transform.rotation);

			projectile.transform.LookAt(self.Target);
			projectile.GetComponent<Projectile>().SetDamageAmount(Damage);
			projectile.GetComponent<Projectile>().SetVelocity(GetDirectionFromMousePosition(self));
		}

		private Vector3 GetDirectionFromMousePosition(Actor self)
		{
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(TargetPosition);
			Vector3 direction = mousePos - self.GetComponentInChildren<Spawner>().transform.position;
			direction.Normalize();
			return direction *= m_projectileSpeed;
		}
	}
}