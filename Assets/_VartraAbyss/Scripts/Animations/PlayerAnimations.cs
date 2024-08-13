using UnityEngine;
using UnityEngine.AI;

namespace VartraAbyss
{
	public class PlayerAnimations : MonoBehaviour
	{
		public Animator anim;
		public SpriteRenderer sr;
		public NavMeshAgent player;
		private Vector3 m_playerNotMoving;

		public float x;
		public float z;

		private void Awake()
		{
			m_playerNotMoving = new Vector3(0 , 0 , 0);
		}
		private void Update()
		{
			if(player.velocity == m_playerNotMoving)
			{
				StopWalkAnim();
			}
		}

		private void StopWalkAnim()
		{
			anim.Play("PlayerIdle");
		}
		public void PlayWalkAnim()
		{
			if(x < 0 & z < 0)
			{
				sr.flipX = false;
				anim.Play("PlayerWalkLeft");
			}
			else if(x > 0 & z > 0)
			{
				sr.flipX = true;
				anim.Play("PlayerWalkRight");
			}
			else if(x < 0 & z > 0)
			{
				anim.Play("PlayerWalkUp");
			}
			else if(x > 0 & z < 0)
			{
				anim.Play("PlayerWalkDown");
			}
		}
	}
}
