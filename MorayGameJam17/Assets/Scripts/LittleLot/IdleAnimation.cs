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
		protected Transform pingPongTarget = null;

		[Header("Animation")]
		[SerializeField]
		protected bool isAnimated = true;

		[SerializeField]
		protected bool isMoving = true;

		[SerializeField]
		[Tooltip("The amount of time in seconds it should take to move to the target.")]
		protected float moveToTargetInterval =2.0f;

		[SerializeField]
		protected bool isScaling = true;

		[SerializeField]
		[Tooltip("The amount of time in seconds it should take to scale to the targets scale.")]
		protected float scaleToTargetInterval =2.0f;

		[SerializeField]
		protected bool isRotating = true;

		[SerializeField]
		[Tooltip("The amount of time in seconds it should take to rotate to the targets rotation.")]
		protected float rotateToTargetInterval =2.0f;

		protected Vector3 pingPongMoveTo_;

		protected Vector3 pingPongMoveFrom_;

		protected Vector3 pingPongScaleTo_;

		protected Vector3 pingPongScaleFrom_;

		protected Vector3 pingPongRotateTo_;

		protected Vector3 pingPongRotateFrom_;

		protected bool wasAnimating_ = true;

		/// <summary>
		/// Store initial start and end points.
		/// </summary>
		protected void Start() {
			SetupPingPongTargets();
		}

		/// <summary>
		/// Update the animations.
		/// Moving,rotating and scaling between values.
		/// </summary>
		protected void Update() {
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
		/// Stores the initial to and from targets for animations.
		/// </summary>
		protected void SetupPingPongTargets() {
			pingPongMoveTo_ = pingPongTarget.position;
			pingPongMoveFrom_ = transform.position;

			pingPongScaleTo_ = pingPongTarget.localScale;
			pingPongScaleFrom_ = transform.localScale;

			pingPongRotateTo_ = pingPongTarget.rotation.eulerAngles;
			pingPongRotateFrom_ = transform.rotation.eulerAngles;
		}

		/// <summary>
		/// Moves the collectable towards the set target with lerp(smoothstep(pingpong))).
		/// Gives a nice dampened animation effect back and forth.
		/// </summary>
		protected void PingPongMoveToTarget() {
			transform.position = MathUtil.SmoothPingPongLerp(pingPongMoveFrom_, pingPongMoveTo_, moveToTargetInterval);
		}

		/// <summary>
		/// Rotates the collectable towards the set target with lerp(smoothstep(pingpong))).
		/// Gives a nice dampened animation effect back and forth.
		/// </summary>
		protected void PingPongRotateToTarget() {
			transform.rotation = Quaternion.Euler(MathUtil.SmoothPingPongLerp(pingPongRotateFrom_, pingPongRotateTo_, rotateToTargetInterval));
		}

		/// <summary>
		/// Scales the collectable towards the set target with lerp(smoothstep(pingpong))).
		/// Gives a nice dampened animation effect back and forth.
		/// </summary>
		protected void PingPongScaleToTarget() {
			transform.localScale = MathUtil.SmoothPingPongLerp(pingPongScaleFrom_, pingPongScaleTo_, scaleToTargetInterval);
		}

	}
}
