using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameRoomSettingsUI : SettingsUI
{
    private void Start()
    {
        MouseControlButton.onClick.AddListener(() => { SetControlMode(EControlType.MouseControl); });
        KeyboardMouseControlButton.onClick.AddListener(() => { SetControlMode(EControlType.KeyboardMouse); });
    }

    public void Open()
	{
		AmongUsRoomPlayer.MyRoomPlayer.lobbyPlayerCharacter.IsMoveable = false;
        gameObject.SetActive(true);
	}

	public override void Close()
	{
		base.Close();
        AmongUsRoomPlayer.MyRoomPlayer.lobbyPlayerCharacter.IsMoveable = true;
	}

	public void ExitGameRoom()
    {
        var manager = AmongUsRoomManager.singleton;
        if(manager.mode == NetworkManagerMode.Host)
        {
            manager.StopHost();
        }
        else
        {
            manager.StopClient();
        }
    }
}
