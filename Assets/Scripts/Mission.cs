using UnityEngine;
using System.Collections;

public class Mission : ScriptableObject {

	public enum MissionType
	{
		Shoot,
		Pickup,
		Damage
	};

	public string missionName;
	public string description;
	public MissionType missionType;
	public int missionGoal;
	public int currentProgess;
	public bool IsComplete = false;

	//Use this for initialization
//	void Start () {
//
//	}
	
//	// Update is called once per frame
//	void Update () {
//		
//	}

	public bool IsMissionComplete(){
		if(currentProgess >= missionGoal)
		{
			return this.IsComplete = true;
		}
		return false;
	}

}




