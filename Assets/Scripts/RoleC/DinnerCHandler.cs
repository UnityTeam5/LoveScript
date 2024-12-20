using UnityEngine;
using UnityEngine.SceneManagement;
using Flower;
using Modules;

public class DinnerCHandler : MonoBehaviour
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
            fs = FlowerManager.Instance.GetFlowerSystem("DinnerCScene");
            fs.Resume();
        }
        catch
        {
            fs = FlowerManager.Instance.CreateFlowerSystem("DinnerCScene", false);
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
                    fs.ReadTextFromResource("Txtfiles/DinnerCText1");
                    break;
                case 1:
                    fs.SetupButtonGroup();
                    fs.SetupButton("我比較喜歡選擇排序，因為它簡單直接。", () => {
                        fs.Resume();
                        fs.RemoveButtonGroup();
                        fs.ReadTextFromResource("Txtfiles/SelectionSortCAction");
                        isLocked = false;
                    });
                    fs.SetupButton("快速排序效率更高，對於這麼多菜單選項應該更合適吧？", () => {
                        fs.Resume();
                        fs.RemoveButtonGroup();
                        fs.ReadTextFromResource("Txtfiles/QuickSortCAction");
                        isLocked = false;
                    });
                    fs.SetupButton("其實這種時候應該用二分搜尋法來縮小選擇範圍！", () => {
                        fs.Resume();
                        fs.RemoveButtonGroup();
                        fs.ReadTextFromResource("Txtfiles/BinarySearchCAction");
                        isLocked = false;
                    });
                    isLocked = true;
                    break;
                case 2:
                    fs.ReadTextFromResource("Txtfiles/DinnerCText2");
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
            SceneManager.LoadScene("MovieCScene");
        }
    }
}
