using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Item")]
public class Item : ScriptableObject
{
	[SerializeField] string id;
	public string ID {
        get {
            return id;
        }
    }
	new public string ItemName = "New Item";
	public Sprite icon = null;

	[Range(1,999)]
	public int MaximumStacks = 1;
	
	// Called when the item is pressed in the inventory
	public virtual void Use ()
	{
		// Use the item
		// Something might happen

		Debug.Log("Using " + name);
	}

	public void RemoveFromInventory ()
	{
		Inventory.instance.Remove(this);
	}
}
