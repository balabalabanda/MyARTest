using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCubes : MonoBehaviour {


    private Ray newRay;
    private RaycastHit newRaycastHit;
    private Transform targetTransform;

    public AudioClip BreakAudio;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {           
      
	}

    public void DestroyCube(Gesture gesture)
    {
        newRay = Camera.main.ScreenPointToRay(gesture.position);
        if (Physics.Raycast(newRay, out newRaycastHit))
        {
            
            if (newRaycastHit.collider.gameObject.tag == "MusicCube"|| newRaycastHit.collider.gameObject.tag == "StartCube") 
            {

                AudioSource.PlayClipAtPoint(BreakAudio, newRaycastHit.collider.gameObject.transform.position);
                Destroy(newRaycastHit.collider.gameObject);

            }           
        }
    }

    public void DestroyAllCube()
    {
        Transform[] childrenTransfrom = GetComponentsInChildren<Transform>();
        for (int i = 1; i < childrenTransfrom.Length; i++)
        {
            Destroy(childrenTransfrom[i].gameObject);
        }        
    }
}
