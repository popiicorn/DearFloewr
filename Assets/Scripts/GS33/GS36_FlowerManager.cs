using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS36_FlowerManager : MonoBehaviour
{
    [SerializeField] GS36_Flower[] flowers;
    int selectedFlowerId;

    public int SelectedFlowerId { get => selectedFlowerId; }
    public GS36_Flower CurrentFlower { get => flowers[selectedFlowerId]; }
    public GS36_Flower[] Flowers { get => flowers; }

    private void Start()
    {
        for (int i = 0; i < flowers.Length; i++)
        {
            flowers[i].OnSelectedEvent += OnSelected;
        }
    }

    void OnSelected(int id)
    {
        foreach (var flower in flowers)
        {
            flower.SetLock(true);
        }
        selectedFlowerId = id;
    }

    public void ResetFlower()
    {
        foreach (var flower in flowers)
        {
            flower.SetLock(false);
        }
        CurrentFlower.ResetToInit();
    }
}
