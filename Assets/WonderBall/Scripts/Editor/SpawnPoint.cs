using UnityEngine;

namespace Wonderseat
{
    public class SpawnPoint : MonoBehaviour
    {
    #if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.DrawIcon(transform.position + new Vector3(0, 0.5f, 0), "SpawnPoint.png", true);
        }
    #endif
    }
}