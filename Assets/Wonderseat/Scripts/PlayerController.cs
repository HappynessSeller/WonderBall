using UnityEngine;

namespace Wonderseat
{
    [RequireComponent(typeof(AssetInputs))]
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        public IInputs Input;
        public float MoveSpeed = 1;
        public float SprintMultiplyer = 1.5f;
        public float JumpSpeed = 10;
        public float Gravity = -9.8f;
        public LayerMask GroundLayers;

        private bool _grounded = false;
        private bool _canApplyAdditionalVerticalSpeed = false;
        private float _timeFromJumpStarted = 0;
        private const float _maxTimeToIncreaseJumpVelocity = 3f;
        private Vector3 _velocity;
        private Rigidbody _rigidbody;

        private void Start()
        {
            if (Input == null)
            {
                Input = GetComponent<AssetInputs>();
            }

            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            JumpAndGravity();
            SetSpeedX();
        }

        private void SetSpeedX()
        {
            var speed = Input.Sprint ? MoveSpeed * SprintMultiplyer : MoveSpeed;
            _velocity.x = Input.Move.x * speed;
            _rigidbody.velocity = new Vector3(_velocity.x, _rigidbody.velocity.y, _rigidbody.velocity.z);
        }

        private void JumpAndGravity()
        {
            bool jumpStarted = false;

            if (Input.Jump)
            {
                if (_grounded)
                {
                    _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, JumpSpeed, _rigidbody.velocity.z);
                    jumpStarted = true;
                    _canApplyAdditionalVerticalSpeed = true;
                }
                else if (_timeFromJumpStarted < _maxTimeToIncreaseJumpVelocity && _canApplyAdditionalVerticalSpeed)
                {
                   _rigidbody.velocity += new Vector3(0, JumpSpeed / 1000 / (1 + _timeFromJumpStarted), 0);
                }
            }
            else
            {
                _canApplyAdditionalVerticalSpeed = false;
            }

            if (_timeFromJumpStarted > 0 || jumpStarted)
            {
                _timeFromJumpStarted += Time.deltaTime;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
             if ((GroundLayers.value & (1 << collision.gameObject.layer)) > 0) 
             {
                _grounded = true;
                _timeFromJumpStarted = 0;
             }
        }

        private void OnCollisionExit(Collision collision)
        {
             if ((GroundLayers.value & (1 << collision.gameObject.layer)) > 0) 
             {
                _grounded = false;
             }
        }
    }
}