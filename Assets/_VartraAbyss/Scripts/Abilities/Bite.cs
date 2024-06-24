using UnityEngine;
using VartraAbyss.Entity;

namespace VartraAbyss.Abilities
{
	public class Bite : Ability, IAbility_Strategy
	{
		public void UseAbility(Actor self)
		{
			Debug.Log("Bite has been used.");
		}
	}
}