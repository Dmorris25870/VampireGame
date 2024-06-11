﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VartraAbyss.Inventory
{
	public class CloseMenuScriptLITE : MonoBehaviour
	{
		public void CloseMenu()
		{
			transform.parent.GetComponent<RectTransform>().localScale = new Vector2(0, 0);
		}
	}
}