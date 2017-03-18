using UnityEngine;

public class HullController : MonoBehaviour {

	[SerializeField]
	GameObject hullModels = null;

	[SerializeField]
	float transitionTime = 3;

	[SerializeField]
	Transform downTransform = null;

	[SerializeField]
	Transform upTransform = null;

	private float startTime = 0;

	private Vector3 startPosition = Vector3.zero;

	private Vector3 endPosition = Vector3.zero;

	bool isMoving = false;

	void Start () {
		transform.position = downTransform.position;
		MoveUp();
	}

	private void Update() {
		if (isMoving) {
			float timeSinceStarted = Time.time - startTime;
			float percentageComplete = timeSinceStarted / transitionTime;

			hullModels.transform.position = Vector3.Lerp(startPosition, endPosition,
				Mathf.SmoothStep(0f, 1f, percentageComplete));

			//When we've completed the lerp, we set isMoving to false
			if (percentageComplete >= 1.0f) {
				isMoving = false;
			}
		}
	}

	private void MoveUp() {
		isMoving = true;
		startTime = Time.time;
		startPosition = downTransform.position;
		endPosition = upTransform.position;
	}
	private void MoveDown() {
		isMoving = true;
		startTime = Time.time;
		startPosition = upTransform.position;
		endPosition = downTransform.position;
	}

	private void OnTriggerEnter(Collider other) {
		if(other.tag == "Player") {
			MoveUp();
			EventManager.NameChanged(EventManager.NameUpdateType.ShipName);
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
			MoveDown();
			EventManager.NameChanged(EventManager.NameUpdateType.WorldName);			
		}
	}

}
