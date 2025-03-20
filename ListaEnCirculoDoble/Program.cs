using System;

public class Node
{
    public int Value;
    public Node Next;
    public Node Prev;

    public Node(int value)
    {
        this.Value = value;
        this.Next = null;
        this.Prev = null;
    }
}

public class CircularDoublyLinkedList
{
    private Node tail;
    private int size;

    public CircularDoublyLinkedList()
    {
        this.tail = null;
        this.size = 0;
    }

    public void Clear()
    {
        this.tail = null;
        this.size = 0;
    }

    public bool IsEmpty()
    {
        return this.size == 0;
    }

    public int Size()
    {
        return this.size;
    }

    public bool Contains(int element)
    {
        if (this.tail == null)
        {
            return false;
        }

        Node current = this.tail.Next;
        do
        {
            if (current.Value == element)
            {
                return true;
            }
            current = current.Next;
        } while (current != this.tail.Next);

        return false;
    }

    public void InsertAtStart(int value)
    {
        Node newNode = new Node(value);
        if (this.tail == null)
        {
            newNode.Next = newNode;
            newNode.Prev = newNode;
            this.tail = newNode;
        }
        else
        {
            newNode.Next = this.tail.Next;
            newNode.Prev = this.tail;
            this.tail.Next.Prev = newNode;
            this.tail.Next = newNode;
        }
        this.size++;
    }

    public void InsertAtEnd(int value)
    {
        InsertAtStart(value);
        this.tail = this.tail.Next;
    }

    public void InsertAt(int value, int index)
    {
        if (index < 0 || index > this.size)
        {
            throw new ArgumentOutOfRangeException("Índice fuera de rango.");
        }

        if (index == 0)
        {
            InsertAtStart(value);
            return;
        }

        Node newNode = new Node(value);
        Node current = this.tail.Next;
        for (int i = 0; i < index - 1; i++)
        {
            current = current.Next;
        }

        newNode.Next = current.Next;
        newNode.Prev = current;
        current.Next.Prev = newNode;
        current.Next = newNode;

        if (current == this.tail)
        {
            this.tail = newNode;
        }

        this.size++;
    }

    public void RemoveFromStart()
    {
        if (this.tail == null)
        {
            throw new InvalidOperationException("La lista está vacía.");
        }

        if (this.size == 1)
        {
            this.tail = null;
        }
        else
        {
            this.tail.Next = this.tail.Next.Next;
            this.tail.Next.Prev = this.tail;
        }
        this.size--;
    }

    public void RemoveFromEnd()
    {
        if (this.tail == null)
        {
            throw new InvalidOperationException("La lista está vacía.");
        }

        if (this.size == 1)
        {
            this.tail = null;
        }
        else
        {
            this.tail.Prev.Next = this.tail.Next;
            this.tail.Next.Prev = this.tail.Prev;
            this.tail = this.tail.Prev;
        }
        this.size--;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= this.size)
        {
            throw new ArgumentOutOfRangeException("Índice fuera de rango.");
        }

        if (index == 0)
        {
            RemoveFromStart();
            return;
        }

        Node current = this.tail.Next;
        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }

        current.Prev.Next = current.Next;
        current.Next.Prev = current.Prev;

        if (current == this.tail)
        {
            this.tail = current.Prev;
        }

        this.size--;
    }

    public override string ToString()
    {
        if (this.tail == null)
        {
            return string.Empty;
        }

        Node current = this.tail.Next;
        string result = current.Value.ToString();
        current = current.Next;

        while (current != this.tail.Next)
        {
            result += ", " + current.Value;
            current = current.Next;
        }

        return result;
    }
}

public class Program1
{
    public static void Main()
    {

    }
}