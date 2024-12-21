using UnityEngine;
using Flower;
using System;
using UnityEngine.SceneManagement;
using Modules;

public class ParkBenchA : MonoBehaviour
{   
    private FlowerSystem fs;
    private PausedMenuHandler pausedMenuHandler;
    private int progress = 0;
    private bool isGameEnd = false;
    private bool isLocked = false;
    private String RoleAname;
    private String myname;

    void Start(){
        RoleAname = "我老婆";
        myname = "我";
        try
        {
            fs = FlowerManager.Instance.GetFlowerSystem("RoleAFlowerSystem");
            fs.Resume();
        }
        catch
        {
            fs = FlowerManager.Instance.CreateFlowerSystem("RoleAFlowerSystem",false);
            fs.SetupDialog();
            fs.SetVariable("RoleA",RoleAname);
            fs.SetVariable("myname",myname);
        }
        pausedMenuHandler = new PausedMenuHandler(fs);
    }

    // Update is called once per frame
    void Update(){   
        if(fs.isCompleted && !isGameEnd && !isLocked){
            switch(progress){
                case 0:
                    fs.ReadTextFromResource("Txtfiles/ParkBenchAText1");
                    break;
                case 1:
                    fs.SetupButtonGroup();
                    fs.SetupButton("妳今天回去有什麼安排嗎？",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ10A1Action");
                            isLocked=false;
                    });
                    fs.SetupButton("回家的路遠嗎？要不要我送妳？",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ10A2Action");
                            isLocked=false;
                    });
                    fs.SetupButton("天快黑了，我們趕快走吧。",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ10A3Action");
                            isLocked=false;
                    });
                    isLocked=true;
                    break;
                case 2:
                    fs.ReadTextFromResource("Txtfiles/ParkBenchAText2");
                    break;
                case 3:
                    fs.SetupButtonGroup();
                    fs.SetupButton("路上小心，回去記得告訴我一聲。",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ11A1Action");
                            isLocked=false;
                    });
                    fs.SetupButton("再見，下次見面我會帶點新鮮的話題來跟妳分享。",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ11A2Action");
                            isLocked=false;
                    });
                    fs.SetupButton("期待下次約會，再見！",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ11A3Action");
                            isLocked=false;
                    });
                    isLocked=true;
                    break;
                case 4:
                    fs.ReadTextFromResource("Txtfiles/ParkBenchAText3");
                    break;
                default:
                    isGameEnd=true;
                    break;
            }
            
            progress++;
        }
        if (!isGameEnd)
        {
            if(Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButton(0)){
                // Continue the messages, stoping by [w] or [lr] keywords.
                fs.Next();
            }
            if (Input.GetKeyDown(KeyCode.Escape)){
                pausedMenuHandler.TogglePause();
            }
        }
        if(isGameEnd){
            SceneManager.LoadScene("Menu");
        }
        
    }
}