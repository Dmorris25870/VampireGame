using UnityEngine;
using UnityEngine.AI;

namespace VartraAbyss
{
	public class MouseMarker : MonoBehaviour
	{
		[SerializeField] private GameObject m_markerPrefab;
		[SerializeField] private GameObject m_currentMarker;
		[SerializeField] private LayerMask m_interactionLayers;
		[SerializeField] private bool m_debugMode;
		private Camera m_mainCamera;

		private void OnEnable()
		{
			EventManager.OnDebugModeCommand += ToggleDebugMode;
		}

		private void OnDisable()
		{
			EventManager.OnDebugModeCommand -= ToggleDebugMode;
		}

		void Start()
		{
			m_mainCamera = Camera.main;
		}

		void Update()
		{
			if(m_debugMode)
			{
				PlaceMarker();
			}
			else
			{
				Destroy(m_currentMarker);
			}
		}

		private void ToggleDebugMode()
		{
			m_debugMode = !m_debugMode;
		}

		void PlaceMarker()
		{
			Ray ray = m_mainCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if(Physics.Raycast(ray , out hit , Mathf.Infinity , m_interactionLayers))
			{
				NavMeshHit navMeshHit;

				if(NavMesh.SamplePosition(hit.point , out navMeshHit , 1.0f , NavMesh.AllAreas))
				{
					Vector3 targetPosition = navMeshHit.position;
					if(m_currentMarker == null)
					{
						m_currentMarker = Instantiate(m_markerPrefab , targetPosition , m_markerPrefab.transform.rotation);
					}
					else
					{
						m_currentMarker.transform.position = targetPosition;
					}
				}
			}
		}

		bool IsOnFloor(Vector3 position)
		{
			return Mathf.Abs(position.y) < 0.1f;
		}
	}
}
