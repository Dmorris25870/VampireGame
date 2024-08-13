using UnityEngine;
using VartraAbyss.Entity;
using VartraAbyss.Utility;

namespace VartraAbyss.Abilities
{
	public class Leap : Ability, IAbility_Strategy
	{
		[field: SerializeField] public LayerMask IgnorePlayerLayer { get; private set; }

		public void UseAbility(Actor self)
		{
			if(IsWithinRange(self.Agent.transform.position , self.CurrentAbility.Range))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if(Physics.Raycast(ray , out RaycastHit hit , IgnorePlayerLayer))
				{
					self.Agent.Warp(hit.point);
					self.SetTarget(hit.point);
				}
			}
		}

		private bool IsWithinRange(Vector3 self , float range)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray , out RaycastHit hit , IgnorePlayerLayer))
			{
				float distance = Utilities.GetDistanceBetweenTwoVectors(self , hit.point);

				if(range >= distance)
				{
					return true;
				}
				else
				{
					return false;
				}
			}

			return false;
		}
	}
}