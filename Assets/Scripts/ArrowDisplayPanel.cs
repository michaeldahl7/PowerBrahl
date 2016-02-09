using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ArrowDisplayPanel : MonoBehaviour {
    public Image arrowOneImage;
    public Image arrowTwoImage;
    public Image arrowThreeImage;
    public Image arrowFourImage;
    public int arrowIndex = 3;
    public PowerBrahlManager PBmanager;

    public List<Image> arrowImageList = new List<Image>();      //dont know if i need a list might just use four seperate images
	// Use this for initialization
	void Start () {
        PBmanager = GetComponent<PowerBrahlManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable()
    {
        
    }


    void OnDisable()
    {
        
    }
    void  AdjustDisplayedArrows(int number)
    {
        switch (number)
        {
            case 1:
                if(arrowIndex < 3)
                { 
                    arrowImageList[arrowIndex].enabled = false;
                }
                break;
            case -1:
                break;
            default:
                break;
        }
        
    }
}
