using UnityEngine;
using System.Collections;
using UnityEngine.Cloud.Analytics;

public class UnityAnalyticsIntegration : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
		const string projectId = "e1e3a682-0d21-41f3-8368-163da3837405";
		UnityAnalytics.StartSDK (projectId);
		
	}
	
}
