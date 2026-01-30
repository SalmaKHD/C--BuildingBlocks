using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace MyFirstApplication
{
    public class Threads
    {
        public static object LockObject = new object();

        public static void workWithThreads()
        {
            Util.printValue(Thread.CurrentThread.Name); // Thread class imported automatically
            Util.printValue(Thread.CurrentThread.Priority); // useful for multiple threads
            // create a code tat will execute in a thread
            Thread thread1 = new Thread(() =>
            {
                Util.printValue("something");

                // method 1: implement thread signaling
                // Monitor
                Monitor.Wait(LockObject); // will signal other threads to wait
                // works ONLY IF the other thread is already waiting 
                Monitor.Pulse(LockObject); // means time to continue execution after waiting (lock state)
                // todo: create ManualResentEvent to signal threads

                // method 2
                // access shared resource with lock
                lock(LockObject) {

                }

                // method 3
                // create concurrent data strucures
                ConcurrentQueue<string> queue = new ConcurrentQueue<string>();
                queue.Enqueue("Salma");
                queue.TryDequeue(out string firstValue);

                // method 4
                // semaphor
                Semaphore semaphor = new Semaphore(1, 2); // second param: max num of slot
                semaphor.WaitOne(); // attempt aaquiring a slot
                semaphor.Release(); // release slot when done

                // method 5
                // mutex: similar to lock method
                Mutex mutex = new Mutex(); // good for interprocess communications only
                mutex.WaitOne(); // will suspend all other threads
                mutex.ReleaseMutex(); // other threads will be signaled to execute

                // thread pool
                ThreadPool.QueueUserWorkItem((object? state) =>
                {
                    // a task that will be executed on a free thread in the thread pool
                }); // no need for manual thread creation and destruction 

                // method 6
                // countdownevent


            });
            thread1.Start();
            // todo: add monitor example with 2 threads

            // method 7: coundownevent -> waits for multiple signals before proceeding
            CountdownEvent cdEvent = new CountdownEvent(10); // 10 represents the number of required signals
            if(cdEvent.CurrentCount != 0)
                cdEvent.Signal(); // decreases countdown by 1
            cdEvent.Wait(); // wait until count down becomes 0
            cdEvent.Reset(); // resets countdown to initial count
        }
    }
}
