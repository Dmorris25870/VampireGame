using UnityEngine;
using VartraAbyss.Entity;

namespace VartraAbyss.Abilities
{
	public class BloodProjectile : Ability, IAbility_Strategy
	{
		[SerializeField] private GameObject m_projectilePrefab;
		[SerializeField] private float m_projectileSpeed;

		public void UseAbility(Actor self)
		{
			GameObject projectile = Instantiate(m_projectilePrefab ,
					self.GetComponentInChildren<Spawner>().transform.position ,
					self.GetComponentInChildren<Spawner>().transform.rotation);


			self.Stat.ModifyBlood(-AbilityData.bloodCost);

			projectile.transform.LookAt(self.Target);
			projectile.GetComponent<Projectile>().SetDamageAmount(Damage);
			projectile.GetComponent<Projectile>().SetVelocity(transform.forward , self.gameObject , m_projectileSpeed);
		}
	}
}