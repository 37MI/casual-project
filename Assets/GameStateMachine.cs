using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateMachine : MonoBehaviour
{
    public static GameStateMachine Instance;
    public DiceRoller diceRoller;
    public SkillManager skillManager;
    public PlayerManager playerManager;
    public Action2UIUpdater action2UIUpdater;

    public GameObject action1UI;
    public GameObject action2UI;

    public enum GameState
    {
        SkillReset,
        SkillSelection,
        DiceRolling,
        ResultAndState,
        Action2_Active
    }

    private GameState currentState;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ChangeState(GameState.SkillReset);
    }

    public void OnDiceButtonPushed()
    {
        if (currentState == GameState.SkillSelection)
        {
            ChangeState(GameState.DiceRolling);
        }
    }

    // ?? �� �Լ��� �ֻ��� �����Ⱑ ������ �� ȣ��˴ϴ�.
    public void OnDiceRollCompleted()
    {
        ChangeState(GameState.ResultAndState);
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
        switch (currentState)
        {
            case GameState.SkillReset:
                if (skillManager != null)
                {
                    skillManager.ResetSkills();
                }
                if (action1UI != null) action1UI.SetActive(true);
                if (action2UI != null) action2UI.SetActive(false);
                ChangeState(GameState.SkillSelection);
                break;

            case GameState.SkillSelection:
                Debug.Log("��ų ���� ����: ��ų�� ��ü�ϰ� �ֻ��� ��ư�� ��������.");
                break;

            case GameState.DiceRolling:
                Debug.Log("�ֻ��� ������ ����: �ֻ����� �������ϴ�.");
                diceRoller.RollAndDisplayResult();
                break;

            case GameState.ResultAndState:
                EndAction1AndStartAction2();
                break;

            case GameState.Action2_Active:
                if (action1UI != null) action1UI.SetActive(false);
                if (action2UI != null) action2UI.SetActive(true);

                // ?? ���⿡�� PlayerManager�� �ʱ�ȭ �Լ��� ȣ���մϴ�.
                if (playerManager != null)
                {
                    playerManager.InitializeCost();
                }
                if (action2UIUpdater != null)
                {
                    action2UIUpdater.UpdateCostUI();
                }
                Debug.Log("�ൿ2 Ȱ��ȭ: ��ų �̹����� Ŭ���ϼ���.");
                break;
        }
    }

    private void EndAction1AndStartAction2()
    {
        Debug.Log("�ൿ1 ����. �ൿ2 ĵ������ ��ȯ�մϴ�.");
        ChangeState(GameState.Action2_Active);
    }
}