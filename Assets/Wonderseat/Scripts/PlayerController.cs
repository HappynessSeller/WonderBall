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
        public LayerMask GroundLayers;

        private bool _grounded = false;
        private bool _canApplyAdditionalVerticalSpeed = false;
        private float _timeFromJumpStarted = 0;
        private const float _maxTimeToIncreaseJumpVelocity = 3f;
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
            float speedY = Jump();
            float speedX = GetSpeedX();

            _rigidbody.velocity = new Vector3(speedX, speedY, _rigidbody.velocity.z);
        }

        private float Jump()
        {
            float speed = _rigidbody.velocity.y;
            bool jumpStarted = false;

            if (Input.Jump)
            {
                if (_grounded)
                {
                    speed = JumpSpeed;
                    jumpStarted = true;
                    _canApplyAdditionalVerticalSpeed = true;
                }
                else if (_timeFromJumpStarted < _maxTimeToIncreaseJumpVelocity && _canApplyAdditionalVerticalSpeed)
                {
                    float acceleration = JumpSpeed / 1000 / (1 + _timeFromJumpStarted);
                    speed = _rigidbody.velocity.y + acceleration;
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

            return speed;
        }

        private float GetSpeedX()
        {
            var speed = Input.Sprint ? MoveSpeed * SprintMultiplyer : MoveSpeed;
            speed *= Input.Move.x;

            return speed;
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