using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VartraAbyss.Entity;

namespace VartraAbyss.Managers
{
	public class Global : MonoBehaviour
	{
		public delegate Actor ActorEvents(Actor self);
		public static ActorEvents onGetPlayerEvent;
		public static ActorEvents onGetEnemyEvent;



	}
}