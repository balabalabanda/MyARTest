using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{

    private AudioSource Do;
    private Ray forwardRay;
    private RaycastHit forwardRaycasHit;

    public bool isPlay;
    public bool canTrigger;

    // Use this for initialization
    void Start()
    {
        isPlay = false;
       


        Do = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        Play();
    }


    private void nextCubePlay()
    {
        forwardRay = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(forwardRay, out forwardRaycasHit, 1))//发出射线。
        {
            if (forwardRaycasHit.collider.gameObject.tag == "MusicCube")
            {
                forwardRaycasHit.collider.gameObject.GetComponent<MusicControl>().isPlay = true;
            }

        }
    }


    public void Play()
    {
        if (isPlay == true)
        {
            //GetComponent<MeshRenderer>().enabled = false;//发出音乐后消失。
            GetComponent<Renderer>().material.SetFloat("_emisssion", 1);
            Do.Play();

            Invoke("nextCubePlay", 0.5f);

            isPlay = false;

        }
    }
}


