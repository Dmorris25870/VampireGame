using UnityEngine;

namespace VartraAbyss.Entity
{
	public class Projectile : MonoBehaviour
	{
		[SerializeField] private GameObject m_projectile;
		[SerializeField] private Rigidbody m_rigidBody;
		[SerializeField] private Collider m_collider;
		[SerializeField] private int m_damage;
		[SerializeField] private float m_projectileSpeed;
		[SerializeField] private Vector3 m_targetPosition;

		private void FixedUpdate()
		{
			// Add force to the rigid body, multiplied by a set speed and fixed delta time.
			m_rigidBody.AddForce(Vector3.forward * m_projectileSpeed * Time.fixedDeltaTime);
		}

		private void OnCollisionEnter(Collision collision)
		{
			// Check we haven't collided with ourselves
			if( collision.collider != m_collider )
			{
				// When this object hits another, check if it's an entity
				if( collision.gameObject.TryGetComponent(out Actor target) )
				{
					// If it is, deal damage
					target.Stat.Health -= m_damage;
				}
				// Then destroy itself
				Die();
			}
		}

		private void Die()
		{
			DestroyImmediate(gameObject);
		}
	}
}
