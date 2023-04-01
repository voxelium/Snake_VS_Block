using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    [SerializeField] private Vector2Int destroyPriceRange;

    private int destroyPrice;
    private int filling;

    public event UnityAction<int> DamageUpdate;

    public int LeftToFill => destroyPrice - filling;


    private void Start()
    {
        destroyPrice = Random.Range(destroyPriceRange.x, destroyPriceRange.y);

        DamageUpdate?.Invoke(LeftToFill);
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

}


