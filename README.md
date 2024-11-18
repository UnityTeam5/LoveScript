# LoveScript

## 如何協作此專案？(限共同開發者)

步驟一：請先fork這支專案(右上角)

<img height="50%" src="https://github.com/user-attachments/assets/f68a706d-2d29-4b77-ba78-7ae72e3fd600" />

步驟二：打開git bash(或者VSCode有裝bash也可使用)先cd至事先建立好的資料夾中，輸入剛剛fork專案的位置並複製至本地端，範例： `git clone https://github.com/George15526/LoveScript.git`

<img height="50%" src="https://github.com/user-attachments/assets/6e491b4a-2618-4ede-bba3-d50a679df5dc" />

步驟三：打開Unity Hub，左側選單選擇Project，並在右上點擊"Add"，選擇"Add project from disk"，選擇剛剛clone下來的資料夾位置

<img height="50%" src="https://github.com/user-attachments/assets/1f53bd0e-9cdf-46e6-b2ac-ff56afc36d4f" />

步驟四：若有發現Unity Hub的Project裡面有LoveScript名字的專案，即可雙擊開啟專案並開始開發囉~

> 注意：在正式開發專案前，請各位確定是否將自己的專案分支改至dev，檢查方式為輸入`git branch`，若不是dev，則請輸入指令`git checkout -b dev`，即可轉至分支dev
> 注意：若在VSCode的話，在畫面的左下角可更容易知道現在的分支狀況

> <img height="50%" src="https://github.com/user-attachments/assets/ba01decf-3d10-4a6e-8a71-16fbbb8d35d4" />

## 專案資料夾結構(協作者必看！！)

~~~
Assets/
├── Resources/
│   ├── Fonts/               # 儲存字體相關
│   │   ├── FontGenerator/   # 儲存 TMP_FontAsset
│   │   │   ├── MINGLIU--確認.asset
│   │   │   └── MINGLIU--按任意鍵開始遊戲.asset
│   │   │
│   │   └── FontStyle/       # 儲存字體檔案 (.TTC/.ttf/.otf)
│   │       └── MINGLIU.TTC
│   │
│   ├── Sprites/             # 2D 精靈圖像或 UI 資源(目前未分類，下次更新會加入)
│   │   ├── Icons/
│   │   │   ├── Arrow-Previous.png
│   │   │   └── Exit.png
│   │   └── Backgrounds/     # 背景圖片放置區
│   │       └── MainMenuBackground.jpg
│   │
│   ├── Audio/               # 音效與音樂(預計加入，未新增資料夾)
│   │   ├── BGM/             # 此為示例
│   │   │   └── MainTheme.mp3
│   │   └── SFX/
│   │       └── ButtonClick.wav
│   │
│   │
│   └── Data/                # 遊戲配置或數據文件(預計加入，未新增資料夾)
│       ├── GameConfig.json  # 此為示例
│       └── Localization/
│           └── zh_TW.json 
│
├── Scripts/                 # 腳本文件
│   ├── Menu/
│   │   ├── ButtonPlayTextSetter.cs
│   │   ├── PlayGameHandler.cs
│   │   ├── QuitGameHandler.cs
│   │   └── TextEffect.cs
│   └── SubMenu/
│       ├── ButtonSubmitTextSetter.cs
│       ├── ReturnButtonEvent.cs
│       └── SubmitButtonEvent.cs
│
├── Editor/                  # 腳本文件
│   └── EventSystemChecker.cs
│
├── Scenes/                  # 遊戲場景檔案
│   ├── MainMenu.unity
│   └── Game.unity
│
└── TextMesh Pro/            # 下載TextMesh Pro套件後自動生成，不可更動
~~~

## Git如何使用？(給還不會使用或不太熟悉git的人服用)

以此專案為例，假設已經跟著上面的說明成功將專案clone下來後，接下來就只需要特別記三項事情(最常用)
1. git add + 要新增的檔案位置 => 新增剛剛改動的檔案
2. git commit -m "這裡放剛剛新增檔案的相關說明" => 在git中留言剛剛新增檔案的相關詳細說明(說明改動了什麼，新增？重構？樣式更改？等等其他)
3. git push -u origin dev => 將剛剛的新增並留言完畢的git檔，推至遠端的git repository的dev分支

> 例子：(branch -> dev)
> git add Assets/
> git commit -m "add a person in project"
> git push -u origin dev

而在之後專案已經clone到本地端情況下，在每一次的協作中，請一定要先至GitHub倉庫中，查看是否需要更新程式碼(有可能其他協作者有更新東西在dev中，或者經過code review後合併至專案的主要main分支中)，若需要更新程式碼，則需要在改動程式碼前，輸入`git pull`，先將更新的程式碼抓取下來，再做改動會比較好哦~