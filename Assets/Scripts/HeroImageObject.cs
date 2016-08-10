using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HeroImageObject : MonoBehaviour {

	public RectTransform rectTransform;
	public Image characterImage;
	public enum characterTypeEnum { adventurey, dazzley, nobley, arcaney};
	public characterTypeEnum characterType;
	public bool isCurrentlyDisplayed;
	// Use this for initialization

}
