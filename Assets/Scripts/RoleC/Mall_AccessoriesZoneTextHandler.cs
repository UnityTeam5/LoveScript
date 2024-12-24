using UnityEngine;
using TMPro;

public class Mall_AccessoriesZoneTextHandler : MonoBehaviour
{
    public string fontPath = "Fonts/FontGenerator/MINGLIU-商場all";
    public string text = "商場-飾品專區";
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
            textComponent.text = text;
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
