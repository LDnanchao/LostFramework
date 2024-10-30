using System;
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
        

        private List<InventoryItem> _inventoryItems = new List<InventoryItem>();
        private int _maxSize;

        /// <summary>
        /// 当前库存不支持重复占位，为无限堆叠
        /// </summary>
        /// <param name="itemToAdd"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public bool AddItem(InventoryItem itemToAdd, int quantity)
        {
            List<int> list = InventoryContains(itemToAdd.ItemID);
            int index = -1;
            //存在则直接加，不存在，则创建新的
            if (list.Count > 0)
            {
                index = list[0];
                _inventoryItems[index].Quantity += quantity;
                InventoryEvent.Trigger(InventoryEventType.ContentChanged,InventoryName,_inventoryItems[index],quantity,index,PlayerID);
                return  true;
            }
            //找到第一个空位，并加入，如果没有空位则失败
            
            for (int i = 0; i < _inventoryItems.Count; i++)
            {
                if (_inventoryItems[i]==null)
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                var item = itemToAdd.Copy();
                item.Quantity = quantity;
                _inventoryItems[index] = item;
                InventoryEvent.Trigger(InventoryEventType.ContentChanged,InventoryName,_inventoryItems[index],quantity,index,PlayerID);
                return  true;
            }
            
            //检查背包是非为无限制，无限制则直接追加新的，有限制则检查是否超过上限
            if (Unlimited ||_inventoryItems.Count < _maxSize)
            {
                var item = itemToAdd.Copy();
                item.Quantity = quantity;
                _inventoryItems.Add(item);
                index = _inventoryItems.Count - 1;
                InventoryEvent.Trigger(InventoryEventType.ContentChanged,InventoryName,_inventoryItems[index],quantity,index,PlayerID);
                return  true;
            }
            return false;
        }

        public bool AddItemAt(InventoryItem itemToAdd, int quantity, int destinationIndex)
        {
            if (destinationIndex == -1)
            {
                return AddItem(itemToAdd, quantity);
            }
            if (_inventoryItems[destinationIndex] == null)
            {
                _inventoryItems[destinationIndex] = itemToAdd.Copy();
                _inventoryItems[destinationIndex].Quantity = quantity;
                InventoryEvent.Trigger(InventoryEventType.ContentChanged,InventoryName,_inventoryItems[destinationIndex],quantity,destinationIndex,PlayerID);
                return  true;
            }

            if (_inventoryItems[destinationIndex].ItemID == itemToAdd.ItemID)
            {
                _inventoryItems[destinationIndex].Quantity += quantity;
                InventoryEvent.Trigger(InventoryEventType.ContentChanged,InventoryName,_inventoryItems[destinationIndex],quantity,destinationIndex,PlayerID);
                return  true;
            }
            
            return false;
        }

        public bool MoveItem(int startIndex, int endIndex)
        {
            if (_inventoryItems.Count <= endIndex - 1)
                return false;

            var startItem = _inventoryItems[startIndex];
            var endItem = _inventoryItems[endIndex];
            _inventoryItems[startIndex] = endItem;
            _inventoryItems[endIndex] = startItem;
            InventoryEvent.Trigger(InventoryEventType.ContentChanged,InventoryName,_inventoryItems[startIndex],0,startIndex,PlayerID);
            InventoryEvent.Trigger(InventoryEventType.ContentChanged,InventoryName,_inventoryItems[endIndex],0,endIndex,PlayerID);
            return true;
        }

        public bool MoveItemToInventory(int startIndex, Inventory targetInventory, int endIndex = -1)
        {
            var targetItem = _inventoryItems[endIndex];
            //先检查目标背包是否可以添加新的
            if (targetInventory.CheckCanAddItemAt(targetItem, targetItem.Quantity, endIndex))
            {
                RemoveItem(startIndex, targetItem.Quantity);
                InventoryEvent.Trigger(InventoryEventType.ContentChanged,InventoryName,targetItem,-targetItem.Quantity,startIndex,PlayerID);
                targetInventory.AddItemAt(targetItem, targetItem.Quantity, endIndex);
                InventoryEvent.Trigger(InventoryEventType.ContentChanged,targetInventory.InventoryName,targetInventory._inventoryItems[endIndex],targetItem.Quantity,endIndex,targetInventory.PlayerID);
            }
            return  false;
        }

        /// <summary>
        /// 检查是否可以添加物品
        /// </summary>
        /// <param name="itemToAdd"></param>
        /// <param name="quantity"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        private bool CheckCanAddItemAt(InventoryItem itemToAdd, int quantity, int endIndex)
        {
            if (endIndex == -1 && (Unlimited || _inventoryItems.Count < _maxSize)) return  true;

            if (_inventoryItems[endIndex] == null)
            {
                return  true;
            }

            if (_inventoryItems[endIndex].ItemID == itemToAdd.ItemID)
            {
                return  true;
            }
            
            return false;
        }

        public bool RemoveItem(int i, int quantity)
        {
            if (_inventoryItems[i] == null)
            {
                return false;
            }

            if (_inventoryItems[i].Quantity < quantity)
            {
                return false;
            }
            var targetItem = _inventoryItems[i];
            _inventoryItems[i].Quantity -= quantity;
            if (_inventoryItems[i].Quantity <= 0)
            {
                _inventoryItems[i] = null;
            }
            InventoryEvent.Trigger(InventoryEventType.ContentChanged,InventoryName,targetItem,-quantity,i,PlayerID);
            return true;
        }

        public bool RemoveItemByID(string itemID, int quantity)
        {
            List<int> list = InventoryContains(itemID);
            if (list.Count == 0) return false;
            int index = list[0];
            var targetItem = _inventoryItems[index];
            if (targetItem.Quantity >= quantity)
            {
                targetItem.Quantity -= quantity;
            }

            if (targetItem.Quantity <= 0)
            {
                _inventoryItems[index] = null;
            }
            InventoryEvent.Trigger(InventoryEventType.ContentChanged,InventoryName,targetItem,-quantity,index,PlayerID);
            return true;
        }

        public bool DestroyItem(int i)
        {
            if (i >= _inventoryItems.Count) return false;
            _inventoryItems[i] = null;
            InventoryEvent.Trigger(InventoryEventType.Destroy,InventoryName,_inventoryItems[i],0,i,PlayerID);
            return true;
        }

        public void EmptyInventory()
        {
            for (int i = 0; i < _inventoryItems.Count; i++)
            {
                var target = _inventoryItems[i];
                _inventoryItems[i] = null;
                InventoryEvent.Trigger(InventoryEventType.Destroy,InventoryName,target,0,i,PlayerID);
            }
        }

        public int CapMaxQuantity(InventoryItem itemToAdd, int newQuantity)
        {
            return newQuantity;
        }

        public void ResizeArray(int newSize)
        {
            List<InventoryItem> newList = new List<InventoryItem>(newSize);
            List<InventoryItem> tempList = new List<InventoryItem>();
            if (_inventoryItems.Count > newSize)
            {
                //背包超出，截断满足当前数量的背包
                tempList.AddRange(_inventoryItems.GetRange(0, newSize));
            }
            else
            {
                tempList.AddRange(_inventoryItems);
            }
            for (int i = 0; i < tempList.Count; i++)
            {
                newList[i] = tempList[i];
            }
            tempList.Clear();
            _inventoryItems.Clear();
            _inventoryItems = newList;
            _maxSize = newSize;
        }

        public int GetQuantity(string searchedItemID)
        {
            List<int> list = InventoryContains(searchedItemID);
            if (list.Count == 0) return 0;
            return _inventoryItems[list[0]].Quantity;
        }

        public List<int> InventoryContains(string searchedItemID)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < _inventoryItems.Count; i++)
            {
                if (_inventoryItems[i].ItemID == searchedItemID)
                {
                    list.Add(i);
                }
            }
            return list;
        }

        public List<int> InventoryContains(ItemClasses searchedClass)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < _inventoryItems.Count; i++)
            {
                if (_inventoryItems[i].ItemClass == searchedClass)
                {
                    list.Add(i);
                }
            }
            return list;
        }

    }
}