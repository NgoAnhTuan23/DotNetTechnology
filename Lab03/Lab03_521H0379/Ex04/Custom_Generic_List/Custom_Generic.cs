namespace Custom_Generic_List
{
    public class CustomList<T>
    {
        private T[] items;
        private int count;

        public CustomList()
        {
            items = new T[5]; // Khởi tạo mảng ban đầu với kích thước 5
            count = 0;
        }

        public int Count
        {
            get { return count; }
        }

        // Thêm một phần tử vào danh sách
        public void Add(T item)
        {
            if (count == items.Length)
            {
                // Nếu danh sách đầy, tạo một mảng mới lớn hơn và sao chép các phần tử từ danh sách cũ
                T[] newItems = new T[items.Length * 2];
                Array.Copy(items, newItems, items.Length);
                items = newItems;
            }

            items[count] = item;
            count++;
        }

        // Xóa một phần tử khỏi danh sách
        public bool Remove(T item)
        {
            int index = Array.IndexOf(items, item, 0, count);
            if (index >= 0)
            {
                // Di chuyển tất cả các phần tử phía sau về phía trước để đè lên phần tử cần xóa
                Array.Copy(items, index + 1, items, index, count - index - 1);
                items[count - 1] = default(T); // Đặt phần tử cuối cùng thành giá trị mặc định
                count--;
                return true;
            }
            return false;
        }

        // Truy xuất phần tử theo index
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException();
                }
                return items[index];
            }
            set
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException();
                }
                items[index] = value;
            }
        }

        // In ra các phần tử của danh sách
        public void Print()
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(items[i]);
            }
        }
    }
}