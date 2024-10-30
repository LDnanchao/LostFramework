using System;

namespace LostFramework
{
    public class InventoryItem
    {
        //id
        public string ItemID = String.Empty;
        //最大数量
        public int MaxQuantity;
        //当前数量
        public int Quantity;
        
        public InventoryItem(){}
        public  InventoryItem(string itemID, int maxQuantity)
        {
            ItemID = itemID;
            MaxQuantity = maxQuantity;
        }
    }
}