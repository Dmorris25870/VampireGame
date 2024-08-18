using System.Collections.Generic;
using UnityEngine;

namespace VartraAbyss
{
	public class PlayerSwayInfluenceOnPlants : MonoBehaviour
	{
		public List<Material> swayMaterials = new(); // Assign the material with the shader
		public Transform player; // Reference to the player's transform

		void Update()
		{
			// Update the shader with the player's current position
			foreach(var item in swayMaterials)
			{
				item.SetVector("_PlayerPos" , player.position);
			}
		}
	}
}
