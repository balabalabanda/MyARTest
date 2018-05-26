using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    private GameStateManager gameStateManager;
    private Camera maincamera;

    private float rotateSpeed;
	// Use this for initialization
	void Start () {
        gameStateManager = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
        maincamera = GetComponent<Camera>();
        rotateSpeed = 0.1f;
        maincamera.fieldOfView = 60;


    }
	
	// Update is called once per frame
	void Update () {
        
    }




    /// <summary>
    /// 旋转摄像机
    /// </summary>
    /// <param name="gesture"></param>
    public void Rotate(Gesture gesture)
    {
        if (gameStateManager.gameState == GameStateManager.GameState.ObserveMode|| gameStateManager.gameState == GameStateManager.GameState.SetMode)
        {
            if (transform.position.y>0)
            {
                transform.RotateAround(new Vector3(0, 0, 0), transform.right, -rotateSpeed * gesture.deltaPosition.y);
            }
            else if (gesture.deltaPosition.y<0)
            {
                transform.RotateAround(new Vector3(0, 0, 0), transform.right, -rotateSpeed * gesture.deltaPosition.y);
            }           //限制旋转视角不能到地底。
                       
            transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, rotateSpeed * gesture.deltaPosition.x);
        }           
    }


    /// <summary>
    /// 放大视角
    /// </summary>
    /// <param name="gesture"></param>
    public void Enlarge(Gesture gesture)
    {
        if (maincamera.fieldOfView>10)
        {
            maincamera.fieldOfView -= gesture.deltaPinch;
        }        
    }

    /// <summary>
    /// 缩小视角
    /// </summary>
    /// <param name="gesture"></param>
    public void Reduce(Gesture gesture)
    {
        if (maincamera.fieldOfView <60)
        {
            maincamera.fieldOfView += gesture.deltaPinch;
        }
    }
}
