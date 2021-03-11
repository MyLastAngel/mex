using System;
using System.Collections.Generic;
using System.Text;

namespace mex
{
    public class MexDB
    {
        #region Поля

        /// <summary>Кэш ID</summary>
        public readonly List<uint> cache = new List<uint>();

        #endregion

        public MexDB()
        {
            cache.Add(1);
            cache.Add(3);
        }

        /// <summary>Получить следующий ID</summary>
        public uint GetNext()
        {
            return 0;
        }

        /// <summary>Перестроить базу</summary>
        public void Rebuild(uint seed)
        {
            for (var i = 0; i < cache.Count; i++)
                cache[i] ^= seed;
        }

    }
}
