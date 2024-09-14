namespace LostFrameWork.GAS
{
    public enum AbilityState
    {
        Success,
        Fail
    }
    /// <summary>
    /// 基础技能
    /// </summary>
    public abstract class AbilityBase
    {
       
        private AbilitySystemComponent owner;
        protected AbilitySystemComponent Owner => owner;
        protected bool isActive = false;
        
        /// <summary>
        /// 激活技能
        /// </summary>
        public virtual void ActiveAbility()
        {
            
        }

        /// <summary>
        /// 每帧刷新执行，仅在技能执行时，执行
        /// </summary>
        public virtual void UpdateAbility()
        {
            
        }
        /// <summary>
        /// 结束技能
        /// </summary>
        /// <param name="abilityState"></param>
        protected void EndAbility(AbilityState abilityState)
        {
            isActive = false;
        }

        protected EffectHandle ApplyEffectToTarget(AbilitySystemComponent target,EffectBase effect)
        {
            EffectHandle handle = new EffectHandle();
            handle.owner = Owner;
            handle.target = target;
            handle.effect = effect;
            target.ApplyEffect(handle);
            return handle;
        }
    }
}