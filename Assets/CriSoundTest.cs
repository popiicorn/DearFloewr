using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CriWare;

public class CriSoundTest : MonoBehaviour
{
    public static CriSoundTest Instance { get; private set; }
    [SerializeField]    private Slider soundSlider;
    //private const string soundCategoryName = "Sound";
    [SerializeField] GameObject soundTestPanel;
    bool openPanel = false;
    static float masterVolume =0.8f;
    private const string MasterBusName = "MasterOut";

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

        CriAtomExAsr.SetBusVolume(MasterBusName, masterVolume);
        soundSlider.onValueChanged.AddListener((value) =>
        {
            masterVolume = value;
            CriAtomExAsr.SetBusVolume(MasterBusName, masterVolume);
        });
        soundTestPanel.SetActive(false);
    }

    public void updateMasterVolume()
    {
        // 各UIスライダーの値をボリューム値に反映
        soundSlider.onValueChanged.AddListener((value) => { CriAtomExAsr.SetBusVolume(MasterBusName, masterVolume); });
        
    }

    public void OpenClosePanel()
    {
        if (openPanel==false)
        {
            soundTestPanel.SetActive(true);
            soundSlider.value = masterVolume;
            openPanel = true;

        }

        else if (openPanel == true)
        {
            soundTestPanel.SetActive(false);
            openPanel = false;

        }
    }


}
