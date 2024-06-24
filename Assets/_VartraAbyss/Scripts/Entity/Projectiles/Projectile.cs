using UnityEngine;

namespace VartraAbyss.Entity
{
	public class Projectile : MonoBehaviour
	{
		[SerializeField] private Rigidbody m_rigidBody;
		[SerializeField] private Collider m_collider;
		[field: SerializeField] public Vector3 Velocity { get; private set; }
		[field: SerializeField] public int DamageAmount { get; private set; }

		private void FixedUpdate()
		{
			m_rigidBody.AddRelativeForce(Velocity * Time.fixedDeltaTime);
		}

		private void OnCollisionEnter(Collision collision)
		{
			// Check we haven't collided with ourselves
			if( collision.collider != m_collider )
			{
				// When this object hits another, check if it's an entity
				if( collision.gameObject.GetComponent<Actor>() != null )
				{
					Actor target = collision.gameObject.GetComponent<Actor>();
					target.Stat.ModifyHealth(-DamageAmount);
				}
			}

			Die();
		}

		public void SetVelocity(Vector3 direction)
		{
			Velocity = direction;
		}

		public void SetDamageAmount(int amount)
		{
			DamageAmount = amount;
		}

		private void Die()
		{
			Destroy(gameObject);
		}
	}
}
