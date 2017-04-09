using UnityEngine;

/// <summary>
/// Framework of Common Use Classes and functions for Unity.
/// @StewMcc 09/04/2017
/// </summary>
namespace LittleLot {

	/// <summary>
	/// Forces the object to not be destroyed when a new scene loads.
	/// </summary>
	public class DontDestroyOnLoad : MonoBehaviour {

		/// <summary>
		/// Utilises DontDestroyOnLoad, to stop the object being destroyed.
		/// </summary>
		void Start() {
			DontDestroyOnLoad(this);
		}
	}
}
