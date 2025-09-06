using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateMachine : MonoBehaviour
{
    public static GameStateMachine Instance;

    public DiceRoller diceRoller;
    public SkillManager skillManager;

    public enum GameState
    {
        SkillReset,
        SkillSelection,
        DiceRolling,
        ResultAndState,
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
                ChangeState(GameState.SkillSelection);
                break;
            case GameState.SkillSelection:
                Debug.Log("��ų ���� ����: ��ų�� ��ü�ϰ� �ֻ��� ��ư�� ��������.");
                break;
            case GameState.DiceRolling:
                Debug.Log("�ֻ��� ������ ����: �ֻ����� �������ϴ�.");
                diceRoller.RollAndDisplayResult(); // �ֻ��� ������ �Լ� ȣ��
                break;
            case GameState.ResultAndState:
                EndAction1AndLoadNextScene();
                break;
        }
    }

    // DiceButton�� ������ �Լ�
    public void OnDiceButtonPushed()
    {
        // ���� ���°� SkillSelection�� ���� ���¸� ����
        if (currentState == GameState.SkillSelection)
        {
            ChangeState(GameState.DiceRolling);
        }
    }

    private void EndAction1AndLoadNextScene()
    {
        Debug.Log("�ൿ1 ����. �ൿ2 ������ ��ȯ�մϴ�.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}