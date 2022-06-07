using UnityEditor;
using UnityEngine;

public class ColorWindow : EditorWindow
{ 
    Color color;

    [MenuItem("Tools/ColorPicker")]
    public static void ShowWindow()
    {
        GetWindow<ColorWindow>("ColorPicker");
    }

    private void OnGUI()
    {
        GUILayout.Label("Color for the selected object");

        color = EditorGUILayout.ColorField("Color", color);

        if (GUILayout.Button("Give it Color!"))
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                Renderer renderer = obj.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.sharedMaterial.color = color;
                }
            }
        }
        
        if (GUILayout.Button("Reset to white"))
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                Renderer renderer = obj.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.sharedMaterial.color = Color.white;
                }
            }
        }
    }
}
