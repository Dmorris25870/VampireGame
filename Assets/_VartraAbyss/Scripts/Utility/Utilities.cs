using UnityEngine;

namespace VartraAbyss.Utility
{
    public class Utilities : MonoBehaviour
    {
        public static float GetDistanceBetweenTwoActors(GameObject actor1, GameObject actor2)
        {
            float distance = Vector3.Distance(actor1.transform.position, actor2.transform.position);
            return distance;
        }
    }
}