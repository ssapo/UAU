using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class OnlineUI : MonoBehaviour
{
	[SerializeField] private InputField IF_nick;
	[SerializeField] private InputField IF_ip;
	[SerializeField] private GameObject createRoomUI;
	// Start is called before the first frame update
	public void OnClickCreateRoomButton()
	{
		if (string.IsNullOrEmpty(IF_nick.text))
		{
			IF_nick.GetComponent<Animator>().SetTrigger("on");
		}
		else
		{
			PlayerSettings.nickname = IF_nick.text;
			createRoomUI.SetActive(true);
			gameObject.SetActive(false);
		}
	}

	public void OnClickEnterGameRoomButton()
	{
		if (string.IsNullOrEmpty(IF_ip.text))
		{
			return;
		}

		if (string.IsNullOrEmpty(IF_nick.text))
		{
			IF_nick.GetComponent<Animator>().SetTrigger("on");
		}
		else
		{
			PlayerSettings.nickname = IF_nick.text;
			AmongUsRoomManager.singleton.networkAddress = IF_ip.text;
			AmongUsRoomManager.singleton.StartClient();
		}
	}
}
