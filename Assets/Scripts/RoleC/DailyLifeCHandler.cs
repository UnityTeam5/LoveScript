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
    private bool isPaused = false;

    void Start()
    {
        RoleCName = "角色C";
        try
        {
            fs = FlowerManager.Instance.GetFlowerSystem("DailyLifeCScene");
            fs.Resume();
        }
        catch
        {
            fs = FlowerManager.Instance.CreateFlowerSystem("DailyLifeCScene", false);
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
