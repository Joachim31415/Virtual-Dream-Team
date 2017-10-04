using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	//private T() { }
	private static T instance;
	public static T Instance
	{
		get
		{
			//   
			if (!instance)
			{
				instance = (T)FindObjectOfType<T>();
			}

			if (!instance)
			{
				GameObject g = GameObject.FindGameObjectWithTag(typeof(T).ToString());
				if (g)
					instance = g.GetComponent<T>();
			}

			if (!instance)
			{
				GameObject g = GameObject.Find(typeof(T).ToString());
				if (g)
					instance = g.GetComponent<T>(); ;
			}

			if (!instance)
			{
				GameObject singleton = new GameObject();
				instance = singleton.AddComponent<T>();
				singleton.name = "" + typeof(T).ToString();
			}

			if (!instance)
			{
				Debug.LogError("UIManager - There is no UIManager GameObject");
			}

			return instance;
		}
	}
}
