using System;

namespace ConsoleLR2
{
    internal class Program
    {

        static void Main(string[] args)
        {

            MyDoublyLinkedList doublyLinkedList = new MyDoublyLinkedList();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Введите {i + 1}-е целочисленное число:");
                int number = int.Parse(Console.ReadLine());
                doublyLinkedList.AddLastNode(number);
            }
            while (true)
            {
                Console.WriteLine("\nВведите:\n1 - для просмотра всех элементов списка" +
               "\n2 - для вставки элемента справа" +
               "\n3 - для поиска элемента" +
               "\n4 - для удаления элемента" +
               "\n5 - для очистки списка" +
               "\n6 - для удаления элементов на нечётных позициях");
                int number = 0;
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        doublyLinkedList.Show();
                        break;
                    case 2:
                        Console.WriteLine("Введите число для добавления:");
                        number = int.Parse(Console.ReadLine());
                        doublyLinkedList.AddLastNode(number);
                        break;
                    case 3:
                        Console.WriteLine("Введите число для поиска");
                        number = int.Parse(Console.ReadLine());
                        if (doublyLinkedList.Search(number) != null)
                            Console.WriteLine(doublyLinkedList.Search(number).Value);
                        else
                            Console.WriteLine("Число не найдено");
                        break;
                    case 4:
                        Console.WriteLine("Введите число для удаления");
                        number = int.Parse(Console.ReadLine());
                        if (doublyLinkedList.Search(number) != null)
                            doublyLinkedList.RemoveNode(doublyLinkedList.Search(number));
                        else
                            Console.WriteLine("Число не найдено");
                        break;
                    case 5:
                        doublyLinkedList.Clear();
                        break;
                    case 6:
                        doublyLinkedList.Sort(doublyLinkedList);
                        break;
                    default:
                        Console.WriteLine("Функционал по данной кнопке не обнаружен");
                        break;
                }
            }
        }
    }
    class MyDoublyLinkedListNode
    {
        public int Value { get; set; }
        public MyDoublyLinkedListNode Next { get; set; }
        public MyDoublyLinkedListNode Prev { get; set; }
        public MyDoublyLinkedListNode(int value)
        {
            Value = value;
        }
    }
    class MyDoublyLinkedList
    {


        public MyDoublyLinkedListNode Head = null;
        public MyDoublyLinkedListNode Current = null;
        public MyDoublyLinkedListNode Tail = null;
        public int Count;
        public MyDoublyLinkedList() { }

        public void AddLastNode(int value)
        {
            MyDoublyLinkedListNode node = new MyDoublyLinkedListNode(value);
            if (Head == null)
                Head = node;
            else
            {
                Tail.Next = node;
                node.Prev = Tail;
            }
            Tail = node;
            Count++;
        }

        public void Show()
        {
            Console.WriteLine("Вывод всех элементов двунаправленного цикличного линейного списка:");
            MyDoublyLinkedListNode tmp = Head;
            while (tmp != null)
            {
                Console.Write(tmp.Value + " ");
                tmp = tmp.Next;
            }
        }
        public MyDoublyLinkedListNode Search(int value)
        {
            MyDoublyLinkedListNode tmp = Head;
            while (tmp != null)
            {
                if (tmp.Value == value)
                    return tmp;
                tmp = tmp.Next;
            }
            return null;
        }
        public void RemoveNode(MyDoublyLinkedListNode target)
        {

            if (Head == target)
                Head = Head.Next;
            else
            {
                MyDoublyLinkedListNode tmp = Head;
                while (tmp.Next != target)
                    tmp = tmp.Next;
                tmp.Next = target.Next;
            }
        }
        public void Clear()
        {
            Console.WriteLine("Очищение списка");
            MyDoublyLinkedListNode temp;
            while (Head != null)
            {
                temp = Head.Next;
                Head = temp;
            }
        }
        public void Sort(MyDoublyLinkedList doublyLinkedList)
        {
            MyDoublyLinkedListNode tmp = Head;
            int localCount = 1; //Поставьте здесь 0, если вам нужно,
                                //чтобы как-раз чётные удалялись, но тогда всегда будет оставаться первый элемент.
            bool isEven = false;
            while (tmp != null)
            {
                isEven = localCount % 2 == 0;
                if (isEven == false)
                    doublyLinkedList.RemoveNode(tmp);
                localCount++;
                tmp = tmp.Next;
            }
        }
    }
}
