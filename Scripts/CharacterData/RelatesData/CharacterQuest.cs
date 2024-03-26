﻿using Cysharp.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MultiplayerARPG
{
    [System.Serializable]
    public partial struct CharacterQuest
    {
        public static readonly CharacterQuest Empty = new CharacterQuest();
        public int dataId;
        public byte randomTasksIndex;
        public bool isComplete;
        public long completeTime;
        public bool isTracking;
        public Dictionary<int, int> killedMonsters;
        public List<int> completedTasks;

        public Dictionary<int, int> ReadKilledMonsters(string killedMonstersString)
        {
            if (killedMonsters == null)
                killedMonsters = new Dictionary<int, int>();
            killedMonsters.Clear();
            string[] splitSets = killedMonstersString.Split(';');
            foreach (string set in splitSets)
            {
                if (string.IsNullOrEmpty(set))
                    continue;
                string[] splitData = set.Split(':');
                if (splitData.Length != 2)
                    continue;
                killedMonsters[int.Parse(splitData[0])] = int.Parse(splitData[1]);
            }
            return killedMonsters;
        }

        public string WriteKilledMonsters()
        {
            using (Utf16ValueStringBuilder stringBuilder = ZString.CreateStringBuilder(true))
            {
                if (killedMonsters != null && killedMonsters.Count > 0)
                {
                    foreach (KeyValuePair<int, int> keyValue in killedMonsters)
                    {
                        stringBuilder.Append(keyValue.Key);
                        stringBuilder.Append(':');
                        stringBuilder.Append(keyValue.Value);
                        stringBuilder.Append(';');
                    }
                }
                return stringBuilder.ToString();
            }
        }

        public List<int> ReadCompletedTasks(string completedTasksString)
        {
            if (completedTasks == null)
                completedTasks = new List<int>();
            completedTasks.Clear();
            string[] splitTexts = completedTasksString.Split(';');
            foreach (string text in splitTexts)
            {
                if (string.IsNullOrEmpty(text))
                    continue;
                completedTasks.Add(int.Parse(text));
            }
            return completedTasks;
        }

        public string WriteCompletedTasks()
        {
            using (Utf16ValueStringBuilder stringBuilder = ZString.CreateStringBuilder(true))
            {
                if (completedTasks != null && completedTasks.Count > 0)
                {
                    foreach (int completedTask in completedTasks)
                    {
                        stringBuilder.Append(completedTask);
                        stringBuilder.Append(';');
                    }
                }
                return stringBuilder.ToString();
            }
        }

        public CharacterQuest Clone()
        {
            CharacterQuest clone = new CharacterQuest();
            clone.dataId = dataId;
            clone.randomTasksIndex = randomTasksIndex;
            clone.isComplete = isComplete;
            clone.completeTime = completeTime;
            clone.isTracking = isTracking;
            // Clone killed monsters
            Dictionary<int, int> killedMonsters = new Dictionary<int, int>();
            foreach (KeyValuePair<int, int> cloneEntry in this.killedMonsters)
            {
                killedMonsters[cloneEntry.Key] = cloneEntry.Value;
            }
            clone.killedMonsters = killedMonsters;
            // Clone complete tasks
            clone.completedTasks = new List<int>(completedTasks);
            return clone;
        }

        public static CharacterQuest Create(int dataId, byte randomTasksIndex)
        {
            return new CharacterQuest()
            {
                dataId = dataId,
                randomTasksIndex = randomTasksIndex,
                isComplete = false,
            };
        }
    }
}
