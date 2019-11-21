using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BT.Variables;
using BT.Events;

namespace BT.Magistrate
{
    public class TimeManager : MonoBehaviour
    {
        [SerializeField] FloatReference turnLength;
        [SerializeField] FloatReference gameTime;

        [SerializeField] BoolVariable timerOn;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (timerOn.value) DecreaseTimer();
        }

        public void ResetTimer()
        {
            timerOn.TurnOff();
            gameTime.SetValue(turnLength);
        }

        public void DecreaseTimer()
        {
            if (gameTime <= 0) { return;  }

            float currentTime = gameTime;
            currentTime -= Time.deltaTime;
            //Debug.Log("TimerCountDown: " + currentTime);
            gameTime.SetValue(currentTime);
        }

        public void ToggleTimer()
        {
            timerOn.ToggleValue();
        }

    }
}