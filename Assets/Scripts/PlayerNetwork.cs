using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerNetwork : NetworkBehaviour
{
    private NetworkVariable<int> _networkVariable = new NetworkVariable<int>(1,NetworkVariableReadPermission.Everyone,NetworkVariableWritePermission.Owner);

    public override void OnNetworkDespawn()
    {
        _networkVariable.OnValueChanged += (int previousValue,int newValue) =>{
            Debug.Log(OwnerClientId + " Number: " + _networkVariable.Value);
        };
    }
    void Update()
    {
        if(!IsOwner) return;


        if(Input.GetKeyDown(KeyCode.Escape))
        {
            _networkVariable.Value = Random.Range(0, 10);
        }


        Vector3 moveDir = new Vector3(0,0,0);

        if (Input.GetKey(KeyCode.W)) moveDir.z++;
        if (Input.GetKey(KeyCode.S)) moveDir.z--;
        if (Input.GetKey(KeyCode.A)) moveDir.x--;
        if (Input.GetKey(KeyCode.D)) moveDir.x++;

        float moveSpeed = 5f;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
}
