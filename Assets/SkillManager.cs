using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Skill
{
    public int id;
    public string skillName;
    public Sprite skillSprite;
}

public class SkillManager : MonoBehaviour
{
    public List<Skill> allSkills;
    public List<Image> currentSkillIcons;

    private List<Skill> currentSkills = new List<Skill>();

    // GameStateMachine�� ȣ���ϴ� �Լ�
    public void ResetSkills()
    {
        currentSkills.Clear();
        List<Skill> skillDeck = new List<Skill>(allSkills);

        for (int i = 0; i < currentSkillIcons.Count; i++)
        {
            if (skillDeck.Count > 0)
            {
                int randomIndex = Random.Range(0, skillDeck.Count);
                Skill newSkill = skillDeck[randomIndex];
                currentSkills.Add(newSkill);
                skillDeck.RemoveAt(randomIndex);
            }
        }
        UpdateSkillIcons();
    }

    // SkillButton�� ȣ���Ͽ� Ư�� �ε����� ��ų�� ��ü�ϴ� �Լ�
    public void ReplaceSkill(int indexToReplace)
    {
        if (indexToReplace < currentSkills.Count)
        {
            int randomIndex = Random.Range(0, allSkills.Count);
            Skill newSkill = allSkills[randomIndex];

            currentSkills[indexToReplace] = newSkill;
            currentSkillIcons[indexToReplace].sprite = newSkill.skillSprite;
        }
    }

    private void UpdateSkillIcons()
    {
        for (int i = 0; i < currentSkillIcons.Count; i++)
        {
            if (i < currentSkills.Count)
            {
                currentSkillIcons[i].sprite = currentSkills[i].skillSprite;
                currentSkillIcons[i].enabled = true;
            }
            else
            {
                currentSkillIcons[i].enabled = false;
            }
        }
    }
}