using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

	public delegate void EventHandler();
	/// <summary>
	/// Event to listen to for when the game might have been complted.
	/// </summary>
	public static event EventHandler OnPossibleGameCompletion;

	/// <summary>
	/// Should be called when a the ship might be fixed.
	/// </summary>
	public static void PossibleCompletion() {
		// notify all listeners to event.
		if (OnPossibleGameCompletion != null) {
			OnPossibleGameCompletion();
		}
	}
}
