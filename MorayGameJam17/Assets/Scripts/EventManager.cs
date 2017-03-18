using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

	public delegate void EventHandler();
	/// <summary>
	/// Event to listen to for when the game might have been complted.
	/// </summary>
	public static event EventHandler OnPossibleGameCompletion;

	/// <summary>
	/// Event to listen to for when the game is completed.
	/// </summary>
	public static event EventHandler OnGameCompletion;

	/// <summary>
	/// Event to listen to for when the ship is fixed
	/// </summary>
	public static event EventHandler OnShipFixed;

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
}
