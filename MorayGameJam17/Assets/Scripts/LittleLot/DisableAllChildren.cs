using UnityEngine;

/// <summary>
/// Framework of Common Use Classes and functions for Unity.
/// @StewMcc 09/04/2017
/// </summary>
namespace LittleLot {

	/// <summary>
	/// Simple Utility class that disables all child game objects on start.
	/// </summary>
	public class DisableAllChildren : MonoBehaviour {

		/// <summary>
		/// Disables all child game objects.
		/// </summary>
		void Start() {
			foreach (Transform child in transform) {
				child.gameObject.SetActive(false);
			}
		}
	}
}
