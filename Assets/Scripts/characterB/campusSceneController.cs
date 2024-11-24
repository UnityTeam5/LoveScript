using UnityEngine;
using UnityEngine.SceneManagement;
using Flower;
 
public class campusSceneController : MonoBehaviour
{
    FlowerSystem fs;
    private int progress = 0;
    void Start()
    { 
        fs = FlowerManager.Instance.CreateFlowerSystem("campus", false);
        fs.SetupDialog();
        fs.ReadTextFromResource("campus");
    }

    void Update()
    {
        fs.SetupButtonGroup();
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            fs.Next();
            if(fs.isCompleted)
            {
                progress += 1;
            }
        }
        
        if(progress == 1)
        {
            fs.SetupButton("「對啊，就像我們去咖啡店排隊買咖啡，先來的就先點。」",()=>
            {
                fs.Resume();
                fs.RemoveButtonGroup();
                fs.ReadTextFromResource("respondCampus");
            });

            fs.SetupButton("「那如果是堆疊，應該是什麼樣的情境呢？」",()=>
            {
                fs.Resume();
                fs.RemoveButtonGroup();
            });

            fs.SetupButton("「佇列和堆疊的應用聽起來都很實用，有沒有更複雜的例子？」",()=>
            {
                fs.Resume();
                fs.RemoveButtonGroup();
            });
            progress+=1;
        }
    }
}
