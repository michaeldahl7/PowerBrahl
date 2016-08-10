using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Required when using Event data.
// hex color of taken 383434B8
public class CharacterSelectionManager : MonoBehaviour
{
//	public bool isDazzleyDisplayed;
//	public bool isAdventureyDisplayed;
//	public bool isNobleyDisplayed;
//	public bool isArcaneyDisplayed;

	public RectTransform heroImageLocation;
	public HeroSelectionPanelComponent leftCharacterSelectPanel;
	public HeroSelectionPanelComponent rightCharacterSelectPanel;
	public HeroImageObject[] heroImageObjectContainer;
	public Sprite[] listOfHeroSprites;
	// Use this for initialization




//	public void leftArrowChange (HeroImageObject obj)
//	{
//		switch (obj.characterType) {
//		case HeroImageObject.characterTypeEnum.adventurey:
//			{
//				return;
//			}
//		case HeroImageObject.characterTypeEnum.dazzley:
//			{
//				return;
//			}
//		case HeroImageObject.characterTypeEnum.arcaney:
//			{
//				return;
//			}
//		case HeroImageObject.characterTypeEnum.nobley:
//			{
//				return;
//			}
//		} 
//		//sprite = sprite previous of this sprite that is available
//		Debug.Log ("left arrow");
//	}

	public void leftArrowChange (HeroImageObject obj){
		
	}

	public void rightArrowChange ()
	{
		//sprite = sprite after this sprite that is available
		Debug.Log ("right arrow");
	}

	public void assignNavigationDirections (HeroImageObject obj)
	{

	}



}
