using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance;

    public int diceValueFromAction1; // �ൿ1���� ������ �ֻ��� ��

    private void Awake()
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
}