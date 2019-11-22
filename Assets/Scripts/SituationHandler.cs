using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BT.Variables;
using Doozy.Engine.UI;
using BT.Events;
using System;


namespace BT.Magistrate
{
    public class SituationHandler : MonoBehaviour
    {

        public float situationCountdown;
        [SerializeField] TMPro.TextMeshProUGUI countdownLabel;


        // Update is called once per frame
        void Update()
        {
            if (situationCountdown > 0) situationCountdown -= Time.deltaTime;
            countdownLabel.text = Mathf.RoundToInt(situationCountdown).ToString();
        }
    }
}