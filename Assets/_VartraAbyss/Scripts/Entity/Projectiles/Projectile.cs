using System.Collections;
using UnityEngine;
using VartraAbyss.Entity.Enemy;

namespace VartraAbyss.Entity
{
	public class Projectile : MonoBehaviour
	{
		[SerializeField] private Rigidbody m_rigidBody;
		[SerializeField] private Collider m_collider;
		[SerializeField] private float m_lifeTime;
		private GameObject spawner;
		[field: SerializeField] public Vector3 Velocity { get; private set; }
		[field: SerializeField] public int DamageAmount { get; private set; }

		private void OnEnable()
		{
			StartCoroutine(DestroyAfterTime(m_lifeTime));
		}

		private void FixedUpdate()
		{
			m_rigidBody.AddRelativeForce(Velocity * Time.fixedDeltaTime);
		}

		private void OnCollisionEnter(Collision collision)
		{
			// Check we haven't collided with ourselves
			if(collision.collider != m_collider && collision.collider != spawner.gameObject)
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
				}
			}

			Die();
		}

		public void SetVelocity(Vector3 direction , GameObject parent , float speed)
		{
			//if( parent < 1 && parent > -1 )
			//	parent = -1;
			spawner = parent;
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
