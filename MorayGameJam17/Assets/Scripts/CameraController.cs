using UnityEngine;

public class CameraController : MonoBehaviour {
	[SerializeField]
	RobotController robot =null;

	[Tooltip("Distance camera is offset from the bot.")]
	[SerializeField]
	Vector3 cameraOffset = Vector3.zero;

	[SerializeField]
	float transitionTime = 3;

	private float startTime =0;

	private Vector3 initialPosition = Vector3.zero;

	private Vector3 lerpStartPosition = Vector3.zero;

	private bool isFollowingRobot = true;

	private bool isMovingToDistressBeacon = true;

	private void Start() {

		initialPosition = gameObject.transform.position;
	}

	private void OnEnable() {
		EventManager.OnShipFixed += OnShipFixed;
	}

	private void OnDisable() {
		EventManager.OnShipFixed -= OnShipFixed;
	}

	/// <summary>
	/// Just before rendering, updates the camera to follow the robot.
	/// </summary>
	private void LateUpdate() {
		if (isFollowingRobot) {
			transform.position = new Vector3(
				robot.transform.position.x + cameraOffset.x,
				transform.position.y + cameraOffset.y,
				robot.transform.position.z + cameraOffset.z);
		}
		else if (isMovingToDistressBeacon) {
			float timeSinceStarted = Time.time - startTime;
			float percentageComplete = timeSinceStarted / transitionTime;

			transform.position = Vector3.Lerp(lerpStartPosition, initialPosition,
				Mathf.SmoothStep(0f, 1f, percentageComplete));

			//When we've completed the lerp, we set isMovingToDistressBeacon to false
			if (percentageComplete >= 1.0f) {
				isMovingToDistressBeacon = false;
				EventManager.CameraInPosition();
			}
		}
	}

	private void OnShipFixed() {
		isFollowingRobot = false;
		isMovingToDistressBeacon = true;

		startTime = Time.time;
		lerpStartPosition = gameObject.transform.position;
	}




}
