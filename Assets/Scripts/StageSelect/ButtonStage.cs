using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonStage : MonoBehaviour
{
    SaveManager.Stage stageData;
    [SerializeField] GameManager.TransitionName transitionName;
    [SerializeField] bool isMovieStage;

    [SerializeField] GameObject notPlayImage;
    [SerializeField] GameObject nextPlayImage;
    [SerializeField] GameObject stageImage;
    [SerializeField] GameObject flowerLock;
    [SerializeField] GameObject flowerGet;

    public UnityAction<int> OnClickButton;

    public void SetStageData(SaveManager.Stage stage)
    {
        stageData = stage;
        SetDalut();

        if (stage.isOpened)
        {
            notPlayImage.SetActive(false);
            nextPlayImage.SetActive(true);
            stageImage.SetActive(false);
            flowerLock.SetActive(false);
            flowerGet.SetActive(false);
        }
        if (stage.isCleared)
        {
            nextPlayImage.SetActive(false);
            stageImage.SetActive(true);
            if (!isMovieStage)
            {
                flowerLock.SetActive(true);
                flowerGet.SetActive(stage.getBonus);
            }
        }
        if (stage.stageNumber == 34)
        {
            flowerLock.SetActive(false);
        }
        SaveManager.Instance.saveData.stages[stage.stageNumber].isMovieStage = isMovieStage;
    }
    void SetDalut()
    {
        notPlayImage.SetActive(true);
        nextPlayImage.SetActive(false);
        stageImage.SetActive(false);
        flowerLock.SetActive(false);
        flowerGet.SetActive(false);
    }

    public void OnClick()
    {
        if (!stageData.isOpened)
        {
            CriManager.instance.PlayObjSE("CloseUI01");
            return;
        }
        BGMManager.Instance.StopBGM();
        CriManager.instance.PlayObjSE("startUI");
        GameManager.Instance.StageSelect(stageData.stageNumber + 1, transitionName);
    }
}
