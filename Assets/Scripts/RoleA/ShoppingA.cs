using UnityEngine;
using Flower;
using System;
using UnityEngine.SceneManagement;
using Modules;

public class ShoppingAScene : MonoBehaviour
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

    void Update(){   
        if(fs.isCompleted && !isGameEnd && !isLocked){
            switch(progress){
                case 0:
                    fs.ReadTextFromResource("Txtfiles/ShoppingAText1");
                    break;
                case 1:
                    fs.SetupButtonGroup();
                    fs.SetupButton("while (true)",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ5A1Action");
                            isLocked=false;
                    });
                    fs.SetupButton("for (int i = 0; i < n; i++)",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ5A2Action");
                            isLocked=false;
                    });
                    fs.SetupButton("do...while",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ5A3Action");
                            isLocked=false;
                    });
                    isLocked=true;
                    break;
                case 2:
                    fs.ReadTextFromResource("Txtfiles/ShoppingAText2");
                    break;
                case 3:
                    fs.SetupButtonGroup();
                    fs.SetupButton("學做菜！每一步都要循環完成，然後依照食譜的步驟逐步來。",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ6A1Action");
                            isLocked=false;
                    });
                    fs.SetupButton("整理房間！每次只整理一小塊區域，然後不斷遞歸處理剩下的部分。",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ6A2Action");
                            isLocked=false;
                    });
                    fs.SetupButton("走迷宮！一步一步往前走，然後每次碰到岔路再遞歸選擇方向。",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ6A3Action");
                            isLocked=false;
                    });
                    isLocked=true;
                    break;
                case 4:
                    fs.ReadTextFromResource("Txtfiles/ShoppingAText3");
                    break;
                case 5:
                    fs.SetupButtonGroup();
                    fs.SetupButton("這件外套很適合妳，想試穿看看嗎？",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ7A1Action");
                            isLocked=false;
                    });
                    fs.SetupButton("妳覺得這外套怎麼樣？我覺得挺不錯的。",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ7A2Action");
                            isLocked=false;
                    });
                    fs.SetupButton("let function_name = function()",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ7A3Action");
                            isLocked=false;
                    });
                    isLocked=true;
                    break;
                case 6:
                    fs.ReadTextFromResource("Txtfiles/ShoppingAText4");
                    break;
                case 7:
                    fs.SetupButtonGroup();
                    fs.SetupButton("想吃就進去吧，妳的直覺通常不會錯。",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ8A1Action");
                            isLocked=false;
                    });
                    fs.SetupButton("要不我們今天換個口味，試試其他店？",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ8A2Action");
                            isLocked=false;
                    });
                    fs.SetupButton("沉默片刻，跟著她一起看著窗外，享受這片刻的寧靜。",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ8A3Action");
                            isLocked=false;
                    });
                    isLocked=true;
                    break;
                case 8:
                    fs.ReadTextFromResource("Txtfiles/ShoppingAText5");
                    break;
                case 9:
                    fs.SetupButtonGroup();
                    fs.SetupButton("當達到一個基準條件時",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ9A1Action");
                            isLocked=false;
                    });
                    fs.SetupButton("當內存不足時",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ9A2Action");
                            isLocked=false;
                    });
                    fs.SetupButton("當所有選項都無法選擇時",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ9A3Action");
                            isLocked=false;
                    });
                    isLocked=true;
                    break;
                case 10:
                    fs.ReadTextFromResource("Txtfiles/ShoppingAText6");
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
            SceneManager.LoadScene("ParkBenchAScene");
        }
        
    }
}