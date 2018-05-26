using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSelection : MonoBehaviour {

    public GameObject modeOption;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectMode()
    {
        if (modeOption.activeSelf == false )
        {
            modeOption.SetActive(true);
        }
        else
        {
            modeOption.SetActive(false);
        }       
    }
}
