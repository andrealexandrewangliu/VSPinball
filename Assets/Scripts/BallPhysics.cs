using UnityEngine;
using System.Collections;

public class BallPhysics : MonoBehaviour {
	public float gravity = 0.5f;
	private Rigidbody2D ballrigidbody;

	// Use this for initialization
	void Start () {
		ballrigidbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.localPosition.y > 0) {
			ballrigidbody.gravityScale = -gravity;
		}
		else if (transform.localPosition.y < 0) {
			ballrigidbody.gravityScale = gravity;
		}

	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag.Equals("EndPoint")){
			coll.gameObject.GetComponent<Endbox>().ballEnter(gameObject);
			ballrigidbody.velocity = new Vector2(0,0);
		}
	}
}
