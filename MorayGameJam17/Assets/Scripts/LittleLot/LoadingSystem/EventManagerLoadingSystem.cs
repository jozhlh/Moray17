using UnityEngine;

/// <summary>
/// Framework of Common Use Classes and functions for Unity.
/// @StewMcc 09/04/2017
/// </summary>
namespace LittleLot {

	/// <summary>
	/// Handles events to do with Loading System.
	/// </summary>
	public class EventManagerLoadingSystem : MonoBehaviour {

		public delegate void EventHandlerLoadingSystem();
		/// <summary>
		/// Event to listen to for when the level has finished loading.
		/// </summary>
		public static event EventHandlerLoadingSystem OnLoadingFinished;

		/// <summary>
		/// Event to listen to for when to start the final animation of the loading screen.
		/// </summary>
		public static event EventHandlerLoadingSystem OnStartFinishLoadingAnimation;

		/// <summary>
		/// Should be called when the new level has finished loading.
		/// </summary>
		public static void FinishedLoading() {
			// notify all listeners to event.
			if (OnLoadingFinished != null) {
				OnLoadingFinished();
			}
		}

		/// <summary>
		/// Should be called to start any final animations for the loading screen.
		/// </summary>
		public static void FinishLoadingAnimation() {
			// notify all listeners to event.
			if (OnStartFinishLoadingAnimation != null) {
				OnStartFinishLoadingAnimation();
			}
		}



	}
}
