using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BT.Variables;
using BT.Events;
using System;



namespace BT.Magistrate
{
    public class SituationManager : MonoBehaviour
    {

        [SerializeField] FloatReference gameTime;
        [SerializeField] FloatReference turnLength;

        bool eventFired;
        Situation currentSituation;

        [SerializeField] SituationList situations;
        [SerializeField] int situationCount;
        List<Situation> turnSituations = new List<Situation>();

        // Start is called before the first frame update
        void Start()
        {
            BuildSituationList();
        }

        public void BuildSituationList()
        {
            turnSituations.Clear();
            for (int i=0;i<situationCount;i++)
            {
                turnSituations.Add(situations.situations[UnityEngine.Random.Range(0, situations.Count())]);
            }
            SortSituations();
            currentSituation = NextSituation();
        }

        // Update is called once per frame
        void Update()
        {
            if (currentSituation == null) return;

            if (gameTime < (turnLength - currentSituation.spawnTime))
            {
                Debug.Log("Situation: " + currentSituation.situationName);
                currentSituation = NextSituation();
            }
        }

        public void SortSituations()
        {
            turnSituations.Sort(delegate (Situation a, Situation b)
            {
                return a.spawnTime.CompareTo(b.spawnTime);
            }
            );
        }

        public Situation NextSituation()
        {
            Situation retVal = null;
            if (turnSituations.Count > 0)
            {
                retVal = turnSituations[0];
                turnSituations.RemoveAt(0);
            }
            return retVal;

        }

    }



}