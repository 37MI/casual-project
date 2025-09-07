using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuffPreviewUI : MonoBehaviour
{
    [Header("���� BuffData (�Ʒ� sources�� ��������� �̰ɷ� 4�� ����)")]
    [SerializeField] private BuffData source;

    [Header("���Ժ� BuffData (����, ũ�� 4�� �ΰ� ���� �ٸ� ���ø� ���� ���� ��)")]
    [SerializeField] private BuffData[] sources; // ����θ� source ���

    [Header("��� TMP �ؽ�Ʈ��")]
    [SerializeField] private TMP_Text Text1;
    [SerializeField] private TMP_Text Text2;
    [SerializeField] private TMP_Text Text3;
    [SerializeField] private TMP_Text Text4;

    // inst1~inst4�� ��Ƶ� ��
    private ActiveBuff[] insts = new ActiveBuff[4];
    private int current = 0; // ���� ȭ�鿡 ������ �ε���(0~3)

    private void Update()
    {
        // �����̽�: inst1~4 ���� ���� ������, current(�⺻ 0��) �����ֱ�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateMany(4);
        }
        ShowCombined(Text1, 1);
        ShowCombined(Text2, 2);
        ShowCombined(Text3, 3);

        // ���� 1~4�� ǥ�� ����� ��ȯ

    }


    string FormatBuff(ActiveBuff b)
    {
        if (b == null) return "";
        string valueStr = (b.modKind == ModKind.Add)
            ? $"+{b.value}"
            : $"+{(b.value <= 1f ? b.value * 100f : b.value)}%";
        return $"{b.targetStat} / {b.modKind} / {valueStr} / {b.remainingTurns}T";
    }

    // �� ��(�Ǵ� ���� ��) �ؽ�Ʈ�� ���� ��ȯ
    string BuildCombinedText(params int[] indices)
    {
        if (indices == null || indices.Length == 0)
            indices = new int[] { 0, 1, 2, 3 }; // �⺻: ����

        var parts = new List<string>();
        foreach (var idx in indices)
        {
            if (idx < 0 || idx >= insts.Length) continue;
            var b = insts[idx];
            if (b == null) continue;
            parts.Add($"{idx + 1}) {FormatBuff(b)}");
        }

        // �ٹٲ����� ��ġ��(�� �ٷθ� ���ϸ� " | " �� �ٲټ���)
        return string.Join("\n", parts);
    }

    // TMP_Text�� �ٷ� ���ִ� ���� �Լ�
    void ShowCombined(TMP_Text label, params int[] indices)
    {
        if (!label) return;
        label.text = BuildCombinedText(indices);
    }
    private void GenerateMany(int n)
    {
        for (int i = 0; i < n && i < insts.Length; i++)
        {
            var src = (sources != null && i < sources.Length && sources[i] != null)
                        ? sources[i]
                        : source;

            insts[i] = src ? src.CreateInstance() : null;
        }
    }

    // �ʿ��ϸ� �ܺο��� inst1~4 ���� ����
    public ActiveBuff GetInst(int i) =>
        (i >= 0 && i < insts.Length) ? insts[i] : null;
}
