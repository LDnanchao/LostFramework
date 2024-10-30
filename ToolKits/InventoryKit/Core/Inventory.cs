using System.Collections.Generic;

namespace LostFramework
{
    //需要支持事件
    public class Inventory:IInventory
    {
        public string PlayerID { get; set; }
        public string InventoryName { get; set; }
        public bool AutoRemoveEmpty { get; set; }
        public bool Unlimited { get; set; }
        

        private List<InventoryItem> _inventoryItems;


        public bool AddItem(InventoryItem itemToAdd, int quantity)
        {
            throw new System.NotImplementedException();
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