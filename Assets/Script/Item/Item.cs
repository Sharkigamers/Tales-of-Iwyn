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
	public string ItemName;
	public Sprite Icon;

	[Range(1,999)]
	public int MaximumStacks = 1;
}
