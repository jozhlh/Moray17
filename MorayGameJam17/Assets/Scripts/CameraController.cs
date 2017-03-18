using UnityEngine;

public class CameraController : MonoBehaviour {
	[SerializeField]
	RobotController robot =null;

	[Tooltip("Distance camera is offset from the bot.")]
	[SerializeField]
	Vector3 cameraOffset = Vector3.zero;

	private Vector3 initialPosition = Vector3.zero;

	private bool isFollowingRobot = true;

	private void Start() {

		initialPosition = gameObject.transform.position;
	}

	private void OnEnable() {
		EventManager.OnGameCompletion += OnGameWin;
	}

	private void OnDisable() {
		EventManager.OnGameCompletion -= OnGameWin;
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
	}

	private void OnGameWin() {
		isFollowingRobot = false;
		gameObject.transform.position = initialPosition;
	}
}
