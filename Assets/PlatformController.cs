using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {

    [SerializeField]
    int moveDistance = 3;
    [SerializeField]
    float moveSpeed = 2;
    Vector3 position;

    // Use this for initialization
    void Start () {
        position = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (position != null) {
            position.x += moveSpeed * Time.deltaTime;
            transform.position = position;
        }

        if (position.x < -moveDistance)
            moveSpeed = Mathf.Abs(moveSpeed);
        else if (position.x > moveDistance)
            moveSpeed = -Mathf.Abs(moveSpeed);
	}
}
