﻿using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControllerInterface.InterProcessCommunication
{
    public static class InterProcessExtensions
    {
        /// <summary>
        /// Waits for a connection to the pipe in a safe way
        /// </summary>
        /// <param name="stream">The pipe to wait from</param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="AbandonedMutexException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ObjectDisposedException"></exception>
        public static void WaitForConnectionEx(this NamedPipeServerStream stream)
        {
            var evt = new AutoResetEvent(false);
            Exception e = null;
            stream.BeginWaitForConnection(ar =>
            {
                try
                {
                    stream.EndWaitForConnection(ar);
                }
                catch (Exception er)
                {
                    e = er;
                }
                evt.Set();
            }, null);
            evt.WaitOne();
            if (e != null)
                throw e; // rethrow exception
        }

        /// <summary>
        /// Waits for a connection to the pipe in a safe way and with a timeout
        /// </summary>
        /// <param name="stream">The pipe to wait from</param>
        /// <param name="timeout">A timeout in milliseconds</param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="AbandonedMutexException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ObjectDisposedException"></exception>
        public static void WaitForConnectionEx(this NamedPipeServerStream stream, int timeout)
        {
            var evt = new AutoResetEvent(false);
            Exception e = null;
            stream.BeginWaitForConnection(ar => {
                try
                {
                    stream.EndWaitForConnection(ar);
                }
                catch (Exception er)
                {
                    e = er;
                }
                evt.Set();
            }, null);
            evt.WaitOne(timeout);
            if (e != null)
                throw e; // rethrow exception
        }
    }
}
