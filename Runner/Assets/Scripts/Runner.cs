using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {
	private Transform thisTransform;
	
	public static float distanceTraveled;

	// Use this for initialization
	void Start () {
		thisTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		thisTransform.Translate(5f * Time.deltaTime, 0, 0);
		distanceTraveled = thisTransform.localPosition.x;
	}
}
