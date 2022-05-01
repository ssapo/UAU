using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;
using System.Linq;

public class AmongUsRoomPlayer : NetworkRoomPlayer
{
    private static AmongUsRoomPlayer myRoomPlayer;

    public static AmongUsRoomPlayer MyRoomPlayer
    {
        get
        {
            if(myRoomPlayer == null)
            {
                var player = FindObjectsOfType<AmongUsRoomPlayer>().First(player => player.hasAuthority);
                myRoomPlayer = player;
            }

            return myRoomPlayer;
        }
    }

    [SyncVar(hook = nameof(SetPlayerColor_Hook))]
    public EPlayerColor playerColor;

    public void SetPlayerColor_Hook(EPlayerColor oldColor, EPlayerColor newColor)
    {
		LobbyUIManager.Instance?.CustomizeUI.UpdateSelectColorButton(newColor);
	}

    public CharacterMover lobbyPlayerCharacter;

    private void Start()
    {
        base.Start();

        if(isServer)
        {
            SpawnLobbyPlayerCharacter();
        }
    }

	private void OnDestroy()
	{
		LobbyUIManager.Instance?.CustomizeUI.UpdateUnselectColorButton(playerColor);
	}

	[Command]
    public void CmdSetPlayerColor(EPlayerColor color)
    {
        playerColor = color;

        lobbyPlayerCharacter.playerColor = color;
    }

    private void SpawnLobbyPlayerCharacter()
    {
        playerColor = GetAvailablePlayerColor();

        var spawnPositions = FindObjectOfType<SpawnPositions>();
        int index = spawnPositions.Index;
        Vector3 spawnPos = spawnPositions.GetSpawnPosition();

        var playerCharacter = Instantiate(AmongUsRoomManager.singleton.spawnPrefabs[0], spawnPos, Quaternion.identity).GetComponent<LobbyCharacterMover>();
        playerCharacter.transform.localScale = index < 5 ? new Vector3(0.5f, 0.5f, 1f) : new Vector3(-0.5f, 0.5f, 1f);
        NetworkServer.Spawn(playerCharacter.gameObject, connectionToClient);
        playerCharacter.ownerNetId = netId;
        playerCharacter.playerColor = playerColor;
    }

    private EPlayerColor GetAvailablePlayerColor()
    {
        var roomSlots = ((AmongUsRoomManager)NetworkManager.singleton).roomSlots;
        List<EPlayerColor> allColors = new List<EPlayerColor>();
        foreach (var color in Enum.GetValues(typeof(EPlayerColor)))
            allColors.Add((EPlayerColor)color);

        EPlayerColor availableColor = allColors.Find(color => !roomSlots.Select(slot => ((AmongUsRoomPlayer)slot).playerColor).Contains(color));

        return availableColor;
    }
}
