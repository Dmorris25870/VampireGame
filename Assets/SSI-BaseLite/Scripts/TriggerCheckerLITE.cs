using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VartraAbyss.Inventory
{
	public class TriggerCheckerLITE : MonoBehaviour
	{
		public bool triggered;
		public bool triggeredInBag;
		public Transform bagTrig = null;
		public Image img;

		private void OnTriggerStay(Collider other)
		{
			if ( !other.transform.GetComponent<InventoryGridScriptLITE>() )
			{
				triggered = true;
			}
			else
			{
				triggeredInBag = true;
				if ( bagTrig == null )
				{
					bagTrig = other.transform;
				}
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if ( !other.transform.GetComponent<InventoryGridScriptLITE>() )
			{
				triggered = false;
			}
			else
			{
				triggeredInBag = false;
				bagTrig = null;
			}
		}
	}
}