using System;
using System.Collections.Generic;
using System.Text;

namespace mex
{
    public class MexDB
    {
        #region Поля

        // Последнее добавленное, чтобы не гонять с 0 
        uint lastAdd = 0;

        /// <summary>Кэш ID</summary>
        public List<uint> sorted = new List<uint>();

        #endregion

        public MexDB()
        {
        }

        /// <summary>Получить следующий ID (В худшем n)</summary>
        public uint GetNext()
        {
            var count = sorted.Count;
            if (count == 0)
            {
                sorted.Add(0);
                return 0;
            }

            // у нас все заполнено последовательно - добавляем в конец
            var last = sorted[count - 1] + 1;
            if (count == last)
            {
                sorted.Add(last);
                return last;
            }

            for (uint value = lastAdd; value < last; value++)
            {
                var index = sorted.BinarySearch(value);
                if (index >= 0)
                    continue;

                sorted.Insert(~index, value);
                lastAdd = value;

                return value;
            }

            throw new Exception("Ошибка алгоритма");
        }

        /// <summary>Перестроить базу (O(log N))</summary>
        public void Rebuild(uint seed)
        {
            var tmp = new List<uint>();
            var count = sorted.Count;

            for (var i = 0; i < count; i++)
            {
                var value = sorted[i] ^ seed;

                var index = tmp.BinarySearch(value);
                tmp.Insert(~index, value);
            }

            sorted = tmp;
            lastAdd = 0;
        }
    }
}
