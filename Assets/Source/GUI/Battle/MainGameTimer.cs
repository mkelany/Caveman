﻿using System;
using Caveman.Setting;
using UnityEngine;
using UnityEngine.UI;

namespace Caveman.UI.Battle
{
    public class MainGameTimer : MonoBehaviour
    {
        public Action RoundEnded;

        private Text value;

        public void Start()
        {
            value = GetComponent<Text>();
        }

        public void Update()
        {
            var remainTime = Settings.RoundTime - Math.Floor(Time.timeSinceLevelLoad);
            var m = Convert.ToInt32(remainTime/60);
            var s = Convert.ToInt32(remainTime%60);
            if (m < 60)
            {
                m = 0;
            }

            value.text = m + ":" + s;

            if (remainTime < 0 && RoundEnded != null)
            {
                RoundEnded();
            }
        }
    }
}
