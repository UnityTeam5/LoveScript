using UnityEngine;
using Flower;
using UnityEngine.UI;
using System;

public class processController : MonoBehaviour
{
    FlowerSystem fs;
    private int progress = 0;
    private bool changeToCoffee = false; 
    private bool changeToZoo = false;
    private bool changedialogue = false;
    private int test;
    void Start()
    { 
        fs = FlowerManager.Instance.CreateFlowerSystem("campus", false);
        fs.SetupDialog();
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
                    fs.SetupButton("「對啊，就像我們去咖啡店排隊買咖啡，先來的就先點。」",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/respondCampus1");
                        fs.RemoveButtonGroup();
                        changeToCoffee = true;
                    });

                    fs.SetupButton("「那如果是堆疊，應該是什麼樣的情境呢？」",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/respondCampus2");
                        fs.RemoveButtonGroup();
                        changeToCoffee = true;
                    });

                    fs.SetupButton("「佇列和堆疊的應用聽起來都很實用，有沒有更複雜的例子？」",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/respondCampus3");
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
                    fs.SetupButton("「那雙向鏈結串列呢？是不是就像我們今天這樣，有時候可以回顧以前的事，再接著向前？」",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/respondCoffee1");
                        fs.RemoveButtonGroup();
                        changedialogue = true;
                    });

                    fs.SetupButton("「那我覺得環狀鏈結串列應該像一個永不停止的行程，不斷循環。」",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/respondCoffee2");
                        fs.RemoveButtonGroup();
                        changedialogue = true;
                    });

                    fs.SetupButton("「單向鏈結串列聽起來有點麻煩，妳平時用這個資料結構多嗎？」",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/respondCoffee3");
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
                    fs.SetupButton("「我覺得生活比較像圖結構。」",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/respondCoffee4");
                        fs.RemoveButtonGroup();
                        changeToZoo = true;
                    });

                    fs.SetupButton("「我感覺比較像堆疊。」",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/respondCoffee5");
                        fs.RemoveButtonGroup();
                        changeToZoo = true;
                    });

                    fs.SetupButton("「我覺得像是多重樹結構」",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/respondCoffee6");
                        fs.RemoveButtonGroup();
                        changeToZoo = true;
                    });
                    progress++;
                    break;
                case 6:
                    if(changeToZoo == true)
                    {
                        fs.ReadTextFromResource("Txtfiles/zoo");
                        progress++;
                    }
                    break;
                case 7:
                    fs.SetupButtonGroup();
                    fs.SetupButton("「那這棵樹有幾層呢？最高層的是什麼？」",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/respondZoo1");
                        fs.RemoveButtonGroup();
                        changedialogue = true;
                    });

                    fs.SetupButton("「如果有兩種動物共享一個棲息地，它們會有相同的父節點嗎？」",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/respondZoo2");
                        fs.RemoveButtonGroup();
                        changedialogue = true;
                    });

                    fs.SetupButton("「這樣的樹結構聽起來很像在做一個分類系統，挺有趣的。」",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/respondZoo3");
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
                    fs.SetupButton("「如果表演中突然需要改變順序，我們該用什麼資料結構？」",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/respondZoo4");
                        fs.RemoveButtonGroup();
                        changedialogue = true;
                    });

                    fs.SetupButton("「那這些動作的指令是不是像一個控制迴圈？」",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/respondZoo5");
                        fs.RemoveButtonGroup();
                        changedialogue = true;
                    });

                    fs.SetupButton("「看來佇列在生活中應用真的很多。」",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/respondZoo6");
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
                    fs.SetupButton("「那妳覺得今天我們的約會更像是什麼資料結構？」",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/respondZoo7"); 
                        fs.RemoveButtonGroup();
                        changedialogue = true;
                    });

                    fs.SetupButton("「如果生活是個資料結構，那它最核心的應該是什麼？」",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/respondZoo8");
                        fs.RemoveButtonGroup();
                        changedialogue = true;
                    });

                    fs.SetupButton("「這次約會就像一棵樹，我們一路從根走到葉子，體驗了很多東西。」",()=>
                    {
                        fs.Resume();
                        fs.ReadTextFromResource("Txtfiles/respondZoo9");
                        fs.RemoveButtonGroup();
                        changedialogue = true;
                    });
                    progress++;
                    break;
            }
        }

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            fs.Next();
        }
    }
}
