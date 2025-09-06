using System.Collections;
using UnityEngine;
using TMPro; // TextMeshPro�� ����ϰų�, UnityEngine.UI;�� ���

public class DiceRoller : MonoBehaviour
{
    // ���� ������Ʈ�� ���� �����ϴ� public ����
    public TMPro.TextMeshProUGUI diceResultText;
    public int diceSides = 6;
    private bool isRolling = false;

    // ���� �Ŵ����� ȣ���ϴ� �Լ�
    public void RollAndDisplayResult()
    {
        if (!isRolling)
        {
            StartCoroutine(RollDiceCoroutine());
        }
    }

    private IEnumerator RollDiceCoroutine()
    {
        isRolling = true;

        float rollDuration = 1.5f;
        float timer = 0f;

        // �ֻ��� �������� �ð��� ȿ��
        while (timer < rollDuration)
        {
            int tempRoll = Random.Range(1, diceSides + 1);
            diceResultText.text = "cost: " + tempRoll.ToString();
            timer += Time.deltaTime;
            yield return null;
        }

        // ���� �ֻ��� �� ���� �� ���
        int finalRoll = Random.Range(1, diceSides + 1);
        diceResultText.text = "cost: " + finalRoll.ToString();

        isRolling = false;

        // ���� �ֻ��� ���� GameData�� ����
        if (GameData.Instance != null)
        {
            GameData.Instance.diceValueFromAction1 = finalRoll;
        }

        // �ֻ��� �����Ⱑ ������ ���� ���·� ��ȯ�ϵ��� ���� �Ŵ����� �˸�
        if (GameStateMachine.Instance != null)
        {
            GameStateMachine.Instance.OnDiceRollCompleted();
        }
    }
}