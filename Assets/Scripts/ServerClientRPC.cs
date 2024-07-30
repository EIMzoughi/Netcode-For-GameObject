using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ServerClientRPC : NetworkBehaviour
{
    [ServerRpc]
    private void ServerCallDoSomethingServerRpc() { }

    [ClientRpc]
    private void ClientCallDoSomethingClientRpc() { }
}
