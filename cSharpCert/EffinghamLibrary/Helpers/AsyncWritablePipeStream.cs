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
