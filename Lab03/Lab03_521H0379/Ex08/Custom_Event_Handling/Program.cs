using System;
delegate void EventHandler();
class EventManager
{
    private event EventHandler customEvent;

    public void AddHandler(EventHandler handler)
    {
        customEvent += handler;
    }

    public void RemoveHandler(EventHandler handler)
    {
        customEvent -= handler;
    }

    public void RaiseEvent()
    {
        customEvent?.Invoke();
    }
}

class Custom_Event_Handling
{
    static void Main(string[] args)
    {
        EventManager eventManager = new EventManager();

        void EventHandler1()
        {
            Console.WriteLine("Event Handler 1 called.");
        }

        void EventHandler2()
        {
            Console.WriteLine("Event Handler 2 called.");
        }

        //Thêm 2 EventHandler vào và Raise chúng
        Console.WriteLine("Add Two EventHandler and Rasie: ");
        eventManager.AddHandler(EventHandler1);
        eventManager.AddHandler(EventHandler2);
        eventManager.RaiseEvent();
        Console.WriteLine("====================================");


        //Xóa đi Eventhadler1 và Raise lại
        Console.WriteLine("Remove EventHandler1 and Rasie: ");
        eventManager.RemoveHandler(EventHandler1);
        eventManager.RaiseEvent();
        Console.WriteLine("====================================");
    }
}
