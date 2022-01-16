using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace Editor
{
    [CustomEditor(typeof(MoveHelper))]
    public class MoveHelperEditor : UnityEditor.Editor // Рисует путь при выделении агента.
    {
        // private void OnSceneGUI()
        // {
        //     if (target is MoveHelper { } moveHelper)
        //     {
        //         NavMeshAgent navMeshAgent = moveHelper.GetComponent<NavMeshAgent>();
        //         
        //         Handles.color = Color.red;
        //
        //         for (int i = 1; i < navMeshAgent.path.corners.Length; i++)
        //         {
        //             NavMeshPath path = navMeshAgent.path;
        //             Handles.DrawLine(path.corners[i - 1], path.corners[i]);
        //         }
        //     }
        // }
    }
}