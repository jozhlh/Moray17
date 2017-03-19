using UnityEngine;
using UnityEngine.UI;

public class ServicePort : MonoBehaviour {

	[SerializeField]
	Canvas interactableCanvas = null;

	[SerializeField]
	GameObject iconObject = null;

	/// <summary>
	/// Disables Popup
	/// </summary>
	private void Start() {
		//interactableCanvas.enabled = false;
		HidePopUp();
	}

	public bool IsFixed() {
		return GetComponentInParent<RoomControl>().IsRoomFixed();		
	}

	/// <summary>
	/// Enables the popup.
	/// </summary>
	public void ShowPopUp() {
		interactableCanvas.enabled = true;
		iconObject.SetActive(true);
        SoundManager.PlayEvent("Item_PopUp", gameObject);
    }

	/// <summary>
	/// Hides the popup.
	/// </summary>
	public void HidePopUp() {
		interactableCanvas.enabled = false;
		iconObject.SetActive(false);
        SoundManager.PlayEvent("Item_PopDown", gameObject);
    }
}
