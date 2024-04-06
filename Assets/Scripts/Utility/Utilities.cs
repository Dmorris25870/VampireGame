using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VartraAbyss.Entity;

namespace VartraAbyss.Utility
{
    public class Utilities : MonoBehaviour
    {
        /// <summary>
        /// Instead of having to use Vector3.Distance, just pass through two gameObjects and it will return the distance.
        /// </summary>
        /// <param name="actor1"></param>
        /// <param name="actor2"></param>
        /// <returns></returns>
        public static float GetDistanceBetweenTwoActors(GameObject actor1, GameObject actor2)
        {
            float distance = Vector3.Distance(actor1.transform.position, actor2.transform.position);
            return distance;
        }
    }
}