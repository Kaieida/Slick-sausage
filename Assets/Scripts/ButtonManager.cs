using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] LaunchController launchController;
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject restartMenu;
    [SerializeField] GameObject finishMenu;
    [SerializeField] Transform startPos;
    [SerializeField] GameObject sausage;

    public void StartGame()
    {
        startMenu.SetActive(false);
        launchController.gameMode = LaunchController.GameMode.playing;
        StartCoroutine(launchController.ForceController());
    }

    public void RestartGame()
    {
        /*startMenu.SetActive(false);
        launchController.gameMode = LaunchController.GameMode.playing;
        sausage.transform.position = startPos.position;
        StartCoroutine(launchController.ForceController());*/
        SceneManager.LoadScene(0);
    }

    public void Finish()
    {
        finishMenu.SetActive(true);
        launchController.gameMode = LaunchController.GameMode.start;
    }

    public void Fail()
    {
        restartMenu.SetActive(true);
        launchController.gameMode = LaunchController.GameMode.start;
    }
}
