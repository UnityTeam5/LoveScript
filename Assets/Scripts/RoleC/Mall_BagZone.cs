using UnityEngine;
using Flower;
using UnityEngine.SceneManagement;
using Modules;

public class ShoppingBaggageCHandler : MonoBehaviour
{
    private FlowerSystem fs;
    private PausedMenuHandler pausedMenuHandler;
    private string RoleCName;
    private int progress = 0;
    private bool isGameEnd = false;
    private bool isLocked = false;
    
    void Start()
    {
        RoleCName = "角色C";

        try
        {
            fs = FlowerManager.Instance.GetFlowerSystem("Mall_BagZoneCScene");
            fs.Resume();
        }
        catch
        {
            fs = FlowerManager.Instance.CreateFlowerSystem("Mall_BagZoneCScene", false);
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
                    fs.ReadTextFromResource("Txtfiles/Mall_BagZoneCText1");
                    break;
                case 1:
                    fs.SetupButtonGroup();
                    fs.SetupButton("我比較喜歡按顏色來挑，這樣搭配起來和諧。", () => {
                        fs.Resume();
                        fs.RemoveButtonGroup();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmCQ5A1Action");
                        isLocked = false;
                    });
                    fs.SetupButton("還是按大小排序吧，這樣能更快找到需要的容量。", () => {
                        fs.Resume();
                        fs.RemoveButtonGroup();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmCQ5A2Action");
                        isLocked = false;
                    });
                    fs.SetupButton("還是隨意挑選，也許能遇到意外的驚喜。", () => {
                        fs.Resume();
                        fs.RemoveButtonGroup();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmCQ5A3Action");
                        isLocked = false;
                    });
                    isLocked = true;
                    break;
                case 2:
                    fs.ReadTextFromResource("Txtfiles/Mall_BagZoneCText2");
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
            SceneManager.LoadScene("Mall_AccessoriesZoneCScene");
        }
    }
}
