using UnityEngine;

public class SkillButton : MonoBehaviour
{
    public int skillIndex;

    public void OnClick()
    {
        // GameManager�� ����� SkillManager�� ã�Ƽ� �Լ� ȣ��
        SkillManager skillManager = FindObjectOfType<SkillManager>();
        if (skillManager != null)
        {
            // SkillManager���� �� ��ư�� �ε����� �˷��༭ ��ų�� ��ü
            skillManager.ReplaceSkill(skillIndex);
        }

        // ���� ��ų ��ư�� ������ ���´� SkillSelection�� �ӹ����� �˴ϴ�.
    }
}