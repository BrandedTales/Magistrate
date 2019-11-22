using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BT.Variables;
using Doozy.Engine.UI;
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

            if (gameTime < (turnLength - currentSituation.baseSpawnTime))
            {
                Debug.Log("Situation: " + currentSituation.situationName);
                ShowPopup();
                currentSituation = NextSituation();
            }
        }

        public void SortSituations()
        {
            turnSituations.Sort(delegate (Situation a, Situation b)
            {
                return a.baseSpawnTime.CompareTo(b.baseSpawnTime);
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

        public void ShowPopup()
        {
            UIPopup popup = UIPopup.GetPopup("SituationAlert");
            if (popup == null)
                return;


            popup.Data.SetLabelsTexts(currentSituation.timeout.ToString());
            popup.GetComponent<SituationHandler>().situationCountdown = currentSituation.timeout;

            popup.Container.StartPosition.x = UnityEngine.Random.Range(-500,500);
            popup.Container.StartPosition.y = UnityEngine.Random.Range(-50,50);

            popup.AutoHideAfterShow = true;
            popup.AutoHideAfterShowDelay = currentSituation.timeout;

            popup.Show();
        }

    }



}