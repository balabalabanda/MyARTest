using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCubeBehaviours : MonoBehaviour {
    private Material material;
    
    private float emisssionValue;

    public bool isHit;
    // Use this for initialization
    void Start () {
        material = GetComponent<Renderer>().material;

       
        emisssionValue = 1;
        isHit = false;
    }
	
	// Update is called once per frame
	void Update () {
        IsHit();
    }

    private void IsHit()
    {
        if (isHit == true)
        {
            material.SetFloat("_emisssion", 1);
            isHit = false;
        }
        if (material.GetFloat("_emisssion") > 0.2)
        {
            emisssionValue -= Mathf.Lerp(0, 1, Time.deltaTime * 1);
            material.SetFloat("_emisssion", emisssionValue);
        }
        else
        {
            emisssionValue = 1;
        }      
    }
}
