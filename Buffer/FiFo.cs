using System;

namespace Buffer
{
    public class FiFo
    {
        private readonly int[] buffer;

        public bool IsFull { get; private set; }
        public bool IsEmpty { get; private set; } = true;
        public bool HasOverflow { get; private set; }
        public int Tail { get; private set; } = -1;
        public int Head { get; private set; } = -1;
        public int Size { get { return buffer.Length; } }

        public FiFo()
        {
            buffer = new int[10];
        }

        public FiFo(int size)
        {
            buffer = new int[size];
        }

        public void Clear()
        {            
            IsEmpty = true;
            IsFull = false;
            HasOverflow = false;
            Head = -1;
            Tail = -1;
        }

        public void Add(int value)
        {
            Head++;
            if ((Head == (Size - 1) && Tail == 0) || Head == (Tail - 1))
            {
                IsFull = true;
            }

            if (Head == Size)
            {
                Head = 0;
            }
            buffer[Head] = value;

            bool HeadEqualsTail = Head == Tail;
            if (IsEmpty || HeadEqualsTail)
            {
                Tail++;
                if (HeadEqualsTail)
                {
                    HasOverflow = true;
                }

                if (Tail == Size)
                {
                    Tail = 0;
                }                
            }
            IsEmpty = false;
        }

        public int GetValue()
        {
            if (IsEmpty)
            {
                Console.WriteLine("Error");
                return -1;
            }

            int value = buffer[Tail];
            if (Tail == Head)
            {
                Clear();
                return value;
            }

            Tail++;
            HasOverflow = false;
            IsFull = false;

            if (Tail == Size)
            {
                Tail = 0;
            }

            return value;
        }

        public int[] GetStack()
        {
            if (IsEmpty)
            {
                return new int[0];
            }

            int[] ausgabeArray = new int[buffer.Length];
            int counter = 0;

            if (Tail <= Head)
            {
                for (int k = Tail; k <= Head; k++)
                {
                    ausgabeArray[counter] = buffer[k];
                    counter++;
                }
            }
            else
            {
                for (int i = Tail; i < Size; i++)
                {
                    ausgabeArray[counter] = buffer[i];
                    counter++;
                }

                for (int j = 0; j <= Head; j++)
                {
                    ausgabeArray[counter] = buffer[j];
                    counter++;
                }
            }

            int[] ausgabe = new int[counter];

            for (int i = 0; i < ausgabe.Length; i++)
            {
                ausgabe[i] = ausgabeArray[i];
            }

            return ausgabe;
        }
    }
}