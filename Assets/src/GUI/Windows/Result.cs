﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Caveman.Players;
using UnityEngine.UI;

namespace Caveman.UI.Windows
{
    public class Result : MonoBehaviour
    {
        public Transform names;
        public Transform kills;
        public Transform deaths;

        private Func<IEnumerable<PlayerModelBase>> getCurrentPlayersModel;
        protected bool isMultiplayer;

        public virtual void Initialization(bool isMultiplayer, Func<IEnumerable<PlayerModelBase>> getCurrentPlayers)
        {
            this.isMultiplayer = isMultiplayer;
            getCurrentPlayersModel = getCurrentPlayers;
        }

        protected  virtual IEnumerator DisplayResult()
        {
            var players = getCurrentPlayersModel();
            var lineIndex = 0;
            foreach (var playerModelBase in players)
            {
                Write(playerModelBase.PlayerCore.Name, names, lineIndex);
                Write(playerModelBase.PlayerCore.DeathCount.ToString(), deaths, lineIndex);
                Write(playerModelBase.PlayerCore.KillCount.ToString(), kills, lineIndex);
                lineIndex++;
            }
            yield return new WaitForSeconds(1f);
        }

        public void Write(string value, Transform parent, int lineIndex)
        {
            var item = parent.GetChild(lineIndex);
            item.GetComponent<Text>().text = value;
            item.gameObject.SetActive(true);
        }
    }
}