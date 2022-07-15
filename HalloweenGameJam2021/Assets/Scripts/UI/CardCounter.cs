using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counter;

    private void Awake()
    {
        counter = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        counter.text = WinLevel.count + "/" + WinLevel.cardsToWin;
    }
}
