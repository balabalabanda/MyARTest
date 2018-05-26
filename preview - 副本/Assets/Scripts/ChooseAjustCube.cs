using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseAjustCube : MonoBehaviour {

    private GameStateManager.GameState lastGameState;
    private GameStateManager gameStateManager;
    // Use this for initialization
    void Start () {
        gameStateManager = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();//获取当前的游戏状态。
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeAjustState(Gesture gesture)
    {
        if (gameStateManager.gameState == GameStateManager.GameState.AdjustMode)
        {
            Ray newRay = Camera.main.ScreenPointToRay(gesture.position);
            RaycastHit newRaycastHit;
            if (Physics.Raycast(newRay, out newRaycastHit))
            {
                GameObject collidedCube = newRaycastHit.collider.gameObject;
                if (collidedCube.gameObject.tag == "MusicCube")
                {
                    if (collidedCube.GetComponent<MusicCubeBehaviours>().cubeState != MusicCubeBehaviours.CubeState.Adjust)
                    {
                        collidedCube.GetComponent<MusicCubeBehaviours>().cubeState = MusicCubeBehaviours.CubeState.Adjust;//改变所选Cube的物体状态。                           
                    }
                    else if (collidedCube.GetComponent<MusicCubeBehaviours>().cubeState == MusicCubeBehaviours.CubeState.Adjust)
                    {
                        collidedCube.GetComponent<MusicCubeBehaviours>().cubeState = MusicCubeBehaviours.CubeState.idle;                                          
                    }
                }
            }
        }       
    }
}
