# LoveScript

## 如何協作此專案？(限共同開發者)

步驟一：打開git bash(或者VSCode有裝bash也可使用)先cd至事先建立好的資料夾中，輸入此專案的位置並複製至本地端 `git clone https://github.com/George15526/LoveScript.git`

步驟二：打開Unity Hub，左側選單選擇Project，並在右上點擊"Add"，選擇"Add project from disk"，選擇剛剛clone下來的資料夾位置

<img height="50%" src="https://github.com/user-attachments/assets/1f53bd0e-9cdf-46e6-b2ac-ff56afc36d4f" />

步驟三：若有發現Unity Hub的Project裡面有LoveScript名字的專案，即可雙擊開啟專案並開始開發囉~

> 注意：在正式開發專案前，請各位確定是否將自己的專案分支改至dev，檢查方式為輸入`git remote`，若不是dev，則請輸入指令`git checkout -b dev`，即可轉至分支dev
> 注意：若在VSCode的話，在畫面的左下角可更容易知道現在的分支狀況
> <img height="50%" src="https://github.com/user-attachments/assets/ba01decf-3d10-4a6e-8a71-16fbbb8d35d4" />

## Git如何使用？(給還不會使用或不太熟悉git的人服用)

以此專案為例，假設已經跟著上面的說明成功將專案clone下來後，接下來就只需要特別記三項事情(最常用)
1. git add + 要新增的檔案位置 => 新增剛剛改動的檔案
2. git commit -m "這裡放剛剛新增檔案的相關說明" => 在git中留言剛剛新增檔案的相關詳細說明(說明改動了什麼，新增？重構？樣式更改？等等其他)
3. git push -u origin dev => 將剛剛的新增並留言完畢的git檔，推至遠端的git repository的dev分支

> 例子：(branch -> dev)
> git add Assets/
> git commit -m "add a person in project"
> git push -u origin dev