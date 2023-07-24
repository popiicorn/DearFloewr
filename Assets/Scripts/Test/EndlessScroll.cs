using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndlessScroll : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float parallaxEffect;
    [SerializeField] int panelBetween;
    [SerializeField] bool isSelfSetting;
    [SerializeField] float selfSize;
    float length, startpos;

    void Start()
    {
        // 背景画像のx座標
        startpos = transform.position.x;
        // 背景画像のx軸方向の幅
        length = spriteRenderer.bounds.size.x * panelBetween;
        if (isSelfSetting)
        {
            length = selfSize * panelBetween;
        }
    }
    private void FixedUpdate()
    {
        // 無限スクロールに使用するパラメーター
        float temp = (Camera.main.transform.position.x * (1 - parallaxEffect));
        // 背景の視差効果に使用するパラメーター
        float dist = (Camera.main.transform.position.x * parallaxEffect);
        // 視差効果を与える処理
        // 背景画像のx座標をdistの分移動させる
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
        // 無限スクロール
        // 画面外になったら背景画像を移動させる
        if (temp > startpos + length)
        {
            startpos += length;
        }
        else if (temp < startpos - length)
        {
            startpos -= length;
        }
    }
}