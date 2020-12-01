using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Bolt;
using System.Linq;

public class PhotonToBolt : MonoBehaviourPunCallbacks
{
    public override void OnConnectedToMaster()
    {
        CustomEvent.Trigger(gameObject, "OnConnectedToMaster");
    }
    public override void OnJoinedRoom()
    {
        CustomEvent.Trigger(gameObject, "OnJoinedRoom");
    }

    [PunRPC]
    void RPCCall(string eventName)
    {
        CustomEvent.Trigger(gameObject, eventName);
    }

    [PunRPC]
    void RPCCall(params object[] args)
    {
        CustomEvent.Trigger(gameObject, (string) args[0], args.Skip(1).ToArray());
    }
}
