using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;
using UnityEngine.SceneManagement;

public class ShoppingCHandler : MonoBehaviour
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
            fs = FlowerManager.Instance.GetFlowerSystem("ShoppingCScene");
            fs.Resume();
        }
        catch
        {
            fs = FlowerManager.Instance.CreateFlowerSystem("ShoppingCScene", false);
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
                    fs.ReadTextFromResource("Txtfiles/ShoppingCText1");
                    break;
                case 1:
                    fs.SetupButtonGroup();
                    fs.SetupButton("我們應該優先逛那些打折的店吧，這樣比較划算！", () => {
                        fs.Resume();
                        fs.RemoveButtonGroup();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmCQ3A1Action");
                        isLocked = false;
                    });
                    fs.SetupButton("我覺得應該根據地理位置來選，這樣我們可以節省時間。", () => {
                        fs.Resume();
                        fs.RemoveButtonGroup();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmCQ3A2Action");
                        isLocked = false;
                    });
                    fs.SetupButton("要不要隨意逛逛，按照直覺來走？", () => {
                        fs.Resume();
                        fs.RemoveButtonGroup();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmCQ3A3Action");
                        isLocked = false;
                    });
                    isLocked = true;
                    break;
                case 2:
                    fs.ReadTextFromResource("Txtfiles/ShoppingCText2");
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
            SceneManager.LoadScene("Mall_GarmentZoneCScene");
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
