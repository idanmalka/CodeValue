using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queues
{
    class Program
    {
        private static LimitedQueue<int> _limitedQueue;

        static void Main(string[] args)
        {
            _limitedQueue = new LimitedQueue<int>(10);

            for (int i = 1; i < 21; ++i)
            {
                ThreadPool.QueueUserWorkItem(ThreadWriterWork, i++);
                ThreadPool.QueueUserWorkItem(ThreadReaderWork, i);
            }
            Console.ReadLine();

        }

        private static void ThreadWriterWork(object obj)
        {
            int threadNumber = (int)obj;
            for (int i = 1; i < 10; i++)
                _limitedQueue.Enque(i * threadNumber);
            
        }

        private static void ThreadReaderWork(object obj)
        {
            for (int i = 1; i < 10; i++)
                _limitedQueue.Deque();
        }
    }
}
