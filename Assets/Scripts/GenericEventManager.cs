using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class GenericEvent<T,U,X> : UnityEvent<T,U,X>
{
}

//public class GenericDictionary<T,U,X>
//{
//	public Dictionary<string, GenericEvent<T,U,X>> genericEventDictionary = new 
//
//}

public class EventManager<T,U,X> : MonoBehaviour {

	private Dictionary<string, GenericEvent<T,U,X>> eventDictionary;

	private static EventManager<T,U,X> eventManager;

	public static EventManager<T,U,X> instance
	{
		get
		{
			if (!eventManager)
			{
				eventManager = FindObjectOfType (typeof (EventManager<T,U,X>)) as EventManager<T,U,X>;

				if (!eventManager)
				{
					Debug.LogError ("There needs to be one active EventManger script on a GameObject in your scene.");
				}
				else
				{
					eventManager.Init (); 
				}
			}

			return eventManager;
		}
	}

	void Init ()
	{
		if (eventDictionary == null)
		{
			eventDictionary = new Dictionary<string, GenericEvent<T,U,X>>();
		}
	}

	public static void StartListening (string eventName, UnityAction<T,U,X> listener)
	{
		GenericEvent<T,U,X> thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.AddListener (listener);
		} 
		else
		{
			thisEvent = new GenericEvent<T,U,X>();
			thisEvent.AddListener (listener);
			instance.eventDictionary.Add (eventName, thisEvent);
		}
	}

	public static void StopListening (string eventName, UnityAction<T,U,X>listener)
	{
		if (eventManager == null) return;
		GenericEvent<T,U,X> thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.RemoveListener (listener);
		}
	}

	public static void TriggerEvent (string eventName, T firstParam, U secondParam, X thirdParam)
	{
		GenericEvent<T,U,X> thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.Invoke (firstParam, secondParam, thirdParam);
		}
	}
}