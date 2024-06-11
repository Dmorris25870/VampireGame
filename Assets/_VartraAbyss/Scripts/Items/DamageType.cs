using UnityEngine;

namespace VartraAbyss.Items
{
	[CreateAssetMenu(fileName = "NewDamageType", menuName = "ScriptableObjects/Item/DamageType")]
	public class DamageType : ItemBase
	{
		public enum DamageTypes
		{
			Blunt,
			Piercing,
			Slashing,
			Blood
		}

		private DamageTypes m_damageTypes;

		public DamageTypes GetDamageType()
		{
			return m_damageTypes;
		}

		private void SetDamageType(DamageTypes value)
		{
			m_damageTypes = value;
		}
	}
}