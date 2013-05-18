using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {
	private Transform thisTransform;
	private bool touchingPlatform;
	
	public static float distanceTraveled;
	public float acceleration;
	public Vector3 jumpVelocity;

	// Use this for initialization
	void Start ()
	{
		thisTransform = transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(touchingPlatform && Input.GetButtonDown("Jump"))
		{
			rigidbody.AddForce(jumpVelocity, ForceMode.VelocityChange);
			touchingPlatform = false;
			
		}
		distanceTraveled = thisTransform.localPosition.x;
	}
	
	void FixedUpdate()
	{
		if(touchingPlatform)
		{
			rigidbody.AddForce(acceleration, 0f, 0f, ForceMode.Acceleration);
		}
	}
	
	void OnCollisionEnter()
	{
		touchingPlatform = true;
	}
	
	void OnCollisionExit()
	{
		touchingPlatform = false;
	}
}
