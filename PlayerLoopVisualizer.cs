using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.LowLevel;

public class PlayerLoopVisualizer : EditorWindow
{
    static PlayerLoopSystem playerLoopSystem;
    static Vector2 scrollPos;
    bool firstCall = true;
    GUIStyle leftBold;
    GUIStyle normalCenter;


    [MenuItem("Window/PlayerLoopVisualizer")]
    public static void Open() 
    {
        GetWindow<PlayerLoopVisualizer>();
        Init();
    }

    protected void OnGUI()
    {
        playerLoopSystem = PlayerLoop.GetCurrentPlayerLoop();
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
        
        if (firstCall)
        {
            leftBold = new GUIStyle()
            {
                alignment = TextAnchor.MiddleLeft,
                fontStyle = FontStyle.Bold
            };
            normalCenter = new GUIStyle()
            {
                alignment = TextAnchor.MiddleCenter
            };
            firstCall = false;
        }        

        foreach (var header in playerLoopSystem.subSystemList) 
        {
            EditorGUILayout.BeginVertical(GUI.skin.box);
            GUILayout.Label(header.type.Name, leftBold);

            foreach (var subSystem in header.subSystemList) 
            {
                GUILayout.Label(subSystem.type.Name, normalCenter);
            }

            EditorGUILayout.EndVertical();
        }
        EditorGUILayout.EndScrollView();
        
    }

    static void Init()
    {
        playerLoopSystem = PlayerLoop.GetDefaultPlayerLoop();
    }

}