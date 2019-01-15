using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DynamicList : MonoBehaviour
{
	public ListItemObject listItemPrefab;

	private List<ListItemObject> listItemObjects = new List<ListItemObject> ();

	protected virtual void Awake ()
	{
		if (listItemPrefab == null)
			listItemPrefab = GetComponentInChildren<ListItemObject> ();

		listItemPrefab.gameObject.SetActive (false);
	}

	public void SetItems<T> (IEnumerable<T> itemDataList) where T : ListItemData
	{
        RemoveAllItems();
        foreach (ListItemData itemData in itemDataList)
        {
            AddItem(itemData);
        }
    }

    public void RemoveAllItems ()
	{
		while (listItemObjects.Count > 0) {
			RemoveItem (listItemObjects [0]);
		}
		listItemObjects.Clear ();
	}

	public void AddItem (ListItemData itemData)
	{
		ListItemObject listItem = Instantiate (listItemPrefab);
		listItem.transform.SetParent (listItemPrefab.transform.parent, false);
		listItem.gameObject.SetActive (true);
		listItem.SetData (itemData);
		listItemObjects.Add (listItem);
	}

	public void RemoveItem (ListItemObject itemObject)
	{
		if (itemObject != null) {
			Destroy (itemObject.gameObject);
			listItemObjects.Remove (itemObject);
		}
	}

	public List<T> GetItemDataList<T> () where T : ListItemData
	{
		var itemDataList = new List<T> ();
		foreach (ListItemObject obj in listItemObjects) {
			itemDataList.Add (obj.GetData<T> ());
		}
		return itemDataList;
	}


}
