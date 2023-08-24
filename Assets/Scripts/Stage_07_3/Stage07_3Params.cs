using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage07_3Params : MonoBehaviour
{
    [SerializeField] float characterSpeed;
    [SerializeField] float timer;
    [SerializeField] Character character;
    [SerializeField] float shadowSpeed;
    public float CharacterSpeed { get => characterSpeed; }


    public static Stage07_3Params Instance { get; private set; }
    public float Timer { get => timer; }
    public float ShadowSpeed { get => shadowSpeed; }

    private void Awake()
    {
        Instance = this;
        character.SetParams(characterSpeed);
    }
}
