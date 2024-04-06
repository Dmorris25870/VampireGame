using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VartraAbyss.Utility
{
    /// <summary>
    /// A Class that creates a Timer, Sets the Timer to a Target Time, can Reset the Timer and countdown based off of Fixed Delta Time.
    /// </summary>
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
                return;
            }
            else
            {
                m_currentTime -= Time.fixedDeltaTime;
            }
		}

        /// <summary>
        /// Resets the Timer to the Target Time.
        /// </summary>
        public void ResetTimer()
        {
            m_currentTime = TargetTime;
        }

        /// <summary>
        /// Sets the Timer to the Target Time.
        /// </summary>
        /// <param name="targetTime"></param>
        public void SetTimer(float targetTime)
        {
            m_targetTime = targetTime;
        }
	}
}