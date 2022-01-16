using System;
using UnityEngine;

[RequireComponent(typeof(MoveHelper))]
public class NPCHelper : MonoBehaviour
{
    public float AgroRadius = 10;

    private MoveHelper _moveHelper;

    private void Awake()
    {
        _moveHelper = GetComponent<MoveHelper>();
    }

    private void Update()
    {
        if(_moveHelper.Target != null)
            return;
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, AgroRadius);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].TryGetComponent(out PlayerMoving player))
            {
                _moveHelper.Target = player.gameObject;
                break;
            }
        }
    }
}
