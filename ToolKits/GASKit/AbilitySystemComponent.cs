using System;
using System.Collections.Generic;
using UnityEngine;

namespace LostFrameWork.GAS
{
    /// <summary>
    /// 技能系统基本组件，技能的释放和执行必须依靠该系统
    /// </summary>
    public class AbilitySystemComponent:MonoBehaviour
    {
        public List<string> OwnTag = new List<string>();
        private Dictionary<string, int> ownTags = new Dictionary<string, int>();
        private List<AbilityHandle> _ownAbilities = new List<AbilityHandle>();
        private List<AbilityHandle> activeAbilies = new List<AbilityHandle>();
        private List<AbilityHandle> removeAbilies = new List<AbilityHandle>();
        private List<EffectHandle> _ownEffects = new List<EffectHandle>();
        private List<EffectHandle> removeEffects = new List<EffectHandle>();
        
        public AbilityHandle GiveAbility(AbilityBase ability)
        {
            AbilityHandle handle = new AbilityHandle();
            handle.ability = ability;
            handle.abilitySystemComponent = this;
            _ownAbilities.Add(handle);
            return handle;
        }
        
        public AbilityHandle GiveAndTryActiveAbility(AbilityBase ability)
        {
            AbilityHandle handle = GiveAbility(ability);
            handle.ActiveAbility();
            return handle;
        }

        public void ActiveAbility(AbilityHandle handle)
        {
            handle.ability.ActiveAbility();
            activeAbilies.Add(handle);
        }

        public void RemoveAbility(AbilityHandle handle)
        {
            //先终止技能
            removeAbilies.Add(handle);
        }

        public void ApplyEffect(EffectHandle handle)
        {
            handle.effect.Apply();
            _ownEffects.Add(handle);
        }

        public void RemoveEffect(EffectHandle handle)
        {
            removeEffects.Add(handle);
        }

        private void Update()
        {
            //移除技能
            if (removeAbilies.Count > 0)
            {
                for (int i = 0; i < removeAbilies.Count; i++)
                {
                    AbilityHandle handle = removeAbilies[i];
                    activeAbilies.Remove(handle);
                    _ownAbilities.Remove(handle);
                }
                removeAbilies.Clear();
            }
            //刷新激活的技能
            for (int i = 0; i < activeAbilies.Count; i++)
            {
                activeAbilies[i].ability.UpdateAbility();
            }
            //移除效果
            //刷新效果
        }
    }
}