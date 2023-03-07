using UnityEngine;
using System;

namespace Wonderseat
{
    [RequireComponent(typeof(Rigidbody))]
    public class BallController : MonoBehaviour
    {
        public LayerMask PlayerLayer;
        public LayerMask FloorLayer;
        public Action<PlayerSide> OnTouchedGround;

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
            }
            
            if ((FloorLayer.value & (1 << collision.gameObject.layer)) > 0) 
            {
                OnTouchedGround?.Invoke(transform.localPosition.x > 0 ? PlayerSide.Left : PlayerSide.Right);
            }
        }
    }
}
