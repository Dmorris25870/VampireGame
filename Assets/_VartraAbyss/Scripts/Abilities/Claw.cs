using UnityEngine;
using VartraAbyss.Entity;

namespace VartraAbyss.Abilities
{
	public class Claw : Ability, IAbility_Strategy
	{
		public void UseAbility(Actor self)
		{
			Debug.Log("Claw has been used.");
		}
	}
}