using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    private int currentCost = 0;
    public TMP_Text costText;

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

    // ?? �� �Լ��� GameData���� �ڽ�Ʈ ���� ������ �ʱ�ȭ�մϴ�.
    public void InitializeCost()
    {
        if (GameData.Instance != null)
        {
            currentCost = GameData.Instance.diceValueFromAction1;
            Debug.Log($"�ൿ1���� ������ �ʱ� �ڽ�Ʈ: {currentCost}");
            UpdateCostUI();
        }
    }

    public void AddCost(int amount)
    {
        currentCost += amount;
        UpdateCostUI();
        Debug.Log($"�ڽ�Ʈ {amount} ȹ��. ���� �ڽ�Ʈ: {currentCost}");
    }

    public bool HasSufficientCost(int requiredCost)
    {
        return currentCost >= requiredCost;
    }

    public void ConsumeCost(int amount)
    {
        currentCost -= amount;
        UpdateCostUI();
        Debug.Log($"�ڽ�Ʈ {amount} �Ҹ�. ���� �ڽ�Ʈ: {currentCost}");
    }

    public void UpdateCostUI()
    {
        if (costText != null)
        {
            // "�ڽ�Ʈ:"�� "Cost:"�� ����
            costText.text = $"Cost: {currentCost}";
        }
    }

    public int GetCurrentCost()
    {
        return currentCost;
    }
}