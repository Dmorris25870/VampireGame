using UnityEngine;
using VartraAbyss.Entity;

namespace VartraAbyss.Abilities
{
	public class FelixWave : Ability, IAbility_Strategy
	{
		[SerializeField] private GameObject m_projectilePrefab;
		[SerializeField] private float m_projectileSpeed;

		public void UseAbility(Actor self)
		{
			SpawnProjectile(self);
			self.Stat.ModifyBlood(-AbilityData.bloodCost);
		}

		private void SpawnProjectile(Actor self)
		{
			Vector3 targetPosition = self.Target;
			targetPosition.y = 0f;

			Vector3 playerPosition = self.Agent.transform.position;
			Vector3 directionToTarget = (targetPosition - playerPosition).normalized;

			// Spawn position around the player
			Vector3 spawnPosition = playerPosition + directionToTarget * self.CurrentAbility.Range;

			// Instantiate the projectile
			GameObject projectile = Instantiate(m_projectilePrefab , spawnPosition , Quaternion.identity);

			// Calculate the projectile's initial velocity
			Rigidbody rigidBody = projectile.GetComponent<Rigidbody>();

			Vector3 playerVelocity = self.Agent.velocity;
			Vector3 projectileDirection = (targetPosition - spawnPosition).normalized;

			// Dot product to determine velocity inheritance
			float dotProduct = Vector3.Dot(playerVelocity.normalized , projectileDirection);
			if(dotProduct > 0) // Moving in the same direction
			{
				rigidBody.velocity = playerVelocity + projectileDirection * m_projectileSpeed;
			}
			else // Moving in opposite directions
			{
				rigidBody.velocity = projectileDirection * m_projectileSpeed;
			}
		}
	}
}