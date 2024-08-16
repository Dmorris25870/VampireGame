using UnityEngine;
using VartraAbyss.Entity;

namespace VartraAbyss.Abilities
{
	public class Dash : Ability, IAbility_Strategy
	{
		[field: SerializeField] public LayerMask IgnorePlayerLayer { get; private set; }

		public void UseAbility(Actor self)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			// Use a raycast to find where the player clicked
			if(Physics.Raycast(ray , out RaycastHit hit , Mathf.Infinity , IgnorePlayerLayer))
			{
				Vector3 targetPoint = hit.point;
				float distance = Vector3.Distance(self.Agent.transform.position , targetPoint);

				// If the target point is within range, warp to it
				if(distance <= self.CurrentAbility.Range)
				{
					WarpToPoint(self , targetPoint);
				}
				// If the target point is out of range, warp to the maximum range in that direction
				else
				{
					Vector3 direction = (targetPoint - self.Agent.transform.position).normalized;
					Vector3 limitedPoint = self.Agent.transform.position + direction * self.CurrentAbility.Range;
					WarpToPoint(self , limitedPoint);
				}
			}
		}

		private void WarpToPoint(Actor self , Vector3 point)
		{
			if(self.Agent.Warp(point))
			{
				self.SetTarget(point);
			}
			else
			{
				Debug.LogWarning("Warp failed. Check if the point is valid on the NavMesh.");
			}
		}
	}
}