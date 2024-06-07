using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    // Интерфейс 'IObserver', который определяет метод 'Update', который должен быть реализован всеми наблюдателями.
    public interface IObserver
    {
        void Update(string command);
    }

    // Интерфейс 'ISubject', который определяет методы для добавления, удаления и оповещения наблюдателей.
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }

    // Класс 'DataInput', который реализует интерфейс 'ISubject'.
    public class DataInput : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
        private string _command;

        // Метод для добавления наблюдателя к списку.
        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        // Метод для удаления наблюдателя из списка.
        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        // Метод для оповещения всех наблюдателей о событии.
        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_command);
            }
        }

        // Метод для получения ввода данных и оповещения наблюдателей.
        public void EnterData()
        {
            Console.WriteLine("Введите команду:");
            _command = Console.ReadLine();
            Notify();
        }
    }

    // Класс 'ConsoleObserver', который реализует интерфейс 'IObserver'.
    public class ConsoleObserver : IObserver
    {
        // Метод 'Update', который вызывается, когда 'DataInput' оповещает наблюдателей.
        public void Update(string command)
        {
            if (command == "exit")
            {
                Console.WriteLine("Команда 'exit' введена. Программа завершает работу.");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            // Создание объекта 'DataInput'.
            DataInput dataInput = new DataInput();

            // Создание наблюдателя 'ConsoleObserver'.
            ConsoleObserver observer = new ConsoleObserver();

            // Добавление наблюдателя к 'DataInput'.
            dataInput.Attach(observer);

            // Ввод данных.
            dataInput.EnterData();

            // Удаление наблюдателя, если это необходимо.
            dataInput.Detach(observer);
        }
    }

}
