using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonRoleBHandler : MonoBehaviour
{
    public string imgPath = "Sprites/Roles/B(Role)_1";
    void Start()
    {
        // 尋找 "Image" 子物件
        Transform imageTransform = transform.Find("Mask/Image");
        if (imageTransform == null)
        {
            Debug.LogError("Image component is null");
            return;
        }
        
        // 取得 Image 組件
        Image imageComponent = imageTransform.GetComponent<Image>();
        if (imageComponent == null)
        {
            Debug.LogError("Image component is null");
            return;
        }
        
        // 載入圖片
        Sprite customSprite = Resources.Load<Sprite>(imgPath);
        if (customSprite != null)
        {
            imageComponent.sprite = customSprite;
            Debug.Log("Sprite B set successfully");
        }
        else
        {
            Debug.LogError($"Sprite not found at {imgPath}");
        }

        // 設定按鈕點擊事件
        Button btn = this.GetComponent<Button>();
        if (btn.name == "Button_RoleB")
        {
            btn.onClick.AddListener(() =>{
                Debug.Log("Role B");
                SceneManager.LoadScene("CafesNearCampusBScene");
            });
        }
    }

    void Update()
    {
        
    }
}
