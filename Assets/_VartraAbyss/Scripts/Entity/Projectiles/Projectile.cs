using System.Collections;
using UnityEngine;
using VartraAbyss.Entity.Enemy;
using VartraAbyss.Entity.Boss;

namespace VartraAbyss.Entity
{
	public class Projectile : MonoBehaviour
	{
		[SerializeField] private Rigidbody m_rigidBody;
		[SerializeField] private Collider m_collider;
		[SerializeField] private float m_lifeTime;
		[field: SerializeField] public Vector3 Velocity { get; private set; }
		[field: SerializeField] public int DamageAmount { get; private set; }

		private void OnEnable()
		{
			StartCoroutine(DestroyAfterTime(m_lifeTime));
		}

		private void OnCollisionEnter(Collision collision)
		{
			// Check we haven't collided with ourselves
			if(collision.collider != m_collider)
			{
				// When this object hits another, check if it's an entity
				if(collision.gameObject.GetComponent<Actor>() != null)
				{
					Actor target = collision.gameObject.GetComponent<Actor>();
					if(target.tag == "Player")
					{
						target.Stat.ModifyHealth(-DamageAmount);
					}

					if(target.tag == "Enemy")
					{
						collision.gameObject.GetComponent<EnemyBehaviour>().TakeDamage(-DamageAmount);
					}
					if (target.tag == "Boss")
					{
						collision.gameObject.GetComponent<BossBehaviour>().TakeDamage(-DamageAmount);
					}
				}
			}

			Die();
		}

		public void SetVelocity(Vector3 direction , GameObject parent , float speed)
		{
			//Velocity = direction * parent * speed;
			Velocity = direction * -speed;
		}

		public void SetDamageAmount(int amount)
		{
			DamageAmount = amount;
		}

		private void Die()
		{
			Destroy(gameObject);
		}

		private IEnumerator DestroyAfterTime(float time)
		{
			// Wait for the specified time
			yield return new WaitForSeconds(time);

			// Destroy the projectile
			Die();
		}
	}
}
