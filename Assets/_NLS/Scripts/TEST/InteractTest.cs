using UnityEngine;

namespace _NLS.Scripts.TEST
{
    public class InteractTest : MonoBehaviour, IInteractable
    {
        public float interactDistance;
    
        public bool SetDistance(Vector3 player)
        {
            Vector3 diff = transform.position - player;
            float sqrDist = diff.sqrMagnitude;
            return sqrDist < interactDistance;
        }
    }
}
