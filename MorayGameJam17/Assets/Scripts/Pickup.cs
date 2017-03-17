using UnityEngine;

public class Pickup : MonoBehaviour {

	[SerializeField]
	string garbageName = "DefaultName";

	[SerializeField]
	float itemHeightOffsetWhenPickedUp = 1.0f;

	[SerializeField]
	Canvas interactableCanvas = null;

	Vector3 initialPosition = Vector3.zero;

	Vector3 droppedTargetPosition = Vector3.zero;

	float minDropOffset = 2;

	float maxDropOffset = 10;
	/// <summary>
	/// Saves initial pos and disables Popup
	/// </summary>
	private void Start() {
		interactableCanvas.enabled = false;
		initialPosition = transform.position;
	}

	/// <summary>
	/// Height Offset for position above player, to stop clipping.
	/// </summary>
	/// <returns></returns>
	public float ItemheightOffset() {
		return itemHeightOffsetWhenPickedUp;
	}

	/// <summary>
	/// Enables the popup.
	/// </summary>
	public void ShowPopUp() {		
		interactableCanvas.enabled = true;
	}

	/// <summary>
	/// Hides the popup.
	/// </summary>
	public void HidePopUp() {
		interactableCanvas.enabled = false;
	}

	/// <summary>
	/// Returns the currently available name.
	/// Garbage name or variation, or the full name.
	/// </summary>
	/// <returns></returns>
	public string Name() {
		return garbageName;
	}


	/// <summary>
	/// Drops the item at a random position near the player.	
	/// </summary>
	public void ItemDropped() {
		// TODO :: Replace with proper dropping, placeholder tempory.
		transform.position = new Vector3(
			transform.position.x,
			initialPosition.y,
			transform.position.z);

	}


}
