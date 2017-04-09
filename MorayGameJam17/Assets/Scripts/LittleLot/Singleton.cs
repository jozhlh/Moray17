using UnityEngine;

/// <summary>
/// Framework of Common Use Classes and functions for Unity.
/// @StewMcc 09/04/2017
/// </summary>
namespace LittleLot {
	
	/// <summary>
	/// Singleton class that ensures there is only ever one of itself in the scene.
	/// The singleton will delete itself if one already exists.
	/// </summary>
	public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {

		private static T instance_;

		/// <summary>
		/// Ensures only one instance of the singleton exists at any time,
		///  will destroy itself if one already exists.
		/// </summary>
		private void Awake() {
			if (instance_ != null && instance_ != this) {
				Destroy(gameObject);
				Debug.Log("Destroying Duplicate Singleton");
			}
			else {
				instance_ = GetComponent<T>();
			}
		}
		
		/// <summary>
		/// Returns the single instance of this object.		
		/// </summary>
		/// <return> The component refrence of the object. </return>
		public static T instance {
			get {
				if (instance_ == null) {
					instance_ = (T)FindObjectOfType(typeof(T));
				}
				return instance_;
			}
		}

	}
}
