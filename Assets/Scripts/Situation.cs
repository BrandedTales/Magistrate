using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BT.Variables;
using BT.Events;
using System;

namespace BT.Magistrate
{
    [CreateAssetMenu(menuName = "Situation")]
    public class Situation : ScriptableObject
    {
        public string situationName;
        public float spawnTime;

        public float difficulty;
    }
}