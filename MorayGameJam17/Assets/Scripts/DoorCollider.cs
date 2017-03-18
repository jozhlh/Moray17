using UnityEngine;

public class DoorCollider : MonoBehaviour {
	[SerializeField]
	Door airLock  = null;
	
	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			airLock.OpenDoor();
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {			
			airLock.CloseDoor();
		}
	}
}
