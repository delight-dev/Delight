#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Delight
{
    /// <summary>
    ///     Utility to run coroutine functions in the editor
    /// </summary>
    public class EditorCoroutine
    {
        private readonly Stack<IEnumerator> coroutineList = new Stack<IEnumerator>();

        /// <summary>
        ///     Start running a coroutine
        /// </summary>
        public static void Start(IEnumerator routine)
        {
            new EditorCoroutine(routine).Start();
        }

        private EditorCoroutine(IEnumerator coroutine)
        {
            coroutineList.Push(coroutine);
        }

        private void Start()
        {
            EditorApplication.update += Update;
        }

        private void Stop()
        {
            EditorApplication.update -= Update;
        }

        private void Update()
        {
            try {
                var current = coroutineList.Peek();

                if (current.MoveNext() == false) {
                    // The coroutine at the bottom of the list is complete
                    coroutineList.Pop();
                } else if (current.Current is IEnumerator) {
                    // Coroutine is calling a coroutine, add it to the list and start monitoring that coroutine until it completes.
                    coroutineList.Push((IEnumerator)current.Current);
                } else if (current.Current is AsyncOperation) {
                    var tmp = (AsyncOperation)current.Current;
                    coroutineList.Push(new AsyncToCustomYield(tmp));
                }

                // Stop listening for update events if there are no more coroutines.
                if (coroutineList.Count == 0) {
                    Stop();
                }
            } catch (Exception) {
                // If any sort of error is thrown we kill the whole stack for simplicity.
                coroutineList.Clear();
                Stop();
                throw;
            }
        }

        internal class AsyncToCustomYield : CustomYieldInstruction
        {
            private AsyncOperation async;

            public AsyncToCustomYield(AsyncOperation async)
            {
                this.async = async;
            }

            public override bool keepWaiting {
                get { return async.isDone == false; }
            }
        }
    }
}
#endif