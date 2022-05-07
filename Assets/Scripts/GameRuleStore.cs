using Mirror;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public enum EKillRange
{
	Short, Normal, Long
}

public enum ETaskBarUpdates
{
	Always, Meetings, Never
}

public struct GameRuleData
{
	public bool confirmEjects;
	public int emergencyMeetings;
	public int emergencyMeetingsCooldown;
	public int meetingsTime;
	public int votesTime;
	public bool anonymousVotes;
	public float moveSpeed;
	public float crewSightRange;
	public float imposterSightRange;
	public float killCooldown;
	public EKillRange killRange;
	public bool visualMissions;
	public ETaskBarUpdates taskBarUpdates;
	public int commonMissions;
	public int complexMissions;
	public int simpleMissions;
}

public class GameRuleStore : MonoBehaviour
{
	[SyncVar]
	private bool isRecommendRule;
	[SerializeField]
	private Toggle isRecommendRuleToggle;
	[SyncVar]
	private bool confirmEjects;
	[SerializeField]
	private Toggle confirmEjectsToggle;
	[SyncVar]
	private int emergencyMeetings;
	[SerializeField]
	private Text emergencyMeetingsText;
	[SyncVar]
	private int emergencyMeetingsCooldown;
	[SerializeField]
	private Text emergencyMeetingsCooldownText;
	[SyncVar]
	private int meetingsTime;
	[SerializeField]
	private Text meetingsTimeText;
	[SyncVar]
	private int votesTime;
	[SerializeField]
	private Text votesTimeText;
	[SyncVar]
	private bool anonymousVotes;
	[SerializeField]
	private Toggle anonymousVotesToggle;
	[SyncVar]
	private float moveSpeed;
	[SerializeField]
	private Text moveSpeedText;
	[SyncVar]
	private float crewSightRange;
	[SerializeField]
	private Text crewSightRangeText;
	[SyncVar]
	private float imposterSightRange;
	[SerializeField]
	private Text imposterSightRangeText;
	[SyncVar]
	private float killCooldown;
	[SerializeField]
	private Text killCooldownText;
	[SyncVar]
	private EKillRange killRange;
	[SerializeField]
	private Text killRangeText;
	[SyncVar]
	private bool visualMissions;
	[SerializeField]
	private Toggle visualMissionsToggle;
	[SyncVar]
	private ETaskBarUpdates taskBarUpdates;
	[SerializeField]
	private Text taskBarUpdatesText;
	[SyncVar]
	private int commonMissions;
	[SerializeField]
	private Text commonMissionsText;
	[SyncVar]
	private int complexMissions;
	[SerializeField]
	private Text complexMissionsText;
	[SyncVar]
	private int simpleMissions;
	[SerializeField]
	private Text simpleMissionsText;

	[SerializeField]
	private Text gameRuleOverview;

	public void UpdateGameRuleOverview()
	{
		var roomManager = NetworkManager.singleton as AmongUsRoomManager;
		StringBuilder sb = new StringBuilder(isRecommendRule ? "추천 설정\n" : "커스텀 설정\n");
	}

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
