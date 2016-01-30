using UnityEngine;
using System.Collections;

/// <summary>
/// A stage represents a selection of an item
/// </summary>
public class Stage : MonoBehaviour {
	/// <summary>
	/// The time required to accomplish the task before losing health
	/// </summary>
	public float maxTime;

	/// <summary>
	/// The suggestion the spirit gives to the player
	/// </summary>
	public Suggestion suggestion;
	/// <summary>
	/// The required item.
	/// </summary>
	public Item requiredItem;

	public bool isLost;
	public bool isFinished;


	//TODO: Implement methods

}
