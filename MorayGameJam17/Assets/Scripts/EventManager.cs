using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {
	public enum NameUpdateType { NewName, ShipName, WorldName };

	public delegate void EventHandler();
	/// <summary>
	/// Event to listen to for when the game might have been complted.
	/// </summary>
	public static event EventHandler OnPossibleGameCompletion;

	/// <summary>
	/// Event to listen to for when the game is completed.
	/// </summary>
	public static event EventHandler OnCameraInPosition;

	/// <summary>
	/// Event to listen to for when the game is completed.
	/// </summary>
	public static event EventHandler OnGameCompletion;

	/// <summary>
	/// Event to listen to for when the ship is fixed
	/// </summary>
	public static event EventHandler OnShipFixed;


	public delegate void EventHandlerLocationName(NameUpdateType newNameType, string newName = "");

	/// <summary>
	/// Event to listen to for when locationNameChanges.
	/// </summary>
	public static event EventHandlerLocationName OnNameChanged;

	/// <summary>
	/// Should be called when a the ship might be fixed.
	/// </summary>
	public static void PossibleCompletion() {
		// notify all listeners to event.
		if (OnPossibleGameCompletion != null) {
			OnPossibleGameCompletion();
		}
	}

	/// <summary>
	/// Should be called when the Camera is ready fro the distress signal to send.
	/// </summary>
	public static void CameraInPosition() {
		// notify all listeners to event.
		if (OnCameraInPosition != null) {
			OnCameraInPosition();
		}
	}

	/// <summary>
	/// Should be called when the distress signal is sent.
	/// </summary>
	public static void GameCompleted() {
		// notify all listeners to event.
		if (OnGameCompletion != null) {
			OnGameCompletion();
		}
	}

	/// <summary>
	/// Should be called when a the ship is fixed.
	/// </summary>
	public static void ShipFixed() {
		// notify all listeners to event.
		if (OnShipFixed != null) {
			OnShipFixed();
		}
	}

	public static void NameChanged(NameUpdateType newNameType, string newName = "") {
		// notify all listeners to event.
		if (OnNameChanged != null) {
			OnNameChanged(newNameType, newName);
		}
	}
}
