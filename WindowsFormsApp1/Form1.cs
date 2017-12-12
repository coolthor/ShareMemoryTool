﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int OFFSET = sizeof(int);

        private Mutex mutex;
        public Form1()
        {
            InitializeComponent();
            bool mutexCreated;
            mutex = mutex == null
                ? new Mutex(true, "mutex", out mutexCreated)
                : mutex;
        }

        private List<int> newPLCWordData;

        private void readSM()
        {
            try
            {
                string suffix = txtSuffix.Text.Length == 0 ? "-WordData" : txtSuffix.Text;
                string mapName = $"Global\\{stockID.Text}{suffix}";
                using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting(mapName))
                {

                    mutex.WaitOne();
                    using (MemoryMappedViewStream stream = mmf.CreateViewStream())
                    {
                        using (var br = new BinaryReader(stream))
                        {
                            newPLCWordData = new List<int>();
                            br.BaseStream.Seek(OFFSET, SeekOrigin.Begin);
                            while (br.BaseStream.Position < br.BaseStream.Length)
                                newPLCWordData.Add(br.ReadInt32());
                        }
                    }
                    mutex.ReleaseMutex();
                }
                lblLastReadTime.Text = DateTime.Now.ToString($"yyyy-MM-dd HH:mm:ss");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(@"Memory-mapped file does not exist.");
                Console.WriteLine(@"Memory-mapped file does not exist.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
        

        private void btnGetValue_Click_1(object sender, EventArgs e)
        {
            readSM();
            if (newPLCWordData.Count==0) return;
            int startIndex;
            if (!int.TryParse(txtStartIndex.Text, out startIndex))
                txtStartIndex.Text = "0";
            int wordlength = 1;
            if (!int.TryParse(txtWordLength.Text, out wordlength) || wordlength > 2)
            {
                txtWordLength.Text = "1";
            }

            int result = 0;
            switch (wordlength)
            {
                case 1:
                    if (startIndex >= newPLCWordData.Count)
                    {
                        MessageBox.Show("超出Share memory 範圍");
                        return;
                    }
                    result = newPLCWordData[startIndex];
                    break;
                case 2:
                    if (startIndex >= newPLCWordData.Count-1)
                    {
                        MessageBox.Show("超出Share memory 範圍");
                        return;
                    }
                    result = newPLCWordData[startIndex+1] * 65536 + newPLCWordData[startIndex];
                    break;
            }
            listBox1.Items.Add(result);
        }

        private void btnInitialSM_Click(object sender, EventArgs e)
        {
            string suffix = txtSuffix.Text.Length == 0 ? "-WordData" : txtSuffix.Text;
            string mapName = $"Global\\{stockID.Text}{suffix}";
            int SM_SIZE = 2800;
            if (!int.TryParse(txtSize.Text, out SM_SIZE))
            {
                SM_SIZE = 2800;
                txtSize.Text = "2800";
            }
            try
            {
                MemoryMappedFile mmf = MemoryMappedFile.CreateOrOpen(mapName, SM_SIZE * 5);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            readSM();
        }

        private void btnSetValue_Click(object sender, EventArgs e)
        {
            int index = 0;

            if(!int.TryParse(txtSetIndex.Text, out index)) return;

            int value = 0;
            if(!int.TryParse(txtSetValue.Text, out value)) return;

            newPLCWordData[index] = value;

            try
            {
                string suffix = txtSuffix.Text.Length == 0 ? "-WordData" : txtSuffix.Text;
                string mapName = $"Global\\{stockID.Text}{suffix}";
                using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting(mapName))
                {
                    mutex.WaitOne();
                    using (MemoryMappedViewStream stream = mmf.CreateViewStream())
                    {
                        var writer = new BinaryWriter(stream);
                        
                        writer.Write(0);
                        for (int i = 0; i < newPLCWordData.Count; i++)
                        {
                            writer.Write(newPLCWordData[i]);
                        }
                    }
                    mutex.ReleaseMutex();
                }
                lblLastReadTime.Text = DateTime.Now.ToString($"yyyy-MM-dd HH:mm:ss");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(@"Memory-mapped file does not exist.");
                Console.WriteLine(@"Memory-mapped file does not exist.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
