using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextEffect : MonoBehaviour
{
    public TMP_Text myText;
    public float speed = 2.0f;
    private Color originalColor;

    void Start()
    {

        if (myText == null)
        {
            Debug.LogError("myText is null");
            return;
        }

        originalColor = myText.color;
        myText.fontStyle = FontStyles.Bold | FontStyles.Italic;
    }

    // Update is called once per frame
    void Update()
    {
        if (myText != null)
        {
            float alpha = (Mathf.Sin(Time.time * speed) + 1.0f) / 2.0f;
            myText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            myText.fontStyle = FontStyles.Bold | FontStyles.Italic;
        }
    }
}
