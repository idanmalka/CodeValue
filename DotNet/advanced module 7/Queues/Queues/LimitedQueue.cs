using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queues
{
    //No IDisposable to release the semaphore?
    class LimitedQueue<T> 
    {
        private readonly Queue<T> _queue;

        //Why two? You could have done this using only one.
        private readonly SemaphoreSlim _writerSem,_readerSem;
        public LimitedQueue(int size)
        {
            if (size<0)
                throw new ArgumentOutOfRangeException();
            _queue = new Queue<T>();
            _writerSem = new SemaphoreSlim(size);
            _readerSem = new SemaphoreSlim(0);
        }
        public void Enque(T item)
        {
            _writerSem.Wait();
            lock (_queue)
            {
                _queue.Enqueue(item);
                Console.WriteLine($"Number of items in the queue: {_queue.Count}");
            }

            //You should insert it into a finaly clause when working with acquire-release pattern
            _readerSem.Release();
        }

        public T Deque()
        {
            T dequedItem;
            _readerSem.Wait();
            lock (_queue)
            {
                dequedItem = _queue.Dequeue();
                Console.WriteLine($"Number of items in the queue: {_queue.Count}");
            }
            _writerSem.Release();
            return dequedItem;
        }
    }
}
