using System;

// 1. Tạo một lớp tùy chỉnh với một sự kiện
class Button
{
    // Định nghĩa một sự kiện Click
    public event Action Click;

    // Phương thức này gọi sự kiện Click khi nút được nhấp
    public void OnClick()
    {
        Click?.Invoke();
    }
}

class Program
{
    static void Main()
    {
        // 2. Tạo một đối tượng Button
        Button myButton = new Button();

        // 3. Sử dụng lambda expression để đăng ký xử lý sự kiện Click
        myButton.Click += () =>
        {
            Console.WriteLine("Button clicked: Success!!!");
        };

        // 4. Khi nút được nhấp, sự kiện Click được gọi và lambda expression được thực thi
        myButton.OnClick();
    }
}
