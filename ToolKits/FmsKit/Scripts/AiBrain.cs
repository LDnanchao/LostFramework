using System.Collections.Generic;
using UnityEngine;

namespace LostFramework
{
    public class AiBrain
    {
        private Dictionary<string, AiState> states;
        /// <summary>
        /// 目标
        /// </summary>
        public GameObject target;
        /// <summary>
        /// 拥有者
        /// </summary>
        public GameObject owner;

        private AiState activeState = null;
        public AiBrain(GameObject owner)
        {
            this.owner = owner;
            states = new Dictionary<string, AiState>();
        }
        public AiState InitState(string key)
        {
            if (states.ContainsKey(key))
            {
                Debug.Log($"AiBrain 存入重复key：{key}");
                return states[key];
            }
            AiState state = new AiState();
            state.aiBrain = this;
            states.Add(key,state);
            return state;
        }

        public void Update()
        {
            activeState?.Update();
        }

        public void FixedUpdate()
        {
            activeState?.FixedUpdate();
        }

        public void Clear()
        {
            Stop();
            foreach (var state in states)
            {
                state.Value.Clear();
            }
            target = null;
            owner = null;
            states.Clear();
            states = null;
            activeState = null;
        }

        private void Stop()
        {
            activeState = null;
        }

        public AiState GetCurrentState()
        {
            return activeState;
        }

        public void StartState(string tag)
        {
            foreach (var state in states)
            {
                state.Value.Init();
            }

            if (states.ContainsKey(tag))
            {
                activeState = states[tag] ;
                states[tag].Enter();
            }
            else
            {
                Debug.LogWarning($"状态缺少 {tag}");
                activeState = null;
            }
        }

        public void ChangeState(string tag)
        {
            activeState.Leave();
            if (states.ContainsKey(tag))
            {
                activeState = states[tag] ;
                states[tag].Enter();
            }
            else
            {
                Debug.LogWarning($"状态缺少 {tag}");
                activeState = null;
            }
        }
    }
}