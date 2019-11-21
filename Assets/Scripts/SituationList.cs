using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BT.Variables;
using BT.Events;
using System;

namespace BT.Magistrate
{
    [CreateAssetMenu(menuName = "SituationList")]
    public class SituationList : ScriptableObject
    {
        public List<Situation> situations = new List<Situation>();

        public int Count()
        {
            return situations.Count;
        }

    }
}