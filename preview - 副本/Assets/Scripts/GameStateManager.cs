using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour {


    public GameObject CurrentModeButtonText;
    public enum GameState
    {
        SetMode,
        ObserveMode,
        AdjustMode,
    }

    public GameState gameState;
	// Use this for initialization
	void Start () {
        gameState = GameState.ObserveMode;
	}
	
	// Update is called once per frame
	void Update()
    {
        Debug.Log(gameState);
    }

    /// <summary>
    /// 改变当前是否为放置方块模式还是观察模式。
    /// </summary>
    public void ChangeSetMode()
    {       
        gameState = GameState.SetMode;
        CurrentModeButtonText.GetComponent<Text>().text = "放置模式";
    }
    public void ChangeObserveMode()
    {
        gameState = GameState.ObserveMode;
        CurrentModeButtonText.GetComponent<Text>().text = "观察模式";
    }
    public void ChangeAdjustMode()
    {
        gameState = GameState.AdjustMode;
        CurrentModeButtonText.GetComponent<Text>().text = "调整模式";
    }    
}
