using UnityEngine;

public class CreditsRolling : MonoBehaviour {
	[SerializeField]
	Camera sceneCamera = null;

	[SerializeField]
	float transitionTime = 12.0f;

	[SerializeField]
	Transform finalCameraPosition = null;

	private Vector3 startPosition_ = Vector3.zero;

	private float startTime_ =0;

	private bool isRollingCredits_ = false;

	private void OnEnable() {
		EventManager.OnGameCompletion += StartRollingCredits;
	}

	private void OnDisable() {
		EventManager.OnGameCompletion -= StartRollingCredits;
	}

	// Update is called once per frame
	void Update() {
		if (isRollingCredits_) {
			sceneCamera.transform.position = LittleLot.MathUtil.SmoothLerp(
					startPosition_,
					finalCameraPosition.position,
					startTime_,
					transitionTime,
					out isRollingCredits_);			
		}
	}

	/// <summary>
	/// Starts the credits rolling, by moving the camera up the credits.
	/// </summary>
	private void StartRollingCredits() {
		isRollingCredits_ = true;
		startTime_ = Time.time;
		startPosition_ = sceneCamera.transform.position;
	}
}
