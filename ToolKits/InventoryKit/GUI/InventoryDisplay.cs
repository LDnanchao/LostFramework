using System;
using System.Collections.Generic;
using UnityEngine;

namespace LostFramework
{
    public class InventoryDisplay:MonoBehaviour,IInventoryDisplay,ILEventListener<InventoryEvent>
    {
        public IInventory inventory;
        public List<InventorySlot> SlotContainer { get;protected set; }
        protected InventorySlot _currentlySelectedSlot;
        private void Start()
        {
            if (inventory != null)
            {
                UpdateInventory();
            }
        }
        
        public void OnMMEvent(InventoryEvent eventType)
        {
	        throw new NotImplementedException();
        }
        private void OnEnable()
        {
	        this.LEventStartListening();
        }

        private void OnDisable()
        {
	        this.LEventStopListening();
        }

        private void UpdateInventory()
        {
	        throw new NotImplementedException();
        }

        public void SetInventory(Inventory inventory)
        {
            this.inventory = inventory;
            UpdateInventory();
        }
       
        /// <summary>
		/// 返回当前选定的库存槽
		/// </summary>
		/// <returns>所选库存槽.</returns>
		public virtual InventorySlot CurrentlySelectedInventorySlot()
		{
			return  _currentlySelectedSlot;
		}

		/// <summary>		
		/// 将焦点设置在清单的第一项上	
		/// </summary>		
		public virtual void Focus()
		{
		}
		/// <summary>
		/// 设置当前选定的插槽
		/// </summary>
		/// <param name="slot">Slot.</param>
		public virtual void SetCurrentlySelectedSlot(InventorySlot slot)
		{
			_currentlySelectedSlot = slot;
		}
		

		/// <summary>
		/// Disables all the slots in the inventory display, except those from a certain class
		/// </summary>
		/// <param name="itemClass">Item class.</param>
		public virtual void DisableAllBut(ItemClasses itemClass)
		{
			throw  new NotImplementedException();
		}

		/// <summary>
		/// Enables back all slots (usually after having disabled some of them)
		/// </summary>
		public virtual void ResetDisabledStates()
		{
			throw  new NotImplementedException();
		}

		
    }
}