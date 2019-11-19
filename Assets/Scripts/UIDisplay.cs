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
        [SerializeField] BoolVariable timerOn;

        [SerializeField] GameEvent resetTimerEvent;
        [SerializeField] GameEvent toggleTimerEvent;

        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("Does this ever get called?");
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log("From the UI: " + gameTime.ToString());
            if (timerOn.value)
                timeDisplay.color = Color.white;
            else
                timeDisplay.color = Color.red;

            timeDisplay.text = Mathf.RoundToInt(gameTime).ToString();
        }

        public void ResetTimer()
        {
            resetTimerEvent.Raise();
        }

        public void ToggleTimer()
        {
            Debug.Log("Toggle Button pushed.");
            toggleTimerEvent.Raise();
        }
    }
}