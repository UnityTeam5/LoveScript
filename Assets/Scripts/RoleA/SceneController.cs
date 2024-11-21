using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;

public class SceneController : MonoBehaviour
{   
    FlowerSystem fs;
    private int progress = 0;
    private bool isGameEnd = false;
    void Start()
    {
        fs = FlowerManager.Instance.CreateFlowerSystem("RoleA",false);
        fs.SetupDialog();
        // if (progress == 1){
        //     fs.SetupButtonGroup();
        //     fs.SetupButton("最近程式設計作業好多啊，妳有沒有哪一題也卡住了？",()=>{
        //         fs.Next();
        //         fs.Resume(); // Resume system.
        //         fs.RemoveButtonGroup();
        // });
        // }
        

    }

    // Update is called once per frame
    void Update()
    {   
        if(fs.isCompleted && !isGameEnd){
            switch(progress){
                case 0:
                    fs.ReadTextFromResource("Txtfiles/conversation");
                    break;
                case 1:
                    fs.SetupButtonGroup();
                    fs.SetupButton("最近程式設計作業好多啊，妳有沒有哪一題也卡住了？",()=>{
                            fs.Resume();
                            fs.RemoveButtonGroup();
                            fs.ReadTextFromResource("Txtfiles/conversation2");
                        });
                    break;
                default:
                    isGameEnd=true;
                    break;
            }
            progress ++;
        }
        if (!isGameEnd)
        {
            if(Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButton(0)){
                // Continue the messages, stoping by [w] or [lr] keywords.
                fs.Next();
            }
            if(Input.GetKeyDown(KeyCode.R)){
                // Resume the system that stopped by [stop] or Stop().
                fs.Resume();
            }
        }
        
    }
}
