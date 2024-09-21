using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS33_Background_WT : MonoBehaviour
{
    [SerializeField] Character character;
    [SerializeField] AnimatorOverrideController animatorOverrideController;
    [SerializeField] AnimatorOverrideController defaultAnimatorOverrideController;
    [SerializeField] GameObject triggerObj;
    [SerializeField] BGMManager bGMManager;
    public void Show()
    {
        gameObject.SetActive(true);
        // �L�����N�^�[�̈ʒu���炘��200
        transform.position = new Vector3(character.transform.position.x + 200, transform.position.y, transform.position.z);
    }

    // Character��Animator��animatorOverrideController�ɕς���
    public void ChangeAnimator()
    {
        character.SetAnim(animatorOverrideController);
    }
    public void ChangeDefaultAnimator()
    {
        character.SetAnim(defaultAnimatorOverrideController);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // �L�����N�^�[�����̃R���C�_�[�������Ȃ�ChangeAnimator
        if (collision.GetComponent<Character>())
        {
            if (collision.transform.position.x < triggerObj.transform.position.x)
            {
                ChangeAnimator();
                bGMManager.OnBGMAisac("TimeHole");

            }
            else
            {
                ChangeDefaultAnimator();
                bGMManager.OffBGMAisac("TimeHole");
            }
        }

    }
}
