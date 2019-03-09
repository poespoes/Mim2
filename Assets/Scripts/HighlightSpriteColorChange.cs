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
    
    // Start is called before the first frame update
    void Start()
    {
        if (_spriteRend == null)
        {
            _spriteRend = this.gameObject.GetComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.mimLit == true)
        {
            _spriteRend.DOColor(colorA, colorChangeDuration);
        }
        else
        {
            _spriteRend.DOColor(colorB, colorChangeDuration);
        }
        
    }
}
