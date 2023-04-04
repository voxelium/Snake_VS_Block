using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof (SpriteRenderer))]

public class Block : MonoBehaviour
{
    [SerializeField] private Vector2Int destroyPriceRange;
    [SerializeField] private Color[] _colors;

    private int destroyPrice;
    private int filling;
    private SpriteRenderer _spriteRenderer;

    public event UnityAction<int> DamageUpdate;

    public int LeftToFill => destroyPrice - filling;


    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        destroyPrice = Random.Range(destroyPriceRange.x, destroyPriceRange.y);

        DamageUpdate?.Invoke(LeftToFill);


        SetColor(_colors[Random.Range(0, _colors.Length)]);
    }


    public void Fill()
    {
        filling ++;
        DamageUpdate?.Invoke(LeftToFill);

        if (filling == destroyPrice)
        {
            Destroy(gameObject);
        }
    }


    private void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }

}


