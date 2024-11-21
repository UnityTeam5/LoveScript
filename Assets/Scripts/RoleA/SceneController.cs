using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;

public class SceneController : MonoBehaviour
{   
    FlowerSystem fs;
    private int progress = 0;
    void Start()
    {
        fs = FlowerManager.Instance.CreateFlowerSystem("RoleA",false);
        fs.SetupDialog();
        fs.ReadTextFromResource("Txtfiles/conversation");
        if (progress == 1){
            fs.SetupButtonGroup();
            fs.SetupButton("最近程式設計作業好多啊，妳有沒有哪一題也卡住了？",()=>{
                fs.Next();
                fs.Resume(); // Resume system.
                fs.RemoveButtonGroup();
        });
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0)){
            fs.Next();
            progress++;
            Debug.Log("Progress: "+progress);
        }
        
    }
}
