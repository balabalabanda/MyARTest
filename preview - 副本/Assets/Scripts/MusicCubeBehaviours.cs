using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicCubeBehaviours : MonoBehaviour {

    public  enum CubeState
    {
        Adjust,
        play,
        idle,
    }

   
    private Material material;
    private GameObject createdDirectionLight;
    private GameStateManager gameStateManager;
    private int AdjustCubeCount;   
    private float opacityValue;
    private float opacityChangeSpeed;
    private float emisssionValue;

    public CubeState cubeState;
    public GameObject DirectionLight;
    public bool isHit;
	
	void Start () {
        material =  GetComponent<Renderer>().material;
        createdDirectionLight = Instantiate(DirectionLight, transform.position + transform.forward * 0.51f, transform.rotation, transform);
        cubeState = CubeState.Adjust;//初始化当前的Cube状态。
        gameStateManager = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();

        opacityValue = 0;
        opacityChangeSpeed = 1;
        emisssionValue =1;
        
        isHit = false;
    }
	

	void Update () {
        OpacityChange();
        IsHit();
        Debug.Log(cubeState);

        if (cubeState == CubeState.Adjust)
        {
            ActiveDirectionLight();
            ShowAdjustCubeMenu();
        }
        else
        {
            CloseAdjustCubeMenu();
            DestroyDirectionLight();
        }
       
        }
  



    private void OpacityChange()
    {
        if (opacityValue < 1)
        {
            opacityValue += Mathf.Lerp(0, 1, Time.deltaTime * opacityChangeSpeed);
            material.SetFloat("_opacity", opacityValue);
        }
    }

    private void IsHit()
    {
        if (isHit == true)
        {
            material.SetFloat("_emisssion", 1);
            isHit = false;
        }     
        if (material.GetFloat("_emisssion") > 0.5)
        {
            emisssionValue -= Mathf.Lerp(0, 1, Time.deltaTime * 1);
            material.SetFloat("_emisssion", emisssionValue);
        }
        else
        {
            emisssionValue =1;
        }
    }



    private void ActiveDirectionLight()
    {
        transform.Find("directionLight(Clone)").gameObject.SetActive(true);
    }

    public void DestroyDirectionLight()
    {
        transform.Find("directionLight(Clone)").gameObject.SetActive(false);
    }

    

    private void ShowAdjustCubeMenu()
    {      
            transform.Find("Canvas").gameObject.SetActive(true);
            //if (gesture.swipeVector.x>0)
            //{
            //    gameObject.transform.Rotate(Vector3.up, 90);
            //}
            //else if (gesture.swipeVector.x < 10)
            //{
            //    gameObject.transform.Rotate(Vector3.up, -90);
            //}

            ////if (gesture.swipeVector.y>0)
            ////{
            ////    gameObject.transform.Rotate(Vector3.right, 90);
            ////}
            ////else if (gesture.swipeVector.y<0)
            ////{
            ////    gameObject.transform.Rotate(Vector3.right, -90);
            ////}                           
    }   

    private void CloseAdjustCubeMenu()
    {
        transform.Find("Canvas").gameObject.SetActive(false);
    }


    public void RotateRight()
    {
        gameObject.transform.Rotate(Vector3.up, 90);
    }
    public void RotateLeft()
    {
        gameObject.transform.Rotate(Vector3.up, -90);
    }
    public void RotateForward()
    {
        gameObject.transform.Rotate(Vector3.right, -90);
    }
}
