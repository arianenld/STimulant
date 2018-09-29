using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints{

	public static Dictionary<string, List<Vector3>> waypoint;

	public void SetWaypoints(){
		waypoint = new Dictionary<string, List<Vector3>>();

		waypoint.Add("Urinary", new List<Vector3>(){  new Vector3(-55.43f, 1.16f, -267.04f),
													  new Vector3(-53.5f, -2.2f, -267.04f),
													  new Vector3(-52f, -9.5f, -267.04f),
													  new Vector3(-51.7f, -18.1f, -267.04f),
													  new Vector3(-50.3f, -21.9f, -267.04f),
													  new Vector3(-48.8f, -23.8f, -267.04f),
											      });

											      //-18, 2.2, -267.04;
		waypoint.Add("Urinary2",  new List<Vector3>(){  new Vector3(-18f, 2.2f, -267.04f),
														new Vector3(-20.6f, -4f, -267.04f),
														new Vector3(-22.6f, -6.8f, -267.04f),
														new Vector3(-26.2f, -8.1f, -267.04f),
														new Vector3(-28.1f, -14.1f, -267.04f),
														new Vector3(-29.7f, -20.1f, -267.04f),
														new Vector3(-30.4f, -25.2f, -267.04f),
														new Vector3(-31.5f, -30.6f, -267.04f),
											      });

		waypoint.Add("Brain",  new List<Vector3>(){ new Vector3(-28f, -1.4f, -383.1f),
													new Vector3(-34.29f, 0.62f, -383.1f),
													new Vector3(-31.62f, 6f, -383.1f),
													new Vector3(-21.27f, 6f, -383.1f),
													new Vector3(-23.17f, -0.41f, -383.1f),
													new Vector3(-26.8f, -2.31f, -383.1f),
													new Vector3(-28f, -1.4f, -383.1f),
											      });

		/*waypoint["Liver"] =  new List<Transform>(){ new Vector3(-55.43f, 1.16f, -267.04f),
													new Vector3(-53.5f, -2.2f, -267.04f),
													new Vector3(-52f, -9.5f, -267.04f),
													new Vector3(-51.7f, -18.1f, -267.04f),
													new Vector3(-50.3f, -21.9f, -267.04f),
													new Vector3(-48.8f, -23.8f, -267.04f),
											      };*/
	}

	public static List<Vector3> GetWaypoints(string s){
		//Debug.Log(waypoint);
		return waypoint[s];
	}
}
