using UnityEngine;
using UnityEditor;
using UnityEngine.EventSystems;

[InitializeOnLoad]
public static class EventSystemChecker
{
    static EventSystemChecker()
    {
        EditorApplication.hierarchyChanged += OnHierarchyChanged;
    }

    private static void OnHierarchyChanged()
    {
        if (Object.FindObjectOfType<EventSystem>() == null)
        {
            Debug.Log("No EventSystem found in the scene. Adding one automatically.");
            GameObject eventSystem = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
        }
    }
}
