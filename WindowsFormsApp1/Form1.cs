using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int OFFSET = 0;

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
                OFFSET = int.TryParse(txtOffset.Text, out OFFSET) ? OFFSET : 0;
                string mapName = $"Global\\{txtSuffix.Text}";
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
            if (!checkOFFSET())
            {
                MessageBox.Show("In this case OFFSET, must sizeof(int) * count");
                return;
            }
            readSM();
            
            if (newPLCWordData==null||newPLCWordData.Count==0) return;
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
            listBox1.Items.Add($"[Index:{txtStartIndex.Text} | Length:{txtWordLength.Text}] -> value:{result}");
        }

        private void btnInitialSM_Click(object sender, EventArgs e)
        {
            string mapName = $"Global\\{txtSuffix.Text}";
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
            if (!checkOFFSET())
            {
                MessageBox.Show("In this case OFFSET, must sizeof(int) * count");
                return;
            }

            int index = 0;

            if(!int.TryParse(txtSetIndex.Text, out index)) return;

            int value = 0;
            if(!int.TryParse(txtSetValue.Text, out value)) return;

            if(newPLCWordData==null)
                btnInitialSM.PerformClick();
            newPLCWordData[index] = value;

            try
            {
                OFFSET = int.TryParse(txtOffset.Text, out OFFSET) ? OFFSET : 0;
                string mapName = $"Global\\{txtSuffix.Text}";
                using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting(mapName))
                {
                    mutex.WaitOne();
                    using (MemoryMappedViewStream stream = mmf.CreateViewStream())
                    {
                        stream.Seek(OFFSET, SeekOrigin.Begin);
                        var writer = new BinaryWriter(stream);
                        for (int i = 0; i < newPLCWordData.Count-(OFFSET/sizeof(int)); i++)
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

        private bool checkOFFSET()
        {
            int.TryParse(txtOffset.Text, out OFFSET);
            return (OFFSET % sizeof(int) == 0);
        }
    }
}
