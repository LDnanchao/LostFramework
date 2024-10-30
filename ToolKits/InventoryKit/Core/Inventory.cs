using System.Collections.Generic;

namespace LostFramework
{
    //需要支持事件
    public class Inventory:IInventory
    {
        private bool _isUnlimited;
        private bool _autoRemoveEmpty;
        private List<InventoryItem> _inventoryItems;
        public bool IsAutoRemoveEmpty()
        {
            return  _autoRemoveEmpty;
        }

        public void SetAutoRemoveEmpty(bool autoRemove)
        {
            _autoRemoveEmpty = autoRemove;
        }

        public bool IsUnlimited()
        {
            return  _isUnlimited;
        }

        public void SetUnlimited(bool unlimited)
        {
            _isUnlimited = unlimited;
        }

        public bool AddItem(InventoryItem itemToAdd, int quantity)
        {
            if (itemToAdd == null)
                return false;
            List<int> list = InventoryContains(itemToAdd.ItemID);
 
            
            return  false;
        }

        public bool AddItemAt(InventoryItem itemToAdd, int quantity, int destinationIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool MoveItem(int startIndex, int endIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool MoveItemToInventory(int startIndex, Inventory targetInventory, int endIndex = -1)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveItem(int i, int quantity)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveItemByID(string itemID, int quantity)
        {
            throw new System.NotImplementedException();
        }

        public bool DestroyItem(int i)
        {
            throw new System.NotImplementedException();
        }

        public void EmptyInventory()
        {
            throw new System.NotImplementedException();
        }

        public int CapMaxQuantity(InventoryItem itemToAdd, int newQuantity)
        {
            throw new System.NotImplementedException();
        }

        public void ResizeArray(int newSize)
        {
            throw new System.NotImplementedException();
        }

        public int GetQuantity(string searchedItemID)
        {
            throw new System.NotImplementedException();
        }

        public List<int> InventoryContains(string searchedItemID)
        {
            throw new System.NotImplementedException();
        }

        public List<int> InventoryContains(ItemClasses searchedClass)
        {
            throw new System.NotImplementedException();
        }

    }
}