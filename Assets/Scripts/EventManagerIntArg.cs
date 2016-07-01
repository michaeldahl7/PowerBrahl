using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class IntArgEvent : UnityEvent<int>
{
}

public class EventManagerIntArg : MonoBehaviour {

	private Dictionary <string, IntArgEvent> eventDictionary;

	private static EventManagerIntArg eventManagerIntArg;

	public static EventManagerIntArg instance
	{
		get
		{
			if (!eventManagerIntArg)
			{
				eventManagerIntArg = FindObjectOfType (typeof (EventManagerIntArg)) as EventManagerIntArg;

				if (!eventManagerIntArg)
				{
					Debug.LogError ("There needs to be one active EventManger script on a GameObject in your scene.");
				}
				else
				{
					eventManagerIntArg.Init ();
				}
			}

			return eventManagerIntArg;
		}
	}

	void Init ()
	{
		if (eventDictionary == null)
		{
			eventDictionary = new Dictionary<string, IntArgEvent>();
		}
	}

	public static void StartListening(string eventName, UnityAction<int> listener){
		IntArgEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.AddListener (listener);
		}
		else
		{
			thisEvent = new IntArgEvent();
			thisEvent.AddListener (listener);
			instance.eventDictionary.Add (eventName, thisEvent);
		}
	}

	public static void StopListening(string eventName, UnityAction<int> listener){
		if (eventManagerIntArg == null) return;
		IntArgEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.RemoveListener (listener);
		}
	}

	public static void TriggerEvent(string eventName, int value){
		IntArgEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.Invoke (value);
		}
	}
}