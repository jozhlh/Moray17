using UnityEngine;

public class Door : MonoBehaviour {
	[SerializeField]
	GameObject doorModel = null;

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
		
	void Update() {

		//TODO:: Remove Debug
		if (Input.GetKeyDown(KeyCode.A)) {
			CloseDoor();
		}
		else if (Input.GetKeyDown(KeyCode.D)) {
			OpenDoor();
		}

		if (isMoving) {
			float timeSinceStarted = Time.time - startTime;
			float percentageComplete = timeSinceStarted / transitionTime;

			doorModel.transform.position = Vector3.Lerp(startPosition, endPosition,
				Mathf.SmoothStep(0f, 1f, percentageComplete));

			//When we've completed the lerp, we set isMoving to false
			if (percentageComplete >= 1.0f) {
				isMoving = false;
			}
		}
	}

	public void CloseDoor() {
		isMoving = true;
		startTime = Time.time;
		startPosition = downTransform.position;
		endPosition = upTransform.position;
	}
	public void OpenDoor() {
		isMoving = true;
		startTime = Time.time;
		startPosition = upTransform.position;
		endPosition = downTransform.position;
	}
}
