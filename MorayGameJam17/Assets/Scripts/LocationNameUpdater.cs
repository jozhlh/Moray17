using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LocationNameUpdater : MonoBehaviour {
	

	[SerializeField]
	string shipName = "L.A.D.Ship";

	[SerializeField]
	string worldName = "New World Name";

	Text locationText = null;

	private void Start() {
		locationText = GetComponent<Text>();
		locationText.text = shipName;
	}
	private void OnEnable() {
		EventManager.OnNameChanged += OnNameChange;
	}

	private void OnDisable() {
		EventManager.OnNameChanged -= OnNameChange;
	}

	private void OnNameChange(EventManager.NameUpdateType newNameType, string newName) {
		switch (newNameType) {
			case EventManager.NameUpdateType.NewName:
                // SoundManager.SetSwitch(gameObject, "Landscape_States", "Landscape_Shuttle_State");
               // SoundManager.StopEvent("Landscape_Planet", 0, gameObject);
                //SoundManager.PlayEvent("Landscape_Shuttle", gameObject);
                locationText.text = newName;
				break;
			case EventManager.NameUpdateType.ShipName:
                //SoundManager.SetSwitch(gameObject, "Landscape_States", "Landscape_Shuttle_State");
                SoundManager.StopEvent("Landscape_Planet", 0, gameObject);
                SoundManager.PlayEvent("Landscape_Shuttle", gameObject);
                locationText.text = shipName;
				break;
			case EventManager.NameUpdateType.WorldName:
                // SoundManager.SetSwitch(gameObject, "Landscape_States", "Landscape_Outside_State");
                SoundManager.StopEvent("Landscape_Shuttle", 0, gameObject);
                SoundManager.PlayEvent("Landscape_Planet", gameObject);
				locationText.text = worldName;
				break;
		}
		
	}
}
