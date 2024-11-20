using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;

public class SceneController : MonoBehaviour
{   
    FlowerSystem fs;
    void Start()
    {
        fs = FlowerManager.Instance.CreateFlowerSystem("default",false);
        fs.SetupDialog();
        fs.ReadTextFromResource("Txtfiles/conversation");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
