using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Platform : MonoBehaviour {
	public Transform prefab;
	public int numberOfObjects;
	public float recycleOffset;
	public Vector3 minSize, maxSize, minGrap, maxGrap;
	public float minY, maxY;
	
	private Vector3 nextPosition;
	private Transform thisTransform;
	private Queue<Transform> objectQueue;

	// Use this for initialization
	void Start () {
		thisTransform = transform;
		objectQueue = new Queue<Transform>(numberOfObjects);
		
		for(int i = 0; i < numberOfObjects; i++)
		{
			objectQueue.Enqueue((Transform)Instantiate(prefab));
		}
		
		nextPosition = thisTransform.localPosition;
		
		for(int i = 0; i < numberOfObjects; i++)
		{
			recycle ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(objectQueue.Peek().localPosition.x + recycleOffset < Runner.distanceTraveled)
		{
			recycle();
		}
	}
	
	private void recycle()
	{	
		Vector3 scale = new Vector3(Random.Range(minSize.x, maxSize.x), Random.Range(minSize.y, maxSize.y), Random.Range(minSize.z, maxSize.z));
		
		Vector3 position = nextPosition;
		position.x += scale.x * 0.5f;
		position.y += scale.y * 0.5f;
		
		Transform tmpObject = objectQueue.Dequeue();
		tmpObject.localPosition = position;
		tmpObject.localScale = scale;
		nextPosition.x += scale.x;
		objectQueue.Enqueue(tmpObject);
		
		nextPosition += new Vector3(Random.Range(minGrap.x, maxGrap.x) + scale.x, Random.Range(minGrap.y, maxGrap.y), Random.Range(minGrap.z, maxGrap.z));
		
		if(nextPosition.y < minY)
			nextPosition.y = minY + maxGrap.y;
		else if(nextPosition.y > maxY)
			nextPosition.y = maxY + maxGrap.y;
	}
		
}
