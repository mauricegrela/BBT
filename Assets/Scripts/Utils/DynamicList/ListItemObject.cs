using UnityEngine;
using System.Collections;

public abstract class ListItemObject : MonoBehaviour
{
	private ListItemData data;

	public T GetData<T>() where T : ListItemData
	{
		return (T)data;
	}

	public virtual void SetData(ListItemData _data)
	{
		data = _data;
	}
}
