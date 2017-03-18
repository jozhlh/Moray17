using UnityEngine;

/// <summary>
/// PickUp Idle Animation script, gives nice rotation and scaling animation.
/// </summary>
[RequireComponent(typeof(MeshRenderer))]
public class PickUpIdleAnimation : MonoBehaviour {

	[SerializeField]
	[Tooltip("Used for end rotation, position and scale values.")]
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
	/// Store initial start and end points, and ensures tag is correctly set.
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

	public void PauseAnimation() {
		wasAnimating_ = isAnimated;
		isAnimated = false;
	}

	public void ResumeAnimation() {
		isAnimated = wasAnimating_;
		SetupPingPongTargets();
	}

	private void SetupPingPongTargets() {
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
	private void PingPongMoveToTarget() {
		transform.position = Vector3Lerp(pingPongMoveFrom_, pingPongMoveTo_, moveToTargetInterval);
	}

	/// <summary>
	/// Rotates the collectable towards the set target with lerp(smoothstep(pingpong))).
	/// Gives a nice dampened animation effect back and forth.
	/// </summary>
	private void PingPongRotateToTarget() {
		transform.rotation = Quaternion.Euler(Vector3Lerp(pingPongRotateFrom_, pingPongRotateTo_, rotateToTargetInterval));
	}

	/// <summary>
	/// Scales the collectable towards the set target with lerp(smoothstep(pingpong))).
	/// Gives a nice dampened animation effect back and forth.
	/// </summary>
	private void PingPongScaleToTarget() {
		transform.localScale = Vector3Lerp(pingPongScaleFrom_, pingPongScaleTo_, scaleToTargetInterval);
	}

	/// <summary>
	/// Lerps between the from and to vectors.
	/// Back and forth using pingpong, whilst using smoothstep to give it nice dampening.
	/// Within the interval time.
	/// </summary>
	/// <param name="from"> Point to lerp from. </param>
	/// <param name="to"> Point to lerp towards. </param>
	/// <param name="interval"> The amount of time in seconds it should take. </param>
	private Vector3 Vector3Lerp(Vector3 from, Vector3 to, float interval) {
		return Vector3.Lerp(from, to,
			// Smooth step gives it nice dampening at start and end of bounce.
			Mathf.SmoothStep(0f, 1f,
			// Ensures it is a value between 0-1 for lerp but based on how long it should last.
			Mathf.PingPong(Time.time / interval, 1f)));
	}

}
