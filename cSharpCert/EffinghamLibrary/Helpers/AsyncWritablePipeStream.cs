using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.IO;

namespace EffinghamLibrary
{
    /// <summary>
    /// Class to allow writing to one stream while passing from another.
    /// </summary>
    public class AsyncWritablePipeStream : AbstractStreamBase
    {
        private Stream writableStream;
        private BlockingCollection<byte[]> bytePipe;
        private Task processingTask;
        public AsyncWritablePipeStream(Stream writableStream)
        {
            this.writableStream = writableStream;
            bytePipe = new BlockingCollection<byte[]>();
            processingTask = Task.Factory.StartNew(() =>
                                                   {
                                                       foreach (byte[] bt in bytePipe.GetConsumingEnumerable())
                                                       {
                                                           writableStream.Write(bt, 0, bt.Length);
                                                       }
                                                   }, TaskCreationOptions.LongRunning);
        }

        public override bool CanWrite => true;

        /// <summary>
        /// Write Data to the output stream
        /// </summary>
        /// <param name="buffer">data to write</param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        public override void Write(byte[] buffer, int offset, int count)
        {
            byte[] chunk = new byte[count];
            Buffer.BlockCopy(buffer, offset, chunk, 0, count);
            bytePipe.Add(chunk);
        }

        public override void Close()
        {
            bytePipe.CompleteAdding();
            try
            {
                processingTask.Wait();
            }
            finally
            {
                base.Close();
            }
        }
    }
}
