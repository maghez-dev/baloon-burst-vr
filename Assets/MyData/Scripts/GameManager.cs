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
    }

    public void GameOver()
    {
        // Game stopping
        GameObject.FindGameObjectWithTag("Shooter").GetComponent<BaloonShooter>().enabled = false;
        StartCoroutine(Teleport());

        foreach (GameObject baloon in GameObject.FindGameObjectsWithTag("Baloon"))
        {
            Destroy(baloon);
        }

        // Popup score screen
        GameObject.FindGameObjectWithTag("GameOver").GetComponent<GameOver>().ShowGameOverWindow();
    }

    public void StartPos()
    {
        TeleportTo(_greenMat);
    }

    private IEnumerator Teleport()
    {
        GameObject.FindGameObjectWithTag("Transitions").GetComponent<Animator>().SetTrigger("FadeOut");

        yield return new WaitForSeconds(1f);

        TeleportTo(_greenMat);
        GameObject.FindGameObjectWithTag("Transitions").GetComponent<Animator>().SetTrigger("FadeIn");
    }
}