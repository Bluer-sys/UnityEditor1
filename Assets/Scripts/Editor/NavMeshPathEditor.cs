using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace Editor
{
    public class NavMeshPathEditor : UnityEditor.Editor // Рисует путь агента постоянно.
    {
        [DrawGizmo(GizmoType.NotInSelectionHierarchy | GizmoType.InSelectionHierarchy)]
        public static void RenderCustomGizmo(Transform transform, GizmoType gizmoType)
        {
            NavMeshAgent navMeshAgent = transform.GetComponent<NavMeshAgent>();

            if (navMeshAgent == null)
                return;

            int cornersLength = navMeshAgent.path.corners.Length;
            
            if (navMeshAgent.TryGetComponent(out PlayerMoving playerMoving))
            {
                if (cornersLength > 1)
                {
                    Handles.color = Color.blue;
                    Handles.DrawWireDisc(navMeshAgent.path.corners[cornersLength - 1], Vector3.up, 0.5f);
                    Handles.DrawWireDisc(navMeshAgent.path.corners[cornersLength - 1], Vector3.up, 0.2f);
                }
                Handles.color = Color.green;
            }
            else
            {
                Handles.color = Color.red;
            }

            for (int i = 1; i < cornersLength; i++)
            {
                NavMeshPath path = navMeshAgent.path;
                Handles.DrawLine(path.corners[i - 1], path.corners[i]);
            }
        }
    }
}