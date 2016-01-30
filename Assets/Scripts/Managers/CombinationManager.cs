using UnityEngine;
using System.Collections;

public class CombinationManager : MonoBehaviour {
	private Combination[] combinations;

	void Awake(){
		combinations = GetComponents<Combination>();
	}

	/// <summary>
	/// Combine the specified firstItem and secondItem, or returns NULL if no combination is found
	/// </summary>
	/// <param name="firstItem">First item.</param>
	/// <param name="secondItem">Second item.</param>
	public IItem Combine(IItem firstItem, IItem secondItem){
		foreach (Combination c in combinations){
			if (c.firstItem == firstItem && c.secondItem == secondItem || c.firstItem == secondItem && c.secondItem == firstItem){
				return c.result;
			}
		}
		return null;
	}

}
