using System;
using System.Collections.Generic;
using System.Linq;

namespace MyDirectoryDemo
{
    public class MyDictionary<TKey, TValue>
    {
        int[,] KeyValuePairs;

        List<TKey> Keys;
        List<TValue> Values;
        public MyDictionary()
        {
            Keys = new List<TKey>();
            Values = new List<TValue>();
            KeyValuePairs = new int[0, 0];
        }

        public void Add(TKey key, TValue value)
        {
            Keys.Add(key);
            Values.Add(value);
            int[,] tempArr = KeyValuePairs;

            KeyValuePairs = new int[Keys.Count, 2];

            for (int x = 0; x < Keys.Count - 1; x++)
            {
                KeyValuePairs[x, 0] = tempArr[x, 0];
                KeyValuePairs[x, 1] = tempArr[x, 1];
            }
            int selectedIndex = Keys.Count - 1;
            KeyValuePairs[selectedIndex, 0] = Keys.FirstOrDefault(selectedKey => selectedKey.Equals(key)).GetHashCode();
            KeyValuePairs[selectedIndex, 1] = Values.FirstOrDefault(selectedValue => selectedValue.Equals(value)).GetHashCode();
        }

        public TValue this[TKey key]
        {
            get
            {
                int hashCode = Keys.FirstOrDefault(selectedKey => selectedKey.Equals(key)).GetHashCode();
                for (int x = 0; x < KeyValuePairs.Length; x++)
                {
                    if (KeyValuePairs[x, 0].GetHashCode() == hashCode)
                    {
                        return Values.FirstOrDefault(selectedValue => selectedValue.GetHashCode() == KeyValuePairs[x, 1]);
                    }
                }
                return default;
            }
        }
    }
}
