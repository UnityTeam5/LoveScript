using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;
using UnityEngine.SceneManagement;

public class DailyLifeCHandler : MonoBehaviour
{
    FlowerSystem fs;
    private string RoleCName;
    private int progress = 0;
    private bool isGameEnd = false;
    private bool isLocked = false;
    void Start()
    {
        RoleCName = "角色C";

        fs = FlowerManager.Instance.CreateFlowerSystem("DailyLifeCScene", false);
        fs.SetupDialog();
        fs.SetupUIStage();
        fs.SetVariable("RoleCName", RoleCName);
    }

    void Update()
    {
        if (fs.isCompleted && !isGameEnd && !isLocked)
        {
            switch (progress)
            {
                case 0:
                    fs.ReadTextFromResource("Txtfiles/DailyLifeCText1");
                    break;
                default:
                    isGameEnd = true;
                    break;
            }
            progress++;
        }

        if(!isGameEnd)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                fs.Next();
            }
        }

        if (fs.isCompleted && isGameEnd)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
