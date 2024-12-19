using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;
using UnityEngine.SceneManagement;

public class Mall_AccessoriesZone : MonoBehaviour
{
    FlowerSystem fs;
    private string RoleCName;
    private int progress = 0;
    private bool isGameEnd = false;
    private bool isLocked = false;
    private bool isPaused = false;
    
    void Start()
    {
        RoleCName = "角色C";

        try
        {
            fs = FlowerManager.Instance.GetFlowerSystem("Mall_AccessoriesZoneCScene");
            fs.Resume();
        }
        catch
        {
            fs = FlowerManager.Instance.CreateFlowerSystem("Mall_AccessoriesZoneCScene", false);
            fs.SetupDialog();
            fs.SetupUIStage();
            fs.SetVariable("RoleCName", RoleCName);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key is pressed");
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if (fs.isCompleted && !isGameEnd && !isLocked)
        {
            switch (progress)
            {
                case 0:
                    fs.ReadTextFromResource("Txtfiles/Mall_AccessoriesZoneCText1");
                    break;
                case 1:
                    fs.SetupButtonGroup();
                    fs.SetupButton("我們可以按照飾品的類型來挑選，先選耳環，再選項鍊。", () => {
                        fs.Resume();
                        fs.RemoveButtonGroup();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmCQ6A1Action");
                        isLocked = false;
                    });
                    fs.SetupButton("先挑一件最吸引人的，接著逐一搭配。", () => {
                        fs.Resume();
                        fs.RemoveButtonGroup();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmCQ6A2Action");
                        isLocked = false;
                    });
                    fs.SetupButton("要不要隨興選幾件飾品，隨意搭配？", () => {
                        fs.Resume();
                        fs.RemoveButtonGroup();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmCQ6A3Action");
                        isLocked = false;
                    });
                    isLocked = true;
                    break;
                case 2:
                    fs.ReadTextFromResource("Txtfiles/Mall_AccessoriesZoneCText2");
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
            SceneManager.LoadScene("DailyLifeCScene");
        }
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        SetupPauseMenu();
    }

    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        fs.RemoveButtonGroup();
    }

    void SetupPauseMenu()
    {
        fs.SetupButtonGroup();
        fs.SetupButton("繼續", () => {
            ResumeGame();
        });
        fs.SetupButton("返回主畫面", () => {
            Time.timeScale = 1;
            fs.ReadTextFromResource("Txtfiles/BackToSubMenu");
            fs.RemoveButtonGroup();
            SceneManager.LoadScene("SubMenu");
        });

        fs.SetupButton("重新此場景", () => {
            Time.timeScale = 1;
            fs.RemoveButtonGroup();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
    }
}
