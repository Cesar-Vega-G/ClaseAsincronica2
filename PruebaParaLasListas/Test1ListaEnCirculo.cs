using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class CircularSinglyLinkedListTests
{
    #region Setup and Helper Methods

    private CircularSinglyLinkedList CreateListWithElements(int numberOfElements)
    {
        var list = new CircularSinglyLinkedList();
        for (int i = 1; i <= numberOfElements; i++)
        {
            list.InsertAtEnd(i);
        }
        return list;
    }

    #endregion

    #region Insert Tests

    [TestMethod]
    public void Test_InsertAtStart_EmptyList()
    {
        var list = new CircularSinglyLinkedList();
        list.InsertAtStart(10);

        Assert.AreEqual(1, list.Size());
        Assert.AreEqual("10", list.ToString());
        Assert.IsFalse(list.IsEmpty());
    }

    [TestMethod]
    public void Test_InsertAtStart_NonEmptyList()
    {
        var list = new CircularSinglyLinkedList();
        list.InsertAtEnd(1);
        list.InsertAtStart(0);

        Assert.AreEqual(2, list.Size());
        Assert.AreEqual("0, 1", list.ToString());
    }

    [TestMethod]
    public void Test_InsertAtEnd_EmptyList()
    {
        var list = new CircularSinglyLinkedList();
        list.InsertAtEnd(5);

        Assert.AreEqual(1, list.Size());
        Assert.AreEqual("5", list.ToString());
        Assert.IsFalse(list.IsEmpty());
    }

    [TestMethod]
    public void Test_InsertAtEnd_NonEmptyList()
    {
        var list = CreateListWithElements(3); // List: 1, 2, 3
        list.InsertAtEnd(4);

        Assert.AreEqual(4, list.Size());
        Assert.AreEqual("1, 2, 3, 4", list.ToString());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Test_InsertAt_InvalidIndex()
    {
        var list = CreateListWithElements(3); // List: 1, 2, 3
        list.InsertAt(99, 5); // Invalid index
    }

    [TestMethod]
    public void Test_InsertAt_ValidIndex()
    {
        var list = CreateListWithElements(3); // List: 1, 2, 3
        list.InsertAt(99, 2); // Insert at index 2 (before the last element)

        Assert.AreEqual(4, list.Size());
        Assert.AreEqual("1, 2, 99, 3", list.ToString());
    }

    [TestMethod]
    public void Test_InsertAtStart_LargeList()
    {
        var list = new CircularSinglyLinkedList();
        list.InsertAtStart(1);
        list.InsertAtStart(2);
        list.InsertAtStart(3);

        // Verificar que el tamaño de la lista sea 3
        Assert.AreEqual(3, list.Size());

        // Verificar que el primer elemento sea el 3
        Assert.AreEqual("3", list.ToString().Split(',')[0].Trim());
    }

    #endregion

    #region Remove Tests

    [TestMethod]
    public void Test_RemoveFromStart_OneElement()
    {
        var list = new CircularSinglyLinkedList();
        list.InsertAtEnd(10);
        list.RemoveFromStart();

        Assert.IsTrue(list.IsEmpty());
        Assert.AreEqual(0, list.Size());
    }

    [TestMethod]
    public void Test_RemoveFromStart_MultipleElements()
    {
        var list = CreateListWithElements(3); // List: 1, 2, 3
        list.RemoveFromStart();

        Assert.AreEqual(2, list.Size());
        Assert.AreEqual("2, 3", list.ToString());
    }

    [TestMethod]
    public void Test_RemoveFromEnd_OneElement()
    {
        var list = new CircularSinglyLinkedList();
        list.InsertAtEnd(10);
        list.RemoveFromEnd();

        Assert.IsTrue(list.IsEmpty());
        Assert.AreEqual(0, list.Size());
    }

    [TestMethod]
    public void Test_RemoveFromEnd_MultipleElements()
    {
        var list = CreateListWithElements(3); // List: 1, 2, 3
        list.RemoveFromEnd();

        Assert.AreEqual(2, list.Size());
        Assert.AreEqual("1, 2", list.ToString());
    }

    [TestMethod]
    public void Test_RemoveAt_ValidIndex()
    {
        var list = CreateListWithElements(3); // List: 1, 2, 3
        list.RemoveAt(1); // Remove element at index 1

        Assert.AreEqual(2, list.Size());
        Assert.AreEqual("1, 3", list.ToString());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Test_RemoveAt_InvalidIndex()
    {
        var list = CreateListWithElements(3);
        list.RemoveAt(99); // Invalid index
    }

    [TestMethod]
    public void Test_RemoveAt_Start()
    {
        var list = CreateListWithElements(5); // List: 1, 2, 3, 4, 5
        list.RemoveAt(0); // Remove the first element

        Assert.AreEqual(4, list.Size());
        Assert.AreEqual("2, 3, 4, 5", list.ToString());
    }

    [TestMethod]
    public void Test_RemoveAt_End()
    {
        var list = CreateListWithElements(5); // List: 1, 2, 3, 4, 5
        list.RemoveAt(4); // Remove the last element

        Assert.AreEqual(4, list.Size());
        Assert.AreEqual("1, 2, 3, 4", list.ToString());
    }

    #endregion

    #region Edge and Performance Tests

    [TestMethod]
    public void Test_Clear()
    {
        var list = CreateListWithElements(100);
        list.Clear();

        Assert.IsTrue(list.IsEmpty());
        Assert.AreEqual(0, list.Size());
    }

    [TestMethod]
    public void Test_RemoveAt_LargeList()
    {
        var list = CreateListWithElements(3); // Lista: 1, 2, 3
        list.RemoveAt(2); // Eliminar el elemento en el índice 2 (el último elemento)

        // Verificar que el tamaño sea 2 después de la eliminación
        Assert.AreEqual(2, list.Size());

        // Verificar que la lista restante es "1, 2"
        Assert.AreEqual("1, 2", list.ToString());
    }

    [TestMethod]
    public void Test_Contains_ExistingElement()
    {
        var list = CreateListWithElements(3); // List: 1, 2, 3
        Assert.IsTrue(list.Contains(2)); // Should return true
    }

    [TestMethod]
    public void Test_Contains_NonExistingElement()
    {
        var list = CreateListWithElements(3); // List: 1, 2, 3
        Assert.IsFalse(list.Contains(4)); // Should return false
    }

    [TestMethod]
    public void Test_Contains_EmptyList()
    {
        var list = new CircularSinglyLinkedList();
        Assert.IsFalse(list.Contains(1)); // Should return false
    }

    [TestMethod]
    public void Test_Performance_LargeList_InsertAtStart()
    {
        var list = new CircularSinglyLinkedList();
        for (int i = 0; i < 10000; i++)
        {
            list.InsertAtStart(i);
        }

        Assert.AreEqual(10000, list.Size());
    }

    [TestMethod]
    public void Test_Performance_LargeList_InsertAtEnd()
    {
        var list = new CircularSinglyLinkedList();
        for (int i = 0; i < 10000; i++)
        {
            list.InsertAtEnd(i);
        }

        Assert.AreEqual(10000, list.Size());
    }

    [TestMethod]
    public void Test_Performance_LargeList_RemoveFromStart()
    {
        var list = CreateListWithElements(10000);
        for (int i = 0; i < 10000; i++)
        {
            list.RemoveFromStart();
        }

        Assert.IsTrue(list.IsEmpty());
    }

    [TestMethod]
    public void Test_Performance_LargeList_RemoveFromEnd()
    {
        var list = CreateListWithElements(10000);
        for (int i = 0; i < 10000; i++)
        {
            list.RemoveFromEnd();
        }

        Assert.IsTrue(list.IsEmpty());
    }

    #endregion

    #region Edge Case Tests

    [TestMethod]
    public void Test_EmptyList_AfterRemoveFromStart()
    {
        var list = new CircularSinglyLinkedList();
        list.InsertAtEnd(5);
        list.RemoveFromStart();

        Assert.IsTrue(list.IsEmpty());
    }

    [TestMethod]
    public void Test_EmptyList_AfterRemoveFromEnd()
    {
        var list = new CircularSinglyLinkedList();
        list.InsertAtEnd(5);
        list.RemoveFromEnd();

        Assert.IsTrue(list.IsEmpty());
    }

    #endregion
    [TestMethod]
    public void Test_Main_ExecutesWithoutError()
    {
        // Redirigir la salida de la consola para capturar cualquier error inesperado
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Llamar a Main
            Program.Main();

            // Verificar que no hubo salida inesperada (puede ser vacío si Main no hace nada)
            Assert.AreEqual(string.Empty, sw.ToString());
        }
    }
}




