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
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray , out RaycastHit hit , IgnorePlayerLayer))
			{
				if(IsWithinRange(self.Agent.transform.position , hit.point , self.CurrentAbility.Range))
				{
					self.Agent.Warp(hit.point);
					self.SetTarget(hit.point);
				}
			}
		}

		private bool IsWithinRange(Vector3 self , Vector3 warpLocation , float range)
		{
			float distance = Utilities.GetDistanceBetweenTwoVectors(self , warpLocation);

			if(distance <= range)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}