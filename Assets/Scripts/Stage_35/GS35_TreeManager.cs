using System.Collections;
using UnityEngine;

public class GS35_TreeManager : Gimmick
{
    [SerializeField] Transform leftPos;
    [SerializeField] Transform rightPos;

    GS35_Flower[] flowers;
    [SerializeField] GameObject cloud;
    [SerializeField] Animator treeRootAnimator;
    [SerializeField] GameObject hole;

    void Start()
    {
        flowers = GetComponentsInChildren<GS35_Flower>();
        foreach (var flower in flowers)
        {
            flower.OnClickAction += CheckFlowerClear;
        }
    }

    void CheckFlowerClear()
    {
        foreach (var flower in flowers)
        {
            if (!flower.IsClicked)
            {
                return;
            }
        }
        //3•bŒã‚Écloud‚ð•\Ž¦
        StartCoroutine(ShowCloud());
    }

    IEnumerator ShowCloud()
    {
        yield return new WaitForSeconds(3);
        cloud.SetActive(true);
    }

    int clickCount;

    public override Transform GetTargetPosition(Vector3 playerPos)
    {
        if (transform.position.x < playerPos.x)
        {
            return rightPos;
        }
        return rightPos;
    }

    public override void Move(Vector3 distance)
    {
        throw new System.NotImplementedException();
    }

    public override void OnGameCharacter(Character character)
    {
        StartCoroutine(Anim(character));
    }

    IEnumerator Anim(Character character)
    {
        character.BusyMode();
        yield return new WaitForSeconds(0.5f);
        character.KickGimmick();
        yield return new WaitForSeconds(0.2f);
        clickCount++;
        treeRootAnimator.Play("Crack_" + clickCount);
        character.SetDefaultMode();
        if (clickCount == 4)
        {
            hole.SetActive(true);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
