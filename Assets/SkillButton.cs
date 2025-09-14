using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public int skillIndex;
    private SkillManager skillManager;

    void Start()
    {
        skillManager = FindObjectOfType<SkillManager>();
    }

    public void OnClick()
    {
        if (skillManager != null)
        {
            // SkillManager���� ��ų ��ü�� ��û
            skillManager.ReplaceSkill(skillIndex);

            // ���¸� ������ �ʿ䰡 �����Ƿ� GameStateMachine�� ȣ������ �ʽ��ϴ�.
        }
    }
}