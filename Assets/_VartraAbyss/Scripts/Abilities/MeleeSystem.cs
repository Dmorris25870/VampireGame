using UnityEngine;
using VartraAbyss.Entity;

namespace VartraAbyss.Abilities
{
	public class MeleeSystem : MonoBehaviour
	{
		[SerializeField] private Actor m_self;
		[field: SerializeField] public Actor Target { get; protected set; }

		private void Start()
		{
			m_self = GetComponentInParent<Actor>();
		}

		private void OnTriggerStay(Collider other)
		{
			if( other != gameObject.GetComponent<Collider>() )
			{
				if( other.gameObject.GetComponent<Actor>() != null && other.gameObject != m_self )
				{
					Actor target = other.gameObject.GetComponent<Actor>();
					Target = target;
				}
			}
		}

		private void OnTriggerExit(Collider other)
		{
			Target = null;
		}
	}
}