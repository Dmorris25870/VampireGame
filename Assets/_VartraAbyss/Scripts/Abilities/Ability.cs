using UnityEngine;
using VartraAbyss.Entity;
using VartraAbyss.Utility;

namespace VartraAbyss.Abilities
{
	public class Ability : MonoBehaviour
	{
		[field: SerializeField] public AbilitySO AbilityData { get; protected set; }
		[field: SerializeField] public string Name { get; protected set; }
		[field: SerializeField] public Sprite Icon { get; protected set; }
		[field: SerializeField] public AudioClip SoundEffect { get; protected set; }
		[field: SerializeField] public ParticleSystem VisualEffect { get; protected set; }
		[field: SerializeField] public int Damage { get; protected set; }
		[field: SerializeField] public int BloodCost { get; protected set; }
		[field: SerializeField] public float CoolDownTime { get; protected set; }
		[field: SerializeField] public float Range { get; protected set; }
		[field: SerializeField] public Vector3 SpawnPosition { get; protected set; }
		[field: SerializeField] public Vector3 TargetPosition { get; protected set; }
		[field: SerializeField] public Actor TargetActor { get; protected set; }
		[field: SerializeField] public Timer Timer { get; protected set; }

		public void SetTargetPosition(Vector3 targetPosition)
		{
			TargetPosition = targetPosition;
		}

		public void SetTargetActor(Actor attacker , Actor target)
		{
			TargetActor = target;
		}

		#region Ability Builder
		public class Builder<T> where T : Ability, new()
		{
			AbilitySO m_data;
			string m_name = "Default";
			Sprite m_icon;
			AudioClip m_audioClip;
			ParticleSystem m_particles;
			int m_damage = 1;
			int m_bloodCost = 1;
			float m_coolDownTime = 1;
			float m_range = 1;
			Vector3 m_spawnPosition = Vector3.zero;
			Timer m_timer;

			public Builder<T> SetAbilityData(AbilitySO data)
			{
				m_data = data;
				return this;
			}

			public Builder<T> SetName(string name)
			{
				m_name = name;
				return this;
			}

			public Builder<T> SetIcon(Sprite icon)
			{
				m_icon = icon;
				return this;
			}

			public Builder<T> SetAudio(AudioClip audioClip)
			{
				m_audioClip = audioClip;
				return this;
			}

			public Builder<T> SetVFX(ParticleSystem particle)
			{
				m_particles = particle;
				return this;
			}

			public Builder<T> SetDamage(int damage)
			{
				m_damage = damage;
				return this;
			}

			public Builder<T> SetBloodCost(int cost)
			{
				m_bloodCost = cost;
				return this;
			}

			public Builder<T> SetCoolDownTime(float time)
			{
				m_coolDownTime = time;
				return this;
			}

			public Builder<T> SetRange(float range)
			{
				m_range = range;
				return this;
			}

			public Builder<T> SetSpawnPosition(Vector3 position)
			{
				m_spawnPosition = position;
				return this;
			}

			public Builder<T> SetTimer(float time)
			{
				m_timer = new Timer(time);
				return this;
			}

			public T Build()
			{
				T ability = new GameObject(m_name).AddComponent<T>();
				ability.AbilityData = m_data;
				ability.Name = m_name;
				ability.Icon = m_icon;
				ability.SoundEffect = m_audioClip;
				ability.VisualEffect = m_particles;
				ability.Damage = m_damage;
				ability.BloodCost = m_bloodCost;
				ability.CoolDownTime = m_coolDownTime;
				ability.Range = m_range;
				ability.SpawnPosition = m_spawnPosition;
				ability.Timer = m_timer;
				return ability;
			}
		}
		#endregion
	}
}