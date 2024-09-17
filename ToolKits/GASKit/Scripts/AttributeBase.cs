using QFramework;
using UnityEngine;

namespace LostFrameWork
{
    /// <summary>
    /// 基础属性
    /// </summary>
    public class AttributeBase:MonoBehaviour
    {
        public int initHealth;
        public int initMaxHealth;
        public BindableProperty<int> health;
        public BindableProperty<int> maxHealth;
    }
}