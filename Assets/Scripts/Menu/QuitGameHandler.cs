using UnityEngine;
using UnityEngine.UI;

public class QuitGameHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick); 
    }

    private void OnClick()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
