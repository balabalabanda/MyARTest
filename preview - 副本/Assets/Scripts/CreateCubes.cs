using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateCubes : MonoBehaviour {

    private Ray newRay;
    private RaycastHit newRaycastHit;
    private Vector3 targetPosition;
    private GameObject createCube;
    private GameObject exampleCube;
    private GameObject examplingCube;   
    private GameObject newCube;
    private GameStateManager gameStateManager;
    private bool isSetMode;

   

    public GameObject DoCube;
    public GameObject ReCube;
    public GameObject MiCube;
    public GameObject FaCube;
    public GameObject SoCube;
    public GameObject LaCube;
    public GameObject XiCube;
    public GameObject StartCube;
    public GameObject ChangeModeButtonText;

  

    // Use this for initialization
    void Start () {

        createCube = DoCube;
        exampleCube = createCube;
        examplingCube =  Instantiate(exampleCube, new Vector3(0, 50, 0), Quaternion.identity);     
        gameStateManager = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
        isSetMode = false;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (examplingCube.tag!="StartCube")
        {
            if (examplingCube.GetComponent<MusicCubeBehaviours>().cubeState != MusicCubeBehaviours.CubeState.idle)
            {
                examplingCube.GetComponent<MusicCubeBehaviours>().cubeState = MusicCubeBehaviours.CubeState.idle;
            }
        }
        
        examplingCube.transform.Rotate(0, 10*Time.deltaTime, 0);      
      
                
	}

    

    /// <summary>
    /// 生成新的方块
    /// </summary>
    public void CreateCube(Gesture gesture)
    {
        if (gameStateManager.gameState == GameStateManager.GameState.SetMode)
        {
            newRay = Camera.main.ScreenPointToRay(gesture.position);
            if (Physics.Raycast(newRay, out newRaycastHit))
            {               
                       
                if (newRaycastHit.collider.gameObject.tag == "MusicCube" || newRaycastHit.collider.gameObject.tag == "BaseCube")
                {
                    if (newRaycastHit.collider.gameObject.tag == "MusicCube")
                    {
                        newRaycastHit.collider.gameObject.GetComponent<MusicCubeBehaviours>().isHit = true;                                      
                    }

                   

                    if (newRaycastHit.collider.gameObject.tag == "BaseCube")
                    {
                        newRaycastHit.collider.gameObject.GetComponent<BaseCubeBehaviours>().isHit = true;
                    }
                    targetPosition = newRaycastHit.collider.gameObject.transform.position;
                }


                //实例化新的方块。
                if (!Physics.Raycast(targetPosition, Vector3.up, 1)&&(newRaycastHit.collider.gameObject.tag =="MusicCube"|| newRaycastHit.collider.gameObject.tag == "BaseCube"))
                {
                    Quaternion lastCubeQuaternion = Quaternion.identity;//设定生成方块的初始旋转。
                    if (newCube != null && (newCube.tag == "MusicCube"||newCube.tag=="CreatedCube"))
                    {                      
                        newCube.tag = "MusicCube";                                                        
                        newCube.GetComponent<MusicCubeBehaviours>().cubeState = MusicCubeBehaviours.CubeState.idle;
                        lastCubeQuaternion = newCube.transform.rotation;//将上一个方块的初始旋转传递给下一个方块。
                    }                                      
                    newCube = Instantiate(createCube, targetPosition + new Vector3(0, 1, 0), lastCubeQuaternion, this.transform);//实例化方块   
                    if (newCube.tag !="StartCube")
                    {
                        newCube.tag = "CreatedCube";
                    }                                                                                                                                    
                }
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (newRaycastHit.collider.tag == "CreatedCube")//确定刚生成的方块。
                {
                    newRaycastHit.collider.gameObject.GetComponent<MusicCubeBehaviours>().cubeState = MusicCubeBehaviours.CubeState.idle;
                    newRaycastHit.collider.gameObject.tag = "MusicCube";
                }
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            }
        }      
    }

  
    



    





    /// <summary>
    /// 改变将要创建的音乐方块。
    /// </summary>
    public void ChangeDoCube()
    {
        createCube = DoCube;
        exampleCube = createCube;
        Destroy(examplingCube);
        examplingCube = Instantiate(exampleCube, new Vector3(0, 50, 0), Quaternion.identity);

    }

    public void ChangeReCube()
    {
        createCube = ReCube;
        exampleCube = createCube;
        Destroy(examplingCube);
        examplingCube = Instantiate(exampleCube, new Vector3(0, 50, 0), Quaternion.identity);
    }

    public void ChangeMiCube()
    {
        createCube = MiCube;
        exampleCube = createCube;
        Destroy(examplingCube);
        examplingCube = Instantiate(exampleCube, new Vector3(0, 50, 0), Quaternion.identity);
    }
    public void ChangeFaCube()
    {
        createCube = FaCube;
        exampleCube = createCube;
        Destroy(examplingCube);
        examplingCube = Instantiate(exampleCube, new Vector3(0, 50, 0), Quaternion.identity);
    }
    public void ChangeSoCube()
    {
        createCube = SoCube;
        exampleCube = createCube;
        Destroy(examplingCube);
        examplingCube = Instantiate(exampleCube, new Vector3(0, 50, 0), Quaternion.identity);
    }
    public void ChangeLaCube()
    {
        createCube = LaCube;
        exampleCube = createCube;
        Destroy(examplingCube);
        examplingCube = Instantiate(exampleCube, new Vector3(0, 50, 0), Quaternion.identity);
    }
    public void ChangeXiCube()
    {
        createCube = XiCube;
        exampleCube = createCube;
        Destroy(examplingCube);
        examplingCube = Instantiate(exampleCube, new Vector3(0, 50, 0), Quaternion.identity);
    }
    public void ChangeStartCube()
    {
        createCube =StartCube;
        exampleCube = createCube;
        Destroy(examplingCube);
        examplingCube = Instantiate(exampleCube, new Vector3(0, 50, 0), Quaternion.identity);
    }
}
