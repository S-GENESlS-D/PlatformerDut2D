using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour

{
    [SerializeField] private TMP_Text _coinsAmountText;

    public  int CoinsAmount;

    public int _coinsAmount
    {
        get => CoinsAmount;

        set
        {
            CoinsAmount = value;
            _coinsAmountText.text = value.ToString();
        }
    }

    private void Start()
    {
        CoinsAmount = 0;
    }





}
