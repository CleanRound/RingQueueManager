public class RingQueue<T>
{
    private T[] _array;
    private int _head;
    private int _tail;
    private int _size;
    private int _capacity;

    public RingQueue(int capacity)
    {
        if (capacity < 1)
            throw new ArgumentException("Capacity must be greater than 0");

        _capacity = capacity;
        _array = new T[_capacity];
        _head = 0;
        _tail = 0;
        _size = 0;
    }

    public void Enqueue(T item)
    {
        if (_size == _capacity)
        {
            throw new InvalidOperationException("The queue is full.");
        }

        _array[_tail] = item;
        _tail = (_tail + 1) % _capacity;
        _size++;
    }

    public T Dequeue()
    {
        if (_size == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        T item = _array[_head];
        _array[_head] = default(T);
        _head = (_head + 1) % _capacity;
        _size--;
        return item;
    }

    public T Peek()
    {
        if (_size == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        return _array[_head];
    }

    public int Count
    {
        get { return _size; }
    }

    public bool IsEmpty
    {
        get { return _size == 0; }
    }

    public bool IsFull
    {
        get { return _size == _capacity; }
    }
}

class Program
{
    static void Main()
    {
        var ringQueue = new RingQueue<string>(3);

        ringQueue.Enqueue("Item 1");
        ringQueue.Enqueue("Item 2");
        ringQueue.Enqueue("Item 3");

        Console.WriteLine($"Peek: {ringQueue.Peek()}");
        Console.WriteLine($"Dequeue: {ringQueue.Dequeue()}");
        Console.WriteLine($"Dequeue: {ringQueue.Dequeue()}");

        ringQueue.Enqueue("Item 4");

        Console.WriteLine($"Peek: {ringQueue.Peek()}");
        Console.WriteLine($"Dequeue: {ringQueue.Dequeue()}");
        Console.WriteLine($"Dequeue: {ringQueue.Dequeue()}");

        Console.WriteLine($"IsEmpty: {ringQueue.IsEmpty}");
        Console.WriteLine($"IsFull: {ringQueue.IsFull}");
    }
}
