using UnityEngine;
using UnityEngine.InputSystem;

namespace Wonderseat
{
	public interface IInputs
	{
		Vector2 Move{ get; }
		bool Jump{ get; set; }
		bool Sprint{ get; }
	}	

	public class AssetInputs : MonoBehaviour, IInputs
	{
		public Vector2 Move => _move;
		public bool Jump
		{
			get
			{
				return _jump;
			}
			set
			{
				_jump = value;
			}
		}
		public bool Sprint => _sprint;

		private Vector2 _move;
		private bool _jump;
		private bool _sprint;

		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void MoveInput(Vector2 newMoveDirection)
		{
			_move = newMoveDirection;
		} 

		public void JumpInput(bool newJumpState)
		{
			_jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			_sprint = newSprintState;
		}
	}
}