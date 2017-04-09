using UnityEngine;

/// <summary>
/// Framework of Common Use Classes and functions for Unity.
/// @StewMcc 09/04/2017
/// </summary>
namespace LittleLot {

	/// <summary>
	/// Idle Animation script, gives nice rotation and scaling animation.
	/// </summary>
	public class IdleAnimation : MonoBehaviour {

		[SerializeField]
		[Tooltip("Used for end rotation, position and scale values, Ensure rotation angles are positive...reasons.")]
		Transform pingPongTarget = null;

		[Header("Animation")]
		[SerializeField]
		bool isAnimated = true;

		[SerializeField]
		bool isMoving = true;

		[SerializeField]
		[Tooltip("The amount of time in seconds it should take to move to the target.")]
		float moveToTargetInterval =2.0f;

		[SerializeField]
		bool isScaling = true;

		[SerializeField]
		[Tooltip("The amount of time in seconds it should take to scale to the targets scale.")]
		float scaleToTargetInterval =2.0f;

		[SerializeField]
		bool isRotating = true;

		[SerializeField]
		[Tooltip("The amount of time in seconds it should take to rotate to the targets rotation.")]
		float rotateToTargetInterval =2.0f;

		private Vector3 pingPongMoveTo_;

		private Vector3 pingPongMoveFrom_;

		private Vector3 pingPongScaleTo_;

		private Vector3 pingPongScaleFrom_;

		private Vector3 pingPongRotateTo_;

		private Vector3 pingPongRotateFrom_;

		private bool wasAnimating_ = true;

		/// <summary>
		/// Store initial start and end points.
		/// </summary>
		private void Start() {
			SetupPingPongTargets();
		}

		/// <summary>
		/// Update the animations.
		/// Moving,rotating and scaling between values.
		/// </summary>
		private void Update() {
			if (isAnimated && pingPongTarget) {
				if (isMoving) {
					PingPongMoveToTarget();
				}
				if (isRotating) {
					PingPongRotateToTarget();
				}
				if (isScaling) {
					PingPongScaleToTarget();
				}
			}
		}

		/// <summary>
		/// Stores the initial to and from targets for animations.
		/// </summary>
		private void SetupPingPongTargets() {
			pingPongMoveTo_ = pingPongTarget.position;
			pingPongMoveFrom_ = transform.position;

			pingPongScaleTo_ = pingPongTarget.localScale;
			pingPongScaleFrom_ = transform.localScale;

			pingPongRotateTo_ = pingPongTarget.rotation.eulerAngles;
			pingPongRotateFrom_ = transform.rotation.eulerAngles;
		}

		/// <summary>
		/// Pauses the animation effects.
		/// </summary>
		public void PauseAnimation() {
			wasAnimating_ = isAnimated;
			isAnimated = false;
		}

		/// <summary>
		/// Resumes the animation.
		/// </summary>
		public void ResumeAnimation() {
			isAnimated = wasAnimating_;
		}

		/// <summary>
		/// Moves the collectable towards the set target with lerp(smoothstep(pingpong))).
		/// Gives a nice dampened animation effect back and forth.
		/// </summary>
		private void PingPongMoveToTarget() {
			transform.position = MathUtil.SmoothPingPongLerp(pingPongMoveFrom_, pingPongMoveTo_, moveToTargetInterval);
		}

		/// <summary>
		/// Rotates the collectable towards the set target with lerp(smoothstep(pingpong))).
		/// Gives a nice dampened animation effect back and forth.
		/// </summary>
		private void PingPongRotateToTarget() {
			transform.rotation = Quaternion.Euler(MathUtil.SmoothPingPongLerp(pingPongRotateFrom_, pingPongRotateTo_, rotateToTargetInterval));
		}

		/// <summary>
		/// Scales the collectable towards the set target with lerp(smoothstep(pingpong))).
		/// Gives a nice dampened animation effect back and forth.
		/// </summary>
		private void PingPongScaleToTarget() {
			transform.localScale = MathUtil.SmoothPingPongLerp(pingPongScaleFrom_, pingPongScaleTo_, scaleToTargetInterval);
		}

	}
}
