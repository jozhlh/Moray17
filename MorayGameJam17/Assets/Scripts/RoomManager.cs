using UnityEngine;

public class RoomManager : MonoBehaviour {
	private RoomControl[] rooms;

	// Get all rooms that are children of the room manager
	// Initialise them with their room number
	void Start() {
		rooms = GetComponentsInChildren<RoomControl>();
		for (int i = 0; i < rooms.Length; i++) {
			rooms[i].Initialise(i);
		}
	}

	private void OnEnable() {
		EventManager.OnPossibleGameCompletion += CheckShipFixed;
	}

	private void OnDisable() {
		EventManager.OnPossibleGameCompletion -= CheckShipFixed;
	}

	public int NumberOfRooms() {
		return rooms.Length;
	}

	public void BreakRoom(int roomNum) {
		rooms[roomNum].Break();
	}

	/// <summary>
	/// Checks if all the rooms are fixed, if they are fires the Ship Fixed message.
	/// </summary>
	private void CheckShipFixed() {
		foreach (RoomControl room in rooms) {
			if (!room.IsRoomFixed()) {
				EventManager.ShipFixed();
			}
		}
	}
}
