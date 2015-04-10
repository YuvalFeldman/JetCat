using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class FollowPath : MonoBehaviour
{

	string currentInterval = "Interval";
	int currentIntervalInt = 1;

	public enum FollowType
	{
		MoveTowards,
		Lerp
	}
	
	public FollowType Type = FollowType.MoveTowards;
	public PathDefinition Path;
	public PathDefinition Path2;
	public float Speed = 1;
	public float MaxDistanceToGoal = .1f;
	
	private IEnumerator<Transform> _currentPoint;
	
	public void Start()
	{
		if (Path == null)
		{
			Debug.LogError("Path cannot be null", gameObject);
			return;
		}

		_currentPoint = Path.GetPathEnumerator();
		_currentPoint.MoveNext();
		
		if (_currentPoint.Current == null)
			return;
		
		transform.position = _currentPoint.Current.position;
	}
	
	public void Update()
	{
		//Vector2 v = GetComponent<Rigidbody2D>().velocity;
		//float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
		//transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		if (_currentPoint.Current.tag.Equals ("last")) {
			Path = Path2;

			_currentPoint = Path.GetPathEnumerator();
			_currentPoint.MoveNext();
			//currentIntervalInt++;
			//GameObject pathObject = GameObject.Find (currentInterval + currentIntervalInt);
			//Path = pathObject.GetComponent<PathDefinition>();
		}

		if (_currentPoint == null || _currentPoint.Current == null) {
			return;
		}
		
		if (Type == FollowType.MoveTowards) {
			transform.position = Vector3.MoveTowards (transform.position, _currentPoint.Current.position, Time.deltaTime * Speed);
			transform.rotation = Quaternion.Lerp (transform.rotation, _currentPoint.Current.rotation, Time.deltaTime * 1);
		}
		else if (Type == FollowType.Lerp)
			transform.position = Vector3.Lerp(transform.position, _currentPoint.Current.position, Time.deltaTime * Speed);
		
		var distanceSquared = (transform.position - _currentPoint.Current.position).sqrMagnitude;
		if (distanceSquared < MaxDistanceToGoal * MaxDistanceToGoal)
			_currentPoint.MoveNext();
	}
}﻿