using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HighlightSpriteColorChange : MonoBehaviour
{

    public SpriteRenderer _spriteRend;
    public Color32 colorA;
    public Color32 colorB;
    public float colorChangeDuration;
    private string originLayerName;
    private int originOrderInLayer;

    public string layerName;
    public int setOrderInLayerTo;

    // Start is called before the first frame update
    void Start()
    {
        if (_spriteRend == null)
        {
            _spriteRend = this.gameObject.GetComponent<SpriteRenderer>();
        }

        _spriteRend.sortingLayerName = originLayerName;
        _spriteRend.sortingOrder = originOrderInLayer;

        _spriteRend.sortingLayerName = layerName;
        _spriteRend.sortingOrder = originOrderInLayer;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.mimLit == true)
        {
            _spriteRend.DOColor(colorA, colorChangeDuration);
            _spriteRend.sortingLayerName = originLayerName;
            _spriteRend.sortingOrder = originOrderInLayer;
        }
        else
        {
            _spriteRend.DOColor(colorB, colorChangeDuration);
            _spriteRend.sortingLayerName = layerName;
            _spriteRend.sortingOrder = setOrderInLayerTo;
        }
        
    }
}
