﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
	private RoomControl[] rooms;

	// Get all rooms that are children of the room manager
	// Initialise them with their room number
	void Start ()
	{
		rooms = GetComponentsInChildren<RoomControl>();
		Debug.Log("rooms: " + rooms.Length);
		for (int i = 0; i < rooms.Length; i++)
		{
			rooms[i].Initialise(i);
		}
	}

	public int NumberOfRooms()
	{
		return rooms.Length;
	}

	public void BreakRoom(int roomNum)
	{
		rooms[roomNum].Break();
	}
}
