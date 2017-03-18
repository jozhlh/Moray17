using UnityEngine;

public class ServicePort : MonoBehaviour {

	[SerializeField]
	Canvas interactableCanvas = null;


	/// <summary>
	/// Disables Popup
	/// </summary>
	private void Start() {
		interactableCanvas.enabled = false;
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


}
