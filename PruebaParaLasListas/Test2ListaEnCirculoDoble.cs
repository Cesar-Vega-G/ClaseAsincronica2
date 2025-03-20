namespace PruebaParaLasListas;

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class CircularDoublyLinkedListTests
{
    #region Setup and Helper Methods

    private CircularDoublyLinkedList CreateListWithElements(int numberOfElements)
    {
        var list = new CircularDoublyLinkedList();
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
        var list = new CircularDoublyLinkedList();
        list.InsertAtStart(10);

        Assert.AreEqual(1, list.Size());
        Assert.AreEqual("10", list.ToString());
        Assert.IsFalse(list.IsEmpty());
    }

    [TestMethod]
    public void Test_InsertAtStart_NonEmptyList()
    {
        var list = new CircularDoublyLinkedList();
        list.InsertAtEnd(1);
        list.InsertAtStart(0);

        Assert.AreEqual(2, list.Size());
        Assert.AreEqual("0, 1", list.ToString());
    }

    [TestMethod]
    public void Test_InsertAtEnd_EmptyList()
    {
        var list = new CircularDoublyLinkedList();
        list.InsertAtEnd(5);

        Assert.AreEqual(1, list.Size());
        Assert.AreEqual("5", list.ToString());
        Assert.IsFalse(list.IsEmpty());
    }

    [TestMethod]
    public void Test_InsertAtEnd_NonEmptyList()
    {
        var list = CreateListWithElements(3);
        list.InsertAtEnd(4);

        Assert.AreEqual(4, list.Size());
        Assert.AreEqual("1, 2, 3, 4", list.ToString());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Test_InsertAt_InvalidIndex()
    {
        var list = CreateListWithElements(3);
        list.InsertAt(99, 5);
    }

    [TestMethod]
    public void Test_InsertAt_ValidIndex()
    {
        var list = CreateListWithElements(3);
        list.InsertAt(99, 2);

        Assert.AreEqual(4, list.Size());
        Assert.AreEqual("1, 2, 99, 3", list.ToString());
    }

    #endregion

    #region Remove Tests

    [TestMethod]
    public void Test_RemoveFromStart_OneElement()
    {
        var list = new CircularDoublyLinkedList();
        list.InsertAtEnd(10);
        list.RemoveFromStart();

        Assert.IsTrue(list.IsEmpty());
        Assert.AreEqual(0, list.Size());
    }

    [TestMethod]
    public void Test_RemoveFromStart_MultipleElements()
    {
        var list = CreateListWithElements(3);
        list.RemoveFromStart();

        Assert.AreEqual(2, list.Size());
        Assert.AreEqual("2, 3", list.ToString());
    }

    [TestMethod]
    public void Test_RemoveFromEnd_OneElement()
    {
        var list = new CircularDoublyLinkedList();
        list.InsertAtEnd(10);
        list.RemoveFromEnd();

        Assert.IsTrue(list.IsEmpty());
        Assert.AreEqual(0, list.Size());
    }

    [TestMethod]
    public void Test_RemoveFromEnd_MultipleElements()
    {
        var list = CreateListWithElements(3);
        list.RemoveFromEnd();

        Assert.AreEqual(2, list.Size());
        Assert.AreEqual("1, 2", list.ToString());
    }

    [TestMethod]
    public void Test_RemoveAt_ValidIndex()
    {
        var list = CreateListWithElements(3);
        list.RemoveAt(1);

        Assert.AreEqual(2, list.Size());
        Assert.AreEqual("1, 3", list.ToString());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Test_RemoveAt_InvalidIndex()
    {
        var list = CreateListWithElements(3);
        list.RemoveAt(99);
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
    public void Test_Contains_ExistingElement()
    {
        var list = CreateListWithElements(3);
        Assert.IsTrue(list.Contains(2));
    }

    [TestMethod]
    public void Test_Contains_NonExistingElement()
    {
        var list = CreateListWithElements(3);
        Assert.IsFalse(list.Contains(4));
    }

    [TestMethod]
    public void Test_Contains_EmptyList()
    {
        var list = new CircularDoublyLinkedList();
        Assert.IsFalse(list.Contains(1));
    }

    [TestMethod]
    public void Test_Performance_LargeList_InsertAtStart()
    {
        var list = new CircularDoublyLinkedList();
        for (int i = 0; i < 10000; i++)
        {
            list.InsertAtStart(i);
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

    #endregion

    [TestMethod]
    public void Test_Main_ExecutesWithoutError()
    {
        // Redirigir la salida de la consola para capturar cualquier error inesperado
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Llamar a Main
            Program1.Main();

            // Verificar que no hubo salida inesperada (puede ser vacío si Main no hace nada)
            Assert.AreEqual(string.Empty, sw.ToString());
        }
    }
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Test_RemoveFromStart_EmptyList()
    {
        var list = new CircularDoublyLinkedList();
        list.RemoveFromStart();
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Test_RemoveFromEnd_EmptyList()
    {
        var list = new CircularDoublyLinkedList();
        list.RemoveFromEnd();
    }

    [TestMethod]
    public void Test_RemoveAt_LastIndex()
    {
        var list = CreateListWithElements(3);
        list.RemoveAt(2); // Último índice

        Assert.AreEqual(2, list.Size());
        Assert.AreEqual("1, 2", list.ToString());
    }

    [TestMethod]
    public void Test_InsertAt_SizeIndex()
    {
        var list = CreateListWithElements(3);
        list.InsertAt(99, 3); // Índice igual a la cantidad de elementos

        Assert.AreEqual(4, list.Size());
        Assert.AreEqual("1, 2, 3, 99", list.ToString());
    }

    [TestMethod]
    public void Test_ToString_EmptyList()
    {
        var list = new CircularDoublyLinkedList();
        Assert.AreEqual(string.Empty, list.ToString());
    }
}