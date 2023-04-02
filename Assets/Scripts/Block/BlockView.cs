using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[RequireComponent(typeof (Block))]

public class BlockView : MonoBehaviour
{

    [SerializeField] TMP_Text txtHealth;

    private Block block;


    private void Awake()
    {
        block = GetComponent<Block>();

    }


    private void OnEnable()
    {
        block.DamageUpdate += TxtHealthUpdate;
    }


    private void OnDisable()
    {
        block.DamageUpdate -= TxtHealthUpdate;
    }


    private void TxtHealthUpdate(int damageCount)
    {
        txtHealth.text = damageCount.ToString();
    }


}
