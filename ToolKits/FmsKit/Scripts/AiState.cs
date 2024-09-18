using System.Collections.Generic;
using QFramework;

namespace LostFramework
{
    public class AiState
    {
        private List<AiAction> actions = new List<AiAction>();
        private List<AiDetermine> determines = new List<AiDetermine>();
        internal AiBrain aiBrain;

        public T AddAction<T>() where T:AiAction
        {
            T action = System.Activator.CreateInstance<T>();
            action.aiBrain = aiBrain;
            actions.Add(action);
            return action;
        }

        public T AddDetermine<T>() where T:AiDetermine
        {
            T determine = System.Activator.CreateInstance<T>();
            determine.aiBrain = aiBrain;
            determines.Add(determine);
            return determine;
        }

        internal void Init()
        {
            actions.ForEach(x => x.Init());
            determines.ForEach(x => x.Init());
        }
        internal void Enter()
        {
            actions.ForEach(x => x.Enter());
            determines.ForEach(x => x.Enter());
        }
        internal void Update()
        {
            
            for (int i = 0; i < actions.Count; i++)
            {
                actions[i].Update();
                if(aiBrain.GetCurrentState()!=this)
                    return;
            }

            for (int i = 0; i < determines.Count; i++)
            {
                AiDetermine determine = determines[i];
                bool isSuccess = determine.Update();
                string tag = isSuccess ? determine.TrueTag : determine.FalseTag;
                if (tag.IsNotNullAndEmpty())
                {
                    aiBrain.ChangeState(tag);
                }
                if(aiBrain.GetCurrentState()!=this)
                    return;
                
            }
        }

        internal void FixedUpdate()
        {
            for (int i = 0; i < actions.Count; i++)
            {
                actions[i].FixedUpdate();
                if(aiBrain.GetCurrentState()!=this)
                    return;
            }
        }

        internal void Clear()
        {
            actions.Clear();
            determines.Clear();

            aiBrain = null;

        }

        public void Leave()
        {
            actions.ForEach(x => x.Leave());
            determines.ForEach(x => x.Leave());
        }
    }
}