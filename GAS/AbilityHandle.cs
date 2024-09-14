namespace LostFrameWork.GAS
{
    /// <summary>
    /// AbilityHandle 持有对应的AbilityComponent和Ability
    /// </summary>
    public struct AbilityHandle
    {
        public AbilitySystemComponent abilitySystemComponent;
        public AbilityBase ability;

        /// <summary>
        /// 激活技能
        /// </summary>
        public void ActiveAbility()
        {
            abilitySystemComponent.ActiveAbility(this);
        }

        /// <summary>
        /// 移除技能
        /// </summary>
        public void RemoveAbility()
        {
            abilitySystemComponent.RemoveAbility(this);
        }
    }
}