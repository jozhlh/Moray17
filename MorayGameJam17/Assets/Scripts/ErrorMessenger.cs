using UnityEngine;
using System.Collections;

public class ErrorMessenger : MonoBehaviour {

	[SerializeField]
	ErrorMessage[] errorMessages = null;

	[SerializeField]
	float messageHeight = -100.0f;

	int currentMessage = 0;

	private void Start() {
		foreach (ErrorMessage message in errorMessages) {
			message.SetAlpha(0);
		}
	}
	
	private void OnEnable() {
		EventManager.OnRoomBroken += OnRoomError;		
	}

	private void OnDisable() {
		EventManager.OnRoomBroken -= OnRoomError;		
	}

	private void OnRoomError(string roomName) {
		DisplayErrorMessage(roomName);		
	}

	private void DisplayErrorMessage(string roomName) {
		foreach (ErrorMessage message in errorMessages) {
			message.ShiftUp(messageHeight);
		}
		errorMessages[currentMessage].ResetPosition();
		errorMessages[currentMessage].SetText(roomName +" Damaged");
		errorMessages[currentMessage].SetAlpha(1);
		currentMessage++;
		if(currentMessage >= errorMessages.Length) {
			currentMessage = 0;
		}
	}

}
