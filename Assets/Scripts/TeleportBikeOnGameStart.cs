using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif  
using UnityEngine;

public class TeleportBikeOnGameStart : MonoBehaviour
{
    public Transform BikeTransform;
    public Transform TeleportTransform;
    
    public void Teleport()
    {
        BikeTransform.position = TeleportTransform.position;
        BikeTransform.rotation = TeleportTransform.rotation;
    }
}


#if UNITY_EDITOR

[CustomEditor(typeof(TeleportBikeOnGameStart))]
public class TeleportBikeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Teleport"))
        {
            var mt = target as TeleportBikeOnGameStart;
            mt.Teleport();
        }
    }
}
#endif
