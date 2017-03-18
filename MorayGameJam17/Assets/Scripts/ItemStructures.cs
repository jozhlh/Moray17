using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemResponse
{
	//public Item.ItemType itemID;
	public int[] roomsToBreak;

	public void Initialise(int numberOfRoomsToBreak)
	{
		roomsToBreak = new int[numberOfRoomsToBreak];
	}
}
