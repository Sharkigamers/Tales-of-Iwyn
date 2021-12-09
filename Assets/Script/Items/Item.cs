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
	public string ItemName = "New Item";
	public Sprite Icon = null;

	[Range(1,999)]
	public int MaximumStacks = 1;
}
