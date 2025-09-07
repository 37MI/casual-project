using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatType { Attack, Defense, Speed, HP }
public enum ModKind { Add, Mult }  // Add: ���� ��ġ, Mult: ����

[CreateAssetMenu(fileName = "New Buff", menuName = "Game/Buff Data")]
public class BuffData : ScriptableObject
{
    [Header("�⺻ ����")]
    public int id;                // ���� ���� ID
    public string buffName;       // ���� �̸� (UI ǥ�ÿ�)
    public string description;    // ���� (���� ��)

    [Header("ȿ�� ���")]
    public StatType targetStat;   // � ���ȿ� ����Ǵ���
    public ModKind modKind;       // ���� �߰�����, ���� ����������

    [Header("ȿ�� ����")]
    public int minDuration;       // ������ �ּҰ�
    public int maxDuration;       // ������ �ִ밪
    public int minEffect;         // ȿ�� �ּҰ�
    public int maxEffect;         // ȿ�� �ִ밪

    [Header("����")]
    public Sprite icon;           // ������ �̹���
    public Color buffColor;       // UI ������ (���û���)

    // ���� ������ �� ���� ������ ActiveBuff ��ȯ
    public ActiveBuff CreateInstance()
    {
        int duration = Random.Range(minDuration, maxDuration + 1);
        int effectValue = Random.Range(minEffect, maxEffect + 1);

        return new ActiveBuff(targetStat, modKind, effectValue, duration);
    }
}