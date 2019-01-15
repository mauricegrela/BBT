using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AccelerometerTest : MonoBehaviour {


    public float Inverterx;
    public float Invertery;
    [SerializeField]
    private Text TextRef;
    private float PrevStep;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 dir = Vector3.zero;

        // we assume that device is held parallel to the ground
        // and Home button is in the right hand

        // remap device acceleration axis to game coordinates:
        //  1) XY plane of the device is mapped onto XZ plane
        //  2) rotated 90 degrees around Y axis
        dir.x = Input.acceleration.x*Inverterx;
        dir.y = Input.acceleration.y* Inverterx;

        // clamp acceleration vector to unit sphere
        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        // Make it move 10 meters per second instead of 10 meters per frame...
        dir *= Time.deltaTime;


        // Move object
        transform.Translate(dir * 10);    
        
        // initially, the temporary vector should equal the player's position
        Vector3 clampedPosition = transform.localPosition;
        // Now we can manipulte it to clamp the y element
        clampedPosition.y = Mathf.Clamp(transform.localPosition.y, -100.1f, 100.1f);
        clampedPosition.x = Mathf.Clamp(transform.localPosition.x, -100.1f, 100.1f);
        // re-assigning the transform's position will clamp it
        transform.localPosition = clampedPosition;


	}
}
