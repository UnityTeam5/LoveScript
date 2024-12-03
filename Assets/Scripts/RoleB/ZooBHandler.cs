using System.Collections;
using System.Collections.Generic;
using Flower;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ZooBHandler : MonoBehaviour
{
    FlowerSystem fs;
    private int progress = 0;
    private bool changedialogue = false;
    private bool isEndGame = false;
    // Start is called before the first frame update
    void Start()
    {
        fs = FlowerManager.Instance.CreateFlowerSystem("zoo", false);
        fs.SetupDialog();
    }

    // Update is called once per frame
    void Update()
    {
        if(fs.isCompleted)
        {
            switch(progress)
            {
                case 0:
                    fs.ReadTextFromResource("Txtfiles/zoo");
                    progress ++;
                    break;
                case 1:
                    fs.SetupButtonGroup();
                    fs.SetupButton("那這棵樹有幾層呢？最高層的是什麼？",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmBQ4A1Action");
                        fs.RemoveButtonGroup();
                        changedialogue = true;
                    });

                    fs.SetupButton("如果有兩種動物共享一個棲息地，它們會有相同的父節點嗎？",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmBQ4A2Action");
                        fs.RemoveButtonGroup();
                        changedialogue = true;
                    });

                    fs.SetupButton("這樣的樹結構聽起來很像在做一個分類系統，挺有趣的。",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmBQ4A3Action");
                        fs.RemoveButtonGroup();
                        changedialogue = true;
                    });
                    progress++;
                    break;
                case 2:
                    if(changedialogue == true)
                    {
                        changedialogue = false;
                        progress++;
                    }
                    break;
                case 3:
                    fs.SetupButtonGroup();
                    fs.SetupButton("如果表演中突然需要改變順序，我們該用什麼資料結構？",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmBQ5A1Action");
                        fs.RemoveButtonGroup();
                        changedialogue = true;
                    });

                    fs.SetupButton("那這些動作的指令是不是像一個控制迴圈？",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmBQ5A2Action");
                        fs.RemoveButtonGroup();
                        changedialogue = true;
                    });

                    fs.SetupButton("看來佇列在生活中應用真的很多。",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmBQ5A3Action");
                        fs.RemoveButtonGroup();
                        changedialogue = true;
                    });
                    progress++;
                    break; 
                case 4:
                    if(changedialogue == true)
                    {
                        changedialogue = false;
                        progress++;
                    }
                    break;
                case 5:
                    fs.SetupButtonGroup();
                    fs.SetupButton("那妳覺得今天我們的約會更像是什麼資料結構？",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmBQ6A1Action"); 
                        fs.RemoveButtonGroup();
                        changedialogue = true;
                    });

                    fs.SetupButton("如果生活是個資料結構，那它最核心的應該是什麼？",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmBQ6A2Action");
                        fs.RemoveButtonGroup();
                        changedialogue = true;
                    });

                    fs.SetupButton("這次約會就像一棵樹，我們一路從根走到葉子，體驗了很多東西。",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmBQ6A3Action");
                        fs.RemoveButtonGroup();
                        changedialogue = true;
                    });
                    progress++;
                    break;
                case 6:
                    if(changedialogue == true)
                    {
                        progress++;
                    }
                    break;
                default:
                    isEndGame = true;
                    break;
            }
        }
         if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            fs.Next();
        }

        if (fs.isCompleted && isEndGame)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
