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
			Vector3 velocity = player.velocity.normalized; // Normalize the velocity

			if(velocity == m_playerNotMoving)
			{
				anim.SetBool("isMoving" , false);
				StopWalkAnim();
			}
			else
			{
				anim.SetBool("isMoving" , true);
				string direction = GetDirection(velocity);
				UpdateAnimation(direction);
			}
		}
		private void StopWalkAnim()
		{
			anim.Play("PlayerIdle");
		}

		string GetDirection(Vector3 velocity)
		{
			Vector3 roundedVelocity = new Vector3(Mathf.Round(velocity.x) , Mathf.Round(velocity.z));

			// Use a switch statement to map the rounded velocity to a direction
			switch(roundedVelocity)
			{
				case Vector3 direction when direction.x > 0 && direction.y > 0:
				return "Northeast";
				case Vector3 direction when direction.x < 0 && direction.y > 0:
				return "Northwest";
				case Vector3 direction when direction.x > 0 && direction.y < 0:
				return "Southeast";
				case Vector3 direction when direction.x < 0 && direction.y < 0:
				return "Southwest";
				case Vector3 direction when direction.x > 0 && Mathf.Approximately(direction.y , 0):
				return "East";
				case Vector3 direction when direction.x < 0 && Mathf.Approximately(direction.y , 0):
				return "West";
				case Vector3 direction when Mathf.Approximately(direction.x , 0) && direction.y > 0:
				return "North";
				case Vector3 direction when Mathf.Approximately(direction.x , 0) && direction.y < 0:
				return "South";
				default:
				return "Idle";
			}
		}

		void UpdateAnimation(string direction)
		{
			switch(direction)
			{
				case "Northeast":
				sr.flipX = true;
				anim.SetFloat("Horizontal" , 1f);
				anim.SetFloat("Vertical" , 1f);
				break;

				case "Northwest":
				sr.flipX = false;
				anim.SetFloat("Horizontal" , -1f);
				anim.SetFloat("Vertical" , 1f);
				break;

				case "Southeast":
				sr.flipX = true;
				anim.SetFloat("Horizontal" , 1f);
				anim.SetFloat("Vertical" , -1f);
				break;

				case "Southwest":
				sr.flipX = false;
				anim.SetFloat("Horizontal" , -1f);
				anim.SetFloat("Vertical" , -1f);
				break;

				case "East":
				sr.flipX = true;
				anim.SetFloat("Horizontal" , 1f);
				anim.SetFloat("Vertical" , 0f);
				break;

				case "West":
				sr.flipX = false;
				anim.SetFloat("Horizontal" , -1f);
				anim.SetFloat("Vertical" , 0f);
				break;

				case "North":
				anim.SetFloat("Horizontal" , 0f);
				anim.SetFloat("Vertical" , 1f);
				break;

				case "South":
				anim.SetFloat("Horizontal" , 0f);
				anim.SetFloat("Vertical" , -1f);
				break;

				default: // Idle case
				anim.SetFloat("Horizontal" , 0f);
				anim.SetFloat("Vertical" , 0f);
				break;
			}
		}
	}
}
