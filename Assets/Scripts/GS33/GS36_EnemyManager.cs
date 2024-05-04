using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS36_EnemyManager : MonoBehaviour
{
    [SerializeField] GS36_EnemyAttack enemyAttack;
    // 3�̉e���Ǘ�
    // �Ԃ��炢���Ƃ��ɐ������Ă���e���U�����s��
    [SerializeField] List<GS36_Enemy> shadows = new List<GS36_Enemy>();

    private void Awake()
    {
        enemyAttack.OnAttacked += OnAttacked;
    }

    public void AttackAction()
    {
        // �������Ă���e�������_���Ɏ擾
        List<GS36_Enemy> enemies = shadows.FindAll(s => s.IsAlive);
        if (enemies.Count == 0) return;

        int index = Random.Range(0, enemies.Count);
        for (int i = 0; i < enemies.Count; i++)
        {
            if (!enemies[i].IsAlive)
            {
                continue;
            }
            if (index == i)
            {
                enemies[index].Attack();
                continue;
            }
            enemies[i].Move();
        }
    }

    public void AttackAnim()
    {
    }

    public void OnAttacked(bool attack)
    {
        if (attack)
        {
            shadows.RemoveAt(Random.Range(0, shadows.Count));
        }
        foreach (var shadow in shadows)
        {
            shadow.ReShow();
        }
        if (shadows.Count == 0)
        {
            GameManager.Instance.GameClear();
        }
    }
}
