using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class RobotController : MonoBehaviour {

	[Tooltip("Distance camera is offset from the bot.")]
	[SerializeField]
	Vector3 cameraOffset = Vector3.zero;

	[Tooltip("Camera which will follow the player.")]
	[SerializeField]
	Camera sceneCamera = null;

	// Controls the navigation of the bot on the navmesh
	private NavMeshAgent agent_ = null;


	/// <summary>
	/// Sets up the navmeshagent.
	/// </summary>
	private void Start () {
		agent_ = GetComponent<NavMeshAgent>();		
	}

	/// <summary>
	/// When the player taps the screen updates the target for the robot.	
	/// </summary>
	private void Update() {
		if (OnTap()) {
			// ray trace to check if touching a segment.
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			// if its hit anything
			if (Physics.Raycast(ray, out hit)) {
				agent_.destination = hit.point;
			}
		}
	}

	/// <summary>
	/// Just before rendering, updates the camera to follow the robot.
	/// </summary>
	private void LateUpdate() {
		sceneCamera.transform.position = new Vector3(
			transform.position.x+ cameraOffset.x,
			sceneCamera.transform.position.y + cameraOffset.y,
			transform.position.z+ cameraOffset.z);
	}

	/// <summary>
	/// Checks for tap on screen.
	/// Just Input.Mouse check.
	/// </summary>
	/// <returns></returns>
	private bool OnTap() {
		if (Input.GetMouseButtonDown(0)) {
			return true;
		}
		return false;
	}

	/// <summary>
	/// Gizmo whichs draws the forward vector.
	/// Handy for knowing where the front of an object is.
	/// </summary>
	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Vector3 direction = transform.TransformDirection(Vector3.forward) * 4;
		Gizmos.DrawRay(transform.position, direction);
	}
}
