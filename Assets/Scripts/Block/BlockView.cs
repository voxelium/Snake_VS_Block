using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[RequireComponent(typeof (Block))]

public class BlockView : MonoBehaviour
{

    [SerializeField] TMP_Text txtDamage;

    private Block block;


    private void Awake()
    {
        block = GetComponent<Block>();

    }


    private void OnEnable()
    {
        block.DamageUpdate += TxtDamageUpdate;
    }


    private void OnDisable()
    {
        block.DamageUpdate -= TxtDamageUpdate;
    }


    private void TxtDamageUpdate(int damageCount)
    {
        txtDamage.text = damageCount.ToString();
    }


}
