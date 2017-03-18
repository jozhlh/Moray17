using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControl : MonoBehaviour 
{
	[SerializeField]
	private int maxRoomsToBreak = 2;
	[SerializeField]
	private Pickup.ItemType correctItem;
	[SerializeField]
	private RobotController player = null;
	[SerializeField]
	private List<ItemResponse> incorrectResponses = null;
	private RoomManager roomManager = null;
	private bool roomFixed = true;
	int roomID;

	public void Initialise(int id)
	{
		roomManager = GetComponentInParent<RoomManager>();
		roomID = id;
		int iterator = 0;
		int maxRooms = roomManager.NumberOfRooms();
		incorrectResponses = new List<ItemResponse>();

		// create a response for each availabe item type (- the correct item)
		for (int i = 0; i < System.Enum.GetValues(typeof(Pickup.ItemType)).Length; i++)
		{
			incorrectResponses.Add(new ItemResponse());
		}

		for (int response = 0; response < incorrectResponses.Count; response++)
		{
			// randomly select how many rooms will be broken by presenting the incorrect item
			incorrectResponses[response].Initialise(maxRoomsToBreak);

			// for each room that will be broken
			for (int room = 0; room < incorrectResponses[response].roomsToBreak.Length; room++)
			{
				// select a room which is not this room
				bool validRoom = false;
				while (!validRoom)
				{
					int roomToBreak = Random.Range(0, maxRooms);
					if (roomToBreak != roomID)
					{
						incorrectResponses[response].roomsToBreak[room] = roomToBreak;
						validRoom = true;
					}
				}
			}
			// move to the next item type
			iterator++;
		}
	}

	public void CheckItem()
	{
		Pickup.ItemType presentedItem = player.CurrentItem().CheckItemType();
		if (presentedItem == correctItem)
		{
			// success the room is fixed
			roomFixed = true;
		}
		else
		{
			// get a list of rooms to break and break them
			int[] roomsToBreak = incorrectResponses[(int)presentedItem].roomsToBreak;
			foreach (int roomNum in roomsToBreak)
			{
				roomManager.BreakRoom(roomNum);
			}
		}
		player.RespawnCurrentItem();
		GetComponentInChildren<ServicePort>().HidePopUp();
	}

	public void Break()
	{
		roomFixed = false;
	}
}
