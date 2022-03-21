using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WifiConnector.Math
{
    internal class Arrangement : IEnumerable, IEnumerator
    {
        /// <summary>
        /// 起始的数字
        /// </summary>
        private readonly int startIndex;
        /// <summary>
        /// 结束的数字
        /// </summary>
        private readonly int endIndex;
        /// <summary>
        /// 返回的集合的长度
        /// </summary>
        private readonly int length;
        /// <summary>
        /// 每个排列的游标值
        /// </summary>
        private int cursor = 0;
        /// <summary>
        /// 每个排列的第一个数字
        /// </summary>
        private int index = 0;

        public Arrangement(int sindex, int eindex, int length) 
        {
            this.startIndex = sindex > -1 ? sindex : 0;
            this.endIndex = eindex > -1 ? eindex : 0;
            this.length = length > -1 ? length : 0;
            this.index = sindex;
            this.cursor = sindex;
        }

        public object Current
        {
            get
            {
                int[] vs = new int[length];
                if (vs.Length > 0)
                {
                    Console.WriteLine("Current, index=" + index + ", cursor=" + cursor);
                    vs[0] = index;
                    for (int i = cursor, j = 1; j < vs.Length && i < endIndex; i++, j++)
                    {
                        if (index == i)
                        {
                            j--;
                            continue;
                        }
                        vs[j] = i;
                    }
                }
                return vs;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            Console.WriteLine("MoveNext, index=" + index + ", cursor=" + cursor);
            bool had = index + 1 < endIndex;
            int nextCursor = cursor + 1 == index ? index + 1 : cursor + 1;
            if (had)
            {
                if (nextCursor < endIndex)
                {
                    cursor++;
                }
                else
                {
                    index++;
                    cursor = startIndex;
                }
            }
            else if (nextCursor < endIndex)
            {
                cursor++;
                had = true;
            }
            return had;
        }

        public void Reset()
        {
            index = startIndex;
        }
    }
}