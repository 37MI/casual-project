using UnityEngine;
using TMPro;

public class Action2UIUpdater : MonoBehaviour
{
    // �ൿ2 ĵ������ �ִ� �ڽ�Ʈ �ؽ�Ʈ�� �ν����Ϳ��� ����
    public TMP_Text costText;

    // �� �Լ��� �ൿ2 ĵ������ Ȱ��ȭ�� �� �ڵ����� ȣ��˴ϴ�.
    void OnEnable()
    {
        UpdateCostUI();
    }

    // PlayerManager�κ��� �ڽ�Ʈ�� ������ UI�� ������Ʈ�մϴ�.
    public void UpdateCostUI()
    {
        if (PlayerManager.Instance != null && costText != null)
        {
            int currentCost = PlayerManager.Instance.GetCurrentCost();
            costText.text = $"cost: {currentCost}";
        }
    }
}