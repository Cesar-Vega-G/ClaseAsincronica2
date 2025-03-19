using System;

public class Node
{
    public int Value;
    public Node Next;

    public Node(int value)
    {
        this.Value = value;
        this.Next = null;
    }
}

public class CircularSinglyLinkedList
{
    private Node tail;
    private int size;

    public CircularSinglyLinkedList()
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

    // Insertar al inicio
    public void InsertAtStart(int value)
    {
        Node newNode = new Node(value);
        if (this.tail == null)
        {
            newNode.Next = newNode;
            this.tail = newNode;
        }
        else
        {
            newNode.Next = this.tail.Next;
            this.tail.Next = newNode;
        }
        this.size++;
    }

    // Insertar al final2
    public void InsertAtEnd(int value)
    {
        Node newNode = new Node(value);
        if (this.tail == null)
        {
            newNode.Next = newNode;
            this.tail = newNode;
        }
        else
        {
            newNode.Next = this.tail.Next;
            this.tail.Next = newNode;
            this.tail = newNode;
        }
        this.size++;
    }

    // Insertar en una posición indicada
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
        current.Next = newNode;

        if (current == this.tail)
        {
            this.tail = newNode;
        }

        this.size++;
    }

    // Eliminar al inicio
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
        }
        this.size--;
    }

    // Eliminar al final
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
            Node current = this.tail.Next;
            while (current.Next != this.tail)
            {
                current = current.Next;
            }
            current.Next = this.tail.Next;
            this.tail = current;
        }
        this.size--;
    }

    // Eliminar en una posición indicada
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
        for (int i = 0; i < index - 1; i++)
        {
            current = current.Next;
        }

        current.Next = current.Next.Next;
        if (current.Next == this.tail.Next)
        {
            this.tail = current;
        }

        this.size--;
    }

    // Representación en cadena
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

public class Program
{
    public static void Main()
    {
      
    }
}





