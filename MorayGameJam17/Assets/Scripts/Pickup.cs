using UnityEngine;

public class Pickup : MonoBehaviour {

	[SerializeField]
	string garbageName = "DefaultName";

	[SerializeField]
	float itemHeightOffsetWhenPickedUp = 1.0f;

	[SerializeField]
	Canvas interactableCanvas = null;

	Vector3 initialPosition = Vector3.zero;
	
	private void Start() {
		interactableCanvas.enabled = false;
		initialPosition = transform.position;
	}

	public float ItemheightOffset() {
		return itemHeightOffsetWhenPickedUp;
	}

	public float InitialHeight() {
		return initialPosition.y;
	}

	public void ShowPopUp() {		
		interactableCanvas.enabled = true;
	}

	public void HidePopUp() {
		interactableCanvas.enabled = false;
	}

	public string Name() {
		return garbageName;
	}
}
