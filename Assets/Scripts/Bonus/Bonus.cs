using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bonus : MonoBehaviour
{
    [SerializeField] TMP_Text bonusView;
    [SerializeField] private Vector2Int bonusSizeRange;
    private int bonusSize;

    private void Start()
    {
        bonusSize = Random.Range(bonusSizeRange.x, bonusSizeRange.y);

        bonusView.text = bonusSize.ToString();
    }

    public int Collect()
    {
        Destroy(gameObject);
        return bonusSize;
    }
}
