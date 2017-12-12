using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //REF: https://msdn.microsoft.com/en-us/library/dd267552(v=vs.110).aspx
            using (MemoryMappedFile mmf = MemoryMappedFile.CreateNew("DARKTHREAD", 1024))
            {
                //bool mutexCreated;
                //Mutex mutex = new Mutex(true, "DarkthreadSharedMem", out mutexCreated);
                //using (var stream = mmf.CreateViewStream())
                //{
                //    byte[] msg = Encoding.UTF8.GetBytes("Hello, World!");
                //    using (BinaryWriter bw = new BinaryWriter(stream))
                //    {
                //        bw.Write(msg.Length); //先寫Length
                //        bw.Write(msg); //再寫byte[]
                //    }
                //}
                //mutex.ReleaseMutex();
                //Console.Write("操作 Process B 進行讀取及回應，完成後按Enter");
                //Console.ReadLine();

                //mutex.WaitOne();
                using (MemoryMappedViewStream stream = mmf.CreateViewStream(6500,20))
                {
                    using (var br = new BinaryReader(stream))
                    {
                        //先讀取長度，再讀取内容
                        var len = br.ReadInt32();

                        var msg = Encoding.UTF8.GetString(br.ReadBytes(len), 0, len);
                    }
                }
                //mutex.ReleaseMutex();
                Console.ReadLine();
            }
        }
    }
}
