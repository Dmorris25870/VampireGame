using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VartraAbyss.Utility
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float m_currentTime;
		[SerializeField] private float m_targetTime;

        public float CurrentTime { get { return m_currentTime; } }
        public float TargetTime { get { return m_targetTime; } }

        public Timer(float targetTime)
        {
            m_targetTime = targetTime;
            m_currentTime = TargetTime;
        }

		private void FixedUpdate()
		{
			if(CurrentTime <= 0)
            {
                //DO THING
            }
            else
            {
                m_currentTime -= Time.fixedDeltaTime;
            }
		}

        public void ResetTimer()
        {
            m_currentTime = TargetTime;
        }

        public void SetTimer(float targetTime)
        {
            m_targetTime = targetTime;
        }
	}
}