using VartraAbyss.Entity;

namespace VartraAbyss.Abilities
{
	public class Leap : Ability, IAbility_Strategy
	{
		public void UseAbility(Actor self)
		{
			UnityEngine.Debug.Log("Used Leap Ability");
		}
	}
}