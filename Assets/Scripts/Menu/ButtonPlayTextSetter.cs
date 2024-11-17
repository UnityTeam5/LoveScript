using UnityEngine;
using TMPro;

public class ButtonPlayTextSetter : MonoBehaviour
{
    // Setting font style resources
    public string fontPath = "Fonts/FontGenerator/MINGLIU--按任意鍵開始遊戲";
    public string buttonText = "按任意鍵開始遊戲";

    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI textComponent = transform.Find("Text").GetComponent<TextMeshProUGUI>();

        if (textComponent == null)
        {
            Debug.LogError("Text component is null");
            return;
        }

        TMP_FontAsset customFont = Resources.Load<TMP_FontAsset>(fontPath);
        if (customFont != null)
        {
            textComponent.font = customFont;
            textComponent.text = buttonText;
            Debug.Log("Font set successfully");
        }
        else
        {
            Debug.LogError($"Font not found at {fontPath}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
