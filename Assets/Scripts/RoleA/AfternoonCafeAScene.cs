using UnityEngine;
using Flower;
using System;
using UnityEngine.SceneManagement;

public class AfternoonCafeAScene : MonoBehaviour
{   
    FlowerSystem fs;
    private int progress = 0;
    private bool isGameEnd = false;
    private bool isLocked = false;
    private String RoleAname;
    private String myname;

    void Start(){
        RoleAname = "我老婆";
        myname = "我";
        fs = FlowerManager.Instance.CreateFlowerSystem("RoleAFlowerSystem",false);
        fs.SetupDialog();
        fs.SetVariable("RoleA",RoleAname);
        fs.SetVariable("myname",myname);
    }

    // Update is called once per frame
    void Update(){   
        if(fs.isCompleted && !isGameEnd && !isLocked){
            switch(progress){
                case 0:
                    fs.ReadTextFromResource("Txtfiles/AfternoonCafeAText1");
                    break;
                case 1:
                    fs.SetupButtonGroup();
                    fs.SetupButton("O(n log n)",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ1A1Action");
                            isLocked=false;
                    });
                    fs.SetupButton("n²",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ1A2Action");
                            isLocked=false;
                    });
                    fs.SetupButton("n",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ1A3Action");
                            isLocked=false;
                    });
                    isLocked=true;
                    break;
                case 2:
                    fs.ReadTextFromResource("Txtfiles/AfternoonCafeAText2");
                    break;
                case 3:
                    fs.SetupButtonGroup();
                    fs.SetupButton("O(n log n)",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ2A1Action");
                            isLocked=false;
                    });
                    fs.SetupButton("n",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ2A2Action");
                            isLocked=false;
                    });
                    fs.SetupButton("1",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ2A3Action");
                            isLocked=false;
                    });
                    isLocked=true;
                    break;
                case 4:
                    fs.ReadTextFromResource("Txtfiles/AfternoonCafeAText3");
                    break;
                case 5:
                    fs.SetupButtonGroup();
                    fs.SetupButton("def function_name():",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ3A1Action");
                            isLocked=false;
                    });
                    fs.SetupButton("function function_name() {}",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ3A2Action");
                            isLocked=false;
                    });
                    fs.SetupButton("let function_name = function()",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ3A3Action");
                            isLocked=false;
                    });
                    isLocked=true;
                    break;
                case 6:
                    fs.ReadTextFromResource("Txtfiles/AfternoonCafeAText4");
                    break;
                case 7:
                    fs.SetupButtonGroup();
                    fs.SetupButton("(輕聲問)妳最近有什麼特別想做的事嗎？",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ4A1Action");
                            isLocked=false;
                    });
                    fs.SetupButton("(輕笑說)妳看起來今天特別放鬆。",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ4A2Action");
                            isLocked=false;
                    });
                    fs.SetupButton("沉默片刻，跟著她一起看著窗外，享受這片刻的寧靜。",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/AlgonithmAQ4A3Action");
                            isLocked=false;
                    });
                    isLocked=true;
                    break;
                case 8:
                    fs.ReadTextFromResource("Txtfiles/AfternoonCafeAText5");
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
        }
        if(isGameEnd){
            SceneManager.LoadScene("ShoppingAScene");
        }
        
    }
}
