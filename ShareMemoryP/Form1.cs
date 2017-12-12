﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShareMemoryP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            try
            {
                Console.Write("按 Enter 開始讀取及回應…");
                Console.ReadLine();
                using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting("DARKTHREAD"))
                {
                    Mutex mutex = Mutex.OpenExisting("DarkthreadSharedMem");
                    mutex.WaitOne();
                    using (MemoryMappedViewStream stream = mmf.CreateViewStream(0, 0))
                    {
                        using (var br = new BinaryReader(stream))
                        {
                            //先讀取長度，再讀取内容
                            var len = br.ReadInt32();
                            var word = Encoding.UTF8.GetString(br.ReadBytes(len), 0, len);
                            Console.WriteLine($"訊息＝{word}");
                        }
                    }
                    using (MemoryMappedViewStream stream = mmf.CreateViewStream(512, 512))
                    {
                        using (var bw = new BinaryWriter(stream))
                        {
                            var msg = Encoding.UTF8.GetBytes("朕知道了");
                            bw.Write(msg.Length);
                            bw.Write(msg);
                        }
                    }
                    mutex.ReleaseMutex();
                }
                Console.ReadLine();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Memory-mapped file does not exist.");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
