﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControl : MonoBehaviour
{

	[SerializeField]
	private Renderer rend = null;

	[SerializeField]
	private int maxRoomsToBreak = 2;
	[SerializeField]
	private Pickup.ItemType correctItem = Pickup.ItemType.item1;
	[SerializeField]
	private RobotController player = null;
//	[SerializeField]
	private List<ItemResponse> incorrectResponses = null;
	private RoomManager roomManager = null;
	private bool isFixed = true;
	int roomID;
	private float greenTexDuration = 2.0f;

	//TODO:: Remove Just Debug
	private void Update() {
		if (Input.GetMouseButtonDown(1)) {
			isFixed = true;
			EventManager.PossibleCompletion();
		}
	}

	public void Initialise(int id) {
		roomManager = GetComponentInParent<RoomManager>();
		roomID = id;
		int iterator = 0;
		int maxRooms = roomManager.NumberOfRooms();
		incorrectResponses = new List<ItemResponse>();

		// create a response for each availabe item type (- the correct item)
		for (int i = 0; i < System.Enum.GetValues(typeof(Pickup.ItemType)).Length; i++) {
			incorrectResponses.Add(new ItemResponse());
		}

		for (int response = 0; response < incorrectResponses.Count; response++) {
			// randomly select how many rooms will be broken by presenting the incorrect item
			incorrectResponses[response].Initialise(maxRoomsToBreak);

			// for each room that will be broken
			for (int room = 0; room < incorrectResponses[response].roomsToBreak.Length; room++) {
				// select a room which is not this room
				bool validRoom = false;
				while (!validRoom) {
					int roomToBreak = Random.Range(0, maxRooms);
					if (roomToBreak != roomID) {
						incorrectResponses[response].roomsToBreak[room] = roomToBreak;
						validRoom = true;
					}
				}
			}
			// move to the next item type
			iterator++;
		}

		rend.material.mainTexture = roomManager.whiteTex;

		if (roomID == 0)
		{
			Break();
		}
		else{
			isFixed = true;
		}
	}

	public void CheckItem() {
		Pickup.ItemType presentedItem = player.CurrentItem().CheckItemType();
		if (presentedItem == correctItem) {
			FixRoom();
		}
		else {
			// get a list of rooms to break and break them
			int[] roomsToBreak = incorrectResponses[(int)presentedItem].roomsToBreak;
			foreach (int roomNum in roomsToBreak) {
				roomManager.BreakRoom(roomNum);
			}
		}
		player.RespawnCurrentItem();
		GetComponentInChildren<ServicePort>().HidePopUp();
	}

	/// <summary>
	/// If the room has been fixed.
	/// </summary>
	/// <returns> True if it is fixed. </returns>
	public bool IsRoomFixed() {
		return isFixed;
	}

	/// <summary>
	/// Breaks the room.
	/// </summary>
	public void Break() {
		rend.material.mainTexture = roomManager.redTex;
		isFixed = false;
	}

	private void FixRoom()
	{
			// success the room is fixed
			isFixed = true;
			// Tell everyone the ship might be fixed.
			EventManager.PossibleCompletion();
			// Change to the greenTexture
			StartCoroutine(ShowGreenTex());
	}

	private IEnumerator ShowGreenTex()
	{
		rend.material.mainTexture = roomManager.greenTex;

		yield return new WaitForSeconds(greenTexDuration);

		rend.material.mainTexture = roomManager.whiteTex;

		yield return null;
	}

}
