using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BT.Variables;
using BT.Events;

namespace BT.Magistrate
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] FloatReference turnLength;
        [SerializeField] FloatReference gameTime;

        // Start is called before the first frame update
        void Start()
        {
            ResetTimer();
        }

        // Update is called once per frame
        void Update()
        {
            decreaseTimer();
        }

        public void ResetTimer()
        {
            gameTime.SetValue(turnLength);
        }

        public void decreaseTimer()
        {
            if (gameTime <= 0) { return;  }

            float currentTime = gameTime;
            currentTime -= Time.deltaTime;
            Debug.Log("TimerCountDown: " + currentTime);
            gameTime.SetValue(currentTime);
        }

    }
}