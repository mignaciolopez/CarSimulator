using UnityEngine;

public class Tire : MonoBehaviour {

	public float RestingWeight { get; set; }
	public float ActiveWeight { get; set; }
	public float Grip { get; set; }
	public float FrictionForce { get; set; }
	public float AngularVelocity { get; set; }
	public float Torque { get; set; }

	public float Radius = 0.5f;

	float TrailDuration = 5;
	bool TrailActive;
	[SerializeField] GameObject skidmarkPrefab;
	GameObject Skidmark;

	public void SetTrailActive(bool active) {
		if (active && !TrailActive) {
			// These should be pooled and re-used
			Skidmark = Instantiate(skidmarkPrefab, transform, false);
		} else if (!active && TrailActive) {			
			Skidmark.transform.parent = null;
			GameObject.Destroy (Skidmark.gameObject, TrailDuration); 
		}
		TrailActive = active;
	}

}
