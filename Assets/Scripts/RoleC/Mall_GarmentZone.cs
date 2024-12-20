using UnityEngine;
using Flower;
using UnityEngine.SceneManagement;
using Modules;

public class Mall_GarmentZone : MonoBehaviour
{
    private FlowerSystem fs;
    private PausedMenuHandler pausedMenuHandler;
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
            fs = FlowerManager.Instance.GetFlowerSystem("Mall_GarmentZoneCScene");
            fs.Resume();
        }
        catch
        {
            fs = FlowerManager.Instance.CreateFlowerSystem("Mall_GarmentZoneCScene", false);
            fs.SetupDialog();
            fs.SetVariable("RoleCName", RoleCName);
        }

        pausedMenuHandler = new PausedMenuHandler(fs);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausedMenuHandler.TogglePause();
        }

        if (fs.isCompleted && !isGameEnd && !isLocked)
        {
            switch (progress)
            {
                case 0:
                    fs.ReadTextFromResource("Txtfiles/Mall_GarmentZoneCText1");
                    break;
                case 1:
                    fs.SetupButtonGroup();
                    fs.SetupButton("那我們先挑個幾件試試搭配吧！", () => {
                        fs.Resume();
                        fs.RemoveButtonGroup();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmCQ4A1Action");
                        isLocked = false;
                    });
                    fs.SetupButton("可以用窮舉法來試穿，不過這可能會花些時間。", () => {
                        fs.Resume();
                        fs.RemoveButtonGroup();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmCQ4A2Action");
                        isLocked = false;
                    });
                    fs.SetupButton("要不先用貪婪演算法試試，挑出最顯眼的幾件？", () => {
                        fs.Resume();
                        fs.RemoveButtonGroup();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmCQ4A3Action");
                        isLocked = false;
                    });
                    isLocked = true;
                    break;
                case 2:
                    fs.ReadTextFromResource("Txtfiles/Mall_GarmentZoneCText2");
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
            SceneManager.LoadScene("Mall_BagZoneCScene");
        }
    }
}
