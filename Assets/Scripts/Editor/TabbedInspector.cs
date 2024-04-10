using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using VartraAbyss.Entity;
using UnityEditor.TerrainTools;
using VartraAbyss.Entity.Player;
using VartraAbyss.Actions;
using AYellowpaper.SerializedCollections;
using AYellowpaper.SerializedCollections.Editor;

namespace VartraAbyss.Editor
{
	[CustomEditor(typeof(PlayerBehaviour))]
	public class TabbedInspector : UnityEditor.Editor
	{
		private string[] m_tabs = { "Stats" , "Actions" , "Abilities" , "Items" , "Components" };
		private int m_tabIndex = 0;

		public override void OnInspectorGUI()
		{
			EditorGUILayout.BeginVertical();
			m_tabIndex = GUILayout.Toolbar(m_tabIndex, m_tabs);
			EditorGUILayout.EndVertical();

			switch( m_tabIndex )
			{
				case 0:
				{
					StatsTab();
				}
				break;

				case 1:
				{
					ActionsTab();
				}
				break;

				case 2:
				{
					AbilitiesTab();
				}
				break;

				case 3:
				{
					ItemsTab();
				}
				break;

				case 5:
				{
					ComponentsTab();
				}
				break;

				default:
				break;
			}
		}

		private void StatsTab()
		{
			PlayerBehaviour m_player = (PlayerBehaviour)target;
			m_player.MaximumHealth = EditorGUILayout.IntField("Player Maximum Health" , m_player.MaximumHealth);
			m_player.Health = EditorGUILayout.IntField("Player Health", m_player.Health);
			m_player.MaximumBlood = EditorGUILayout.IntField("Player Maximum Blood" , m_player.MaximumBlood);
			m_player.Blood = EditorGUILayout.IntField("Player Blood" , m_player.Blood);
			m_player.MaximumMoveSpeed = EditorGUILayout.FloatField("Player Maximum Speed" , m_player.MaximumMoveSpeed);
			m_player.MoveSpeed = EditorGUILayout.FloatField("Player Speed" , m_player.MoveSpeed);
		}

		private void ActionsTab()
		{
			PlayerBehaviour m_player = (PlayerBehaviour)target;
			m_player.CurrentAction = (Action.ActionTypes)EditorGUILayout.EnumFlagsField("Current Action", m_player.CurrentAction);
		}

		private void AbilitiesTab()
		{
			PlayerBehaviour m_player = (PlayerBehaviour)target;
		}

		private void ItemsTab()
		{
			PlayerBehaviour m_player = (PlayerBehaviour)target;
		}

		private void ComponentsTab()
		{
			PlayerBehaviour m_player = (PlayerBehaviour)target;
		}

	}
}