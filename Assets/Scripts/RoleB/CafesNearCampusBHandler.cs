using UnityEngine;
using Flower;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Modules;
public class CafeNearCampusBHandler : MonoBehaviour
{
    FlowerSystem fs;
    private PausedMenuHandler pausedMenuHandler;
    private int progress = 0;
    private bool changeToCoffee = false; 
    private bool changeToZoo = false;
    private bool changedialogue = false;
    void Start()
    { 
        fs = FlowerManager.Instance.CreateFlowerSystem("campus", false);
        fs.SetupDialog();
        pausedMenuHandler = new PausedMenuHandler(fs);
    }

    void Update()
    {
        if(fs.isCompleted)
        {
            switch(progress)
            {
                case 0:
                    fs.ReadTextFromResource("Txtfiles/campus");
                    progress ++;
                    break;
                case 1:
                    fs.SetupButtonGroup();
                    fs.SetupButton("對啊，就像我們去咖啡店排隊買咖啡，先來的就先點。",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmBQ1A1Action");
                        fs.RemoveButtonGroup();
                        changeToCoffee = true;
                    });

                    fs.SetupButton("那如果是堆疊，應該是什麼樣的情境呢？",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmBQ1A2Action");
                        fs.RemoveButtonGroup();
                        changeToCoffee = true;
                    });

                    fs.SetupButton("佇列和堆疊的應用聽起來都很實用，有沒有更複雜的例子？",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmBQ1A3Action");
                        fs.RemoveButtonGroup();
                        changeToCoffee = true;
                    });
                    progress++;
                    break;
                case 2:
                    if(changeToCoffee == true)
                    {
                        fs.ReadTextFromResource("Txtfiles/coffee");
                        progress++;
                    }
                    break;
                case 3:
                    fs.SetupButtonGroup();
                    fs.SetupButton("那雙向鏈結串列呢？是不是就像我們今天這樣，有時候可以回顧以前的事，再接著向前？",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmBQ2A1Action");
                        fs.RemoveButtonGroup();
                        changedialogue = true;
                    });

                    fs.SetupButton("那我覺得環狀鏈結串列應該像一個永不停止的行程，不斷循環。",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmBQ2A2Action");
                        fs.RemoveButtonGroup();
                        changedialogue = true;
                    });

                    fs.SetupButton("單向鏈結串列聽起來有點麻煩，妳平時用這個資料結構多嗎？",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmBQ2A3Action");
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
                    fs.SetupButton("我覺得生活比較像圖結構。",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmBQ3A1Action");
                        fs.RemoveButtonGroup();
                        changeToZoo = true;
                    });

                    fs.SetupButton("我感覺比較像堆疊。",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmBQ3A2Action");
                        fs.RemoveButtonGroup();
                        changeToZoo = true;
                    });

                    fs.SetupButton("我覺得像是多重樹結構",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/AlgorithmBQ3A3Action");
                        fs.RemoveButtonGroup();
                        changeToZoo = true;
                    });
                    progress++;
                    break;
                case 6:
                    if(changeToZoo == true)
                    {
                        SceneManager.LoadScene("ZooBScene");
                    }
                    break;
                /*case 7:
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
                case 8:
                    if(changedialogue == true)
                    {
                        changedialogue = false;
                        progress++;
                    }
                    break;
                case 9:
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
                case 10:
                    if(changedialogue == true)
                    {
                        changedialogue = false;
                        progress++;
                    }
                    break;
                case 11:
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
                case 12:
                    if(changedialogue == true)
                    {
                        progress++;
                    }
                    break;
                default:
                    isEndGame = true;
                    break;*/
            }
        }

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            fs.Next();
        }
        
    if (Input.GetKeyDown(KeyCode.Escape))
    {
        pausedMenuHandler.TogglePause();
    }
        /*if (fs.isCompleted && isEndGame)
        {
            SceneManager.LoadScene("Menu");
        }*/
    }
}
