using System.Collections;

using UnityEngine;

using LittleLot;

/// <summary>
/// Loads the set scene once objects is awake.
/// This ensures all other objects have been set up properly before the load happens.
/// </summary>
public class LoadingAutoStart : MonoBehaviour {

	[SerializeField]
	string sceneToAutoLoad = "Splash_Scene";

	/// <summary>
	/// On Initial load determines based on save data which level to load next.
	/// Whether it should load the explore screen, or load the onboarding sequence.	
	/// </summary>
	private IEnumerator Start() {
		// Ensures it happens after everything else has been succesfully loaded.
		// Solves problem with some objects not being initialised fully (i.e. the transition controller)
		yield return new WaitForEndOfFrame();
		
		LoadingTransitionController.AnimatedLoadSceneAsync(sceneToAutoLoad);
		
	}
}
