using NUnit.Framework;

namespace LostFramework
{
    public class InventoryTest
    {
        [Test]
        public void Test()
        {
            Assert.IsTrue(true);
        }

        [Test] 
        public void TestAddItem()
        {
            Inventory inventory = new Inventory();
            inventory.AddItem(new InventoryItem("test",10), 1);
            Assert.IsTrue(inventory.GetQuantity("test") == 1);
            Assert.IsTrue(inventory.InventoryContains("test").Count == 1);
            Assert.IsTrue(inventory.InventoryContains("test")[0]==1);
        }
    }
}