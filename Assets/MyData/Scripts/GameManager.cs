using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Material _redMat;
    [SerializeField] private Material _greenMat;
    [SerializeField] private Material _blueMat;


    public void TeleportTo(Material mat)
    {
        FollowCameraPosition playerPos = GameObject.FindGameObjectWithTag("PlayerPos").GetComponent<FollowCameraPosition>();

        if (mat.color == _redMat.color)
        {
            playerPos.FixPosition(GameObject.FindGameObjectWithTag("RedCam").GetComponent<Transform>());
        }
        else if (mat.color == _greenMat.color)
        {
            playerPos.FixPosition(GameObject.FindGameObjectWithTag("GreenCam").GetComponent<Transform>());
        }
        else if (mat.color == _blueMat.color)
        {
            playerPos.FixPosition(GameObject.FindGameObjectWithTag("BlueCam").GetComponent<Transform>());
        }

        /*
        if (mat.color == _redMat.color)
        {
            GameObject.FindGameObjectWithTag("PlayerPos").GetComponent<Transform>().position =
                GameObject.FindGameObjectWithTag("RedCam").GetComponent<Transform>().position;
            GameObject.FindGameObjectWithTag("PlayerPos").GetComponent<Transform>().rotation =
                GameObject.FindGameObjectWithTag("RedCam").GetComponent<Transform>().rotation;
        } else if (mat.color == _greenMat.color)
        {
            GameObject.FindGameObjectWithTag("PlayerPos").GetComponent<Transform>().position =
                GameObject.FindGameObjectWithTag("GreenCam").GetComponent<Transform>().position; ;
            GameObject.FindGameObjectWithTag("PlayerPos").GetComponent<Transform>().rotation =
                GameObject.FindGameObjectWithTag("GreenCam").GetComponent<Transform>().rotation;
        } else if (mat.color == _blueMat.color)
        {
            GameObject.FindGameObjectWithTag("PlayerPos").GetComponent<Transform>().position =
                GameObject.FindGameObjectWithTag("BlueCam").GetComponent<Transform>().position; ;
            GameObject.FindGameObjectWithTag("PlayerPos").GetComponent<Transform>().rotation =
                GameObject.FindGameObjectWithTag("BlueCam").GetComponent<Transform>().rotation;
        }
        */
    }


    public void StartPos()
    {
        TeleportTo(_greenMat);
    }
}