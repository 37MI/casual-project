using UnityEngine;
using System.Collections;
using TMPro; // TextMeshPro�� ����Ϸ��� �߰��ؾ� �մϴ�.

public class DiceRoller : MonoBehaviour
{
    // �ν����Ϳ� ������ ������
    public TMP_Text diceResultText;
    public int diceSides = 6;

    // �ֻ��� ������ �ִϸ��̼� �ð�
    public float rollTime = 1f;
    private bool isRolling = false;

    // ���ӸŴ����� ȣ���ϴ� �Լ�
    public void RollAndDisplayResult()
    {
        if (!isRolling)
        {
            StartCoroutine(RollDiceCoroutine());
        }
    }

    IEnumerator RollDiceCoroutine()
    {
        isRolling = true;
        float timer = 0f;

        // �ֻ����� �������� ���� �ð��� ȿ��
        while (timer < rollTime)
        {
            int roll = Random.Range(1, diceSides + 1);
            diceResultText.text = $"Cost: {roll}";
            timer += Time.deltaTime;
            yield return null;
        }

        // ���� �ֻ��� �� ����
        int finalRoll = Random.Range(1, diceSides + 1);
        diceResultText.text = $"Cost: {finalRoll}";

        // ���� �ֻ��� ���� GameData�� ����
        if (GameData.Instance != null)
        {
            GameData.Instance.diceValueFromAction1 = finalRoll;
            Debug.Log($"�ֻ��� ��� {finalRoll}��(��) GameData�� ����Ǿ����ϴ�.");
        }

        // �ֻ��� �����Ⱑ �������� GameStateMachine�� �˸�
        if (GameStateMachine.Instance != null)
        {
            GameStateMachine.Instance.OnDiceRollCompleted();
        }

        isRolling = false;
    }
}