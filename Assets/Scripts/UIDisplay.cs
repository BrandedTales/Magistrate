using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BT.Variables;
using BT.Events;
using TMPro;

namespace BT.Magistrate
{
    public class UIDisplay : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI timeDisplay;
        [SerializeField] FloatReference gameTime;

        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("Does this ever get called?");
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log("From the UI: " + gameTime.ToString());
            timeDisplay.text = Mathf.RoundToInt(gameTime).ToString();
        }
    }
}