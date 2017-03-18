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
				locationText.text = newName;
				break;
			case EventManager.NameUpdateType.ShipName:
				locationText.text = shipName;
				break;
			case EventManager.NameUpdateType.WorldName:
				locationText.text = worldName;
				break;
		}
		
	}
}
