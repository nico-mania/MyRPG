// Prüft, ob der Spieler Bodenkontakt hat, basierend auf einem Raycast unterhalb des Colliders.

using UnityEngine;

namespace Player.Movement
{
    [RequireComponent(typeof(Collider))]
    public class GroundChecker : MonoBehaviour
    {
        [Header("Ground Check Settings")]
        public float checkDistance = 0.1f;
        public LayerMask groundLayer = ~0;

        private Collider _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
        }

        public bool IsGrounded
        {
            get
            {
                if (_collider == null) return false;

                Vector3 origin = _collider.bounds.center;
                origin.y = _collider.bounds.min.y + 0.01f;

                return Physics.Raycast(origin, Vector3.down, checkDistance, groundLayer);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            if (TryGetComponent(out Collider col))
            {
                Vector3 origin = col.bounds.center;
                origin.y = col.bounds.min.y + 0.01f;

                Gizmos.DrawLine(origin, origin + Vector3.down * checkDistance);
            }
        }
    }
}
