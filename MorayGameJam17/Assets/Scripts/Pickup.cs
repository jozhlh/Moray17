using UnityEngine;

public class Pickup : MonoBehaviour {

	public enum ItemType { item1, item2, item3 , item4};

	[SerializeField]
	string garbageName = "DefaultName";
	[SerializeField]
	private ItemType itemType;

	[SerializeField]
	float itemHeightOffsetWhenPickedUp = 1.0f;

	[SerializeField]
	Canvas interactableCanvas = null;

	Vector3 initialPosition = Vector3.zero;

	Vector3 droppedTargetPosition = Vector3.zero;

	float minDropOffset = -1;

	float maxDropOffset = 1;
	
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
		
		droppedTargetPosition = transform.position + new Vector3(
			Random.Range(minDropOffset, maxDropOffset),
			0,
			Random.Range(minDropOffset, maxDropOffset));

		droppedTargetPosition = CalculateMoveToTarget(droppedTargetPosition);

		transform.position = new Vector3(
			droppedTargetPosition.x,
			initialPosition.y,
			droppedTargetPosition.z);
	}

	/// Checks a target point to make sure its valid if it is not, it will move it back towards the player.
	/// </summary>
	/// <param name="targetPosition"> New Position to dop item to</param>
	/// <returns></returns>
	private Vector3 CalculateMoveToTarget(Vector3 targetPosition) {
		Vector3 randomDirection = targetPosition - transform.position;
		randomDirection.Normalize();
		
		RaycastHit hit;
		Ray ray = new Ray(transform.position, randomDirection);
		// if its hit anything
		if (Physics.Raycast(ray, out hit)) {
			if (hit.transform.tag != "Navable") {
				targetPosition = hit.point -= randomDirection;
			}
		}
		
		return targetPosition;

	/// <summary>
	/// Returns the type of the item	
	/// </summary>
	public ItemType CheckItemType()
	{
		return itemType;
	}

	public void Respawn()
	{
		transform.position = initialPosition;
	}
}
