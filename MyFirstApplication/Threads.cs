using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
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

            // tasks

            // executed automatically
            Task task = Task.Run(() =>
            {
                // heavy code to execute
            });

            // for canceling a task
            CancellationTokenSource ct = new CancellationTokenSource();

            // alternative method for starting a task
            Task<int> task2 = Task.Factory.StartNew(() => {
                // heavy code
                // more options available than Run()
                // add a 2 sec delay to task
                Task.Delay(2000);
                return 10; // return a value after completion
            }, ct.Token);

            // continue with another task once the task is complete
            task2.ContinueWith((antecedent) =>
            {
                if(task2.Status == TaskStatus.RanToCompletion)
                {
                   Util.printValue(task2.Result);
                } else
                {
                    Util.printValue(task2.Exception?.InnerExceptions.First().Message);
                }
            });

            // get result of task2
            Util.printValue(task2.Result);
            // wait for a task
            task.Wait();
            // wait for more than one task
            Task.WaitAll(task, task2);
            // wait for completion of any task
            Task.WaitAny(task, task2);

            // cancel task
            ct.Cancel();


            


            // 

            // create a stopwatch
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Stop();
            Util.printValue(stopwatch.ElapsedMilliseconds);
            /**
             * output
             * 
             */

        }
    }
}
