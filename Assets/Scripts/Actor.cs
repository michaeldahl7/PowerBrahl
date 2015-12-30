using UnityEngine;
using System.Collections;
using System;
 

public class Actor : MonoBehaviour {

}
//	public int xRemainder;
//
//	// Use this for initialization
//	void Start () {
//	
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
//
////	public void MoveX(float amount, Action onCollide)
////	{
////		xRemainder += amount;
////		int move = Mathf.Round(xRemainder);
////		
////		if (move != 0)
////		{
////			xRemainder -= move;
////			int sign = Mathf.Sign(move);
////			
////			while (move != 0)
////			{
////				if (!collideAt(&ldquo;solids&rdquo;, Position + new Vector2(sign, 0))
////				    {
////					//No solid immediately beside us
////					Position.X += sign;
////					move -= sign;
////				}
////				else
////				{
////					//Hit a solid!
////					if (onCollide != null)
////						onCollide();
////					break;
////				}
////			}
////		}
////	}
//
//	public void MoveX(float amount, Action onCollide)
//	{
//		xRemainder += amount;
//		int move = Mathf.Round(xRemainder);
//		
//		if (move != 0)
//		{
//			xRemainder -= move;
//			int sign = Sign(move);
//			
//			while (move != 0)
//			{
//				//if (!collideAt("Solid", Position + new Vector2(sign, 0))
//				    {
//					//No solid immediately beside us
//				//	transform.position.x += sign;
//					//move -= sign;
//			//	}
////				else
////				{
////					//Hit a solid!
////					if (onCollide != null)
////						onCollide();
////					break;
//			}
//				}
//				}
//				}
//
//////	/*/*public*/*/ virtual bool IsRiding(Solid solid){
////	/////	return false;
////	//}
////	public virtual void Squish(){
////
////	}
//}
