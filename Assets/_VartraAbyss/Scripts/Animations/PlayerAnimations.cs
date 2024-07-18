using System.Collections;
using System.Collections.Generic;
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
			m_playerNotMoving = new Vector3(0, 0, 0);
		}
		private void Update()
		{
			//Debug.Log("velocity: " + player.velocity);
			if(player.velocity == m_playerNotMoving )
			{
				StopWalkAnim();
			}
		}

		private void StopWalkAnim()
		{
			//Debug.Log("Idle");
			anim.Play("PlayerIdle");
		}
		public void PlayWalkAnim()
		{
			if(x < 0 & z < 0 )
			{
				Debug.Log("walk left");
				anim.Play("PlayerWalkLeft");
			}
			else if(x > 0 & z > 0 )
			{
				Debug.Log("walk right");
				anim.Play("PlayerWalkRight");
			}
			else if( x < 0 & z > 0 )
			{
				Debug.Log("walk up");
				anim.Play("PlayerWalkUp");
			}
			else if( x > 0 & z < 0 )
			{
				Debug.Log("walk down");
				anim.Play("PlayerWalkDown");
			}
		}
    }
}
