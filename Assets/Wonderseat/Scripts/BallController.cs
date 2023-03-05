using UnityEngine;

namespace Wonderseat
{
    [RequireComponent(typeof(Rigidbody))]
    public class BallController : MonoBehaviour
    {
        public LayerMask PlayerLayer;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Reset(Vector3 position)
        {
            transform.position = position;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.useGravity = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if ((PlayerLayer.value & (1 << collision.gameObject.layer)) > 0) 
            {
                if (!_rigidbody.useGravity)
                {
                    _rigidbody.useGravity = true;
                }
                _rigidbody.AddForce(collision.rigidbody.velocity, ForceMode.Impulse);
            }
        }

        private void OnCollisionExit(Collision collision)
        {

        }
    }
}
