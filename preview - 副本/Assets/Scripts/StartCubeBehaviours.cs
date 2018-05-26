using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCubeBehaviours : MonoBehaviour {

    private Ray forwardRay;
    private RaycastHit forwardRaycasHit;
    // Use this for initialization
    void Start () {
        nextCubePlay();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void nextCubePlay()//向各个方向发出信号射线开始音乐。
    {
        forwardRay = new Ray(transform.position, new Vector3(1,0,0));
        if (Physics.Raycast(forwardRay, out forwardRaycasHit, 1))//发出射线。
        {
            if (forwardRaycasHit.collider.gameObject.tag == "MusicCube")
            {
                forwardRaycasHit.collider.gameObject.GetComponent<MusicControl>().isPlay = true;
            }
        }
        forwardRay = new Ray(transform.position, new Vector3(0,0,1));
        if (Physics.Raycast(forwardRay, out forwardRaycasHit, 1))//发出射线。
        {
            if (forwardRaycasHit.collider.gameObject.tag == "MusicCube")
            {
                forwardRaycasHit.collider.gameObject.GetComponent<MusicControl>().isPlay = true;
            }
        }
        forwardRay = new Ray(transform.position, new Vector3(0, 0, -1));
        if (Physics.Raycast(forwardRay, out forwardRaycasHit, 1))//发出射线。
        {
            if (forwardRaycasHit.collider.gameObject.tag == "MusicCube")
            {
                forwardRaycasHit.collider.gameObject.GetComponent<MusicControl>().isPlay = true;
            }
        }
        forwardRay = new Ray(transform.position, new Vector3(-1, 0, 0));
        if (Physics.Raycast(forwardRay, out forwardRaycasHit, 1))//发出射线。
        {
            if (forwardRaycasHit.collider.gameObject.tag == "MusicCube")
            {
                forwardRaycasHit.collider.gameObject.GetComponent<MusicControl>().isPlay = true;
            }
        }
    }
}
