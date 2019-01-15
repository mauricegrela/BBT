using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTurnOff : MonoBehaviour {
    [SerializeField]
    private float timeLeft;

    private bool IsCounting = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(IsCounting == true)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
            // GameOver();
            gameObject.SetActive(false);
            }
        }
	}

    public void ActivateCountDown()
    {
        IsCounting = true;
        Debug.Log("Reaching ActivateCount");
    }
}
