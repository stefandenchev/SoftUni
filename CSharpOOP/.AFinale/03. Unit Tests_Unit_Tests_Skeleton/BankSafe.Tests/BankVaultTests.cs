using NUnit.Framework;
using System;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        Item item;
        Item item2;
        BankVault vault;

        [SetUp]
        public void Setup()
        {
            item = new Item("Stefan", "23");
            item2 = new Item("Valeri", "3");
            vault = new BankVault();
        }

        [Test]
        public void CheckItemConstructor()
        {
            Assert.AreEqual(item.Owner, "Stefan");
            Assert.AreEqual(item.ItemId, "23");
        }

        [Test]
        public void CheckVaultConstructor()
        {
            Assert.AreEqual(vault.VaultCells.Count, 12);
        }

        //ADD

        [Test]
        public void CheckIfAddThrowsExceptionWhenCellDoesntExist()
        {
            Assert.Throws<ArgumentException>(()
                => vault.AddItem("Z9", item));
        }

        [Test]
        public void CheckIfAddThrowsExceptionWhenCellIsTaken()
        {
            vault.AddItem("A1", item);

            Assert.Throws<ArgumentException>(()
                => vault.AddItem("A1", item));
        }

        [Test]
        public void CheckIfAddThrowsExceptionWhenCellExists()
        {
            vault.AddItem("A1", item);

            Assert.Throws<InvalidOperationException>(()
                => vault.AddItem("B2", item));
        }

        [Test]
        public void CheckIfAddWorks()
        {
            vault.AddItem("A1", item);

            Assert.AreEqual(vault.VaultCells["A1"], item);
        }

        //REMOVE

        [Test]
        public void CheckIfRemoveThrowsExceptionWhenCellDoesntExist()
        {
            Assert.Throws<ArgumentException>(()
                => vault.RemoveItem("Z9", item));
        }

        [Test]
        public void CheckIfRemoveThrowsExceptionWhenItemInCellDoesntExist()
        {
            vault.AddItem("A1", item);

            Assert.Throws<ArgumentException>(()
                => vault.RemoveItem("A1", item2));
        }

        [Test]
        public void CheckIfRemoveWorks()
        {
            vault.AddItem("A1", item);
            vault.RemoveItem("A1", item);

            Assert.AreEqual(vault.VaultCells["A1"], null);
        }
    }
}