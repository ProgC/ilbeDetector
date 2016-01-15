using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ilbeDetector
{
    public partial class frmilbeDetector : Form
    {
        public class Info
        {
            public int startIndex;
            public int endIndex;
        }

        public List<Info> ilbeInfoForSearch = new List<Info>();

        public frmilbeDetector()
        {
            InitializeComponent();
        }

        public class Worker
        {
            public List<Info> ilbeInfo = new List<Info>();

            public int StartIndex;
            public int EndIndex;
            public string OriginalText;
            public string[] Words;

            public Worker(int start, int end, string text, string[] words )
            {
                StartIndex = start;
                EndIndex = end;
                OriginalText = text;
                Words = words;
            }

            public void DoWork()
            {
                ilbeInfo.Clear();
                FindString(OriginalText, StartIndex, EndIndex, Words);                                
            }

            void FindString(string text, int startIndex, int endIndex, string[] words)
            {
                int storedStartIndex = startIndex;
                for (int i = 0; i < words.Length; ++i)
                {
                    while (true)
                    {
                        int index = text.IndexOf(words[i], startIndex);
                        if (index < 0)
                        {
                            startIndex++;
                        }
                        else
                        {
                            // ilbe?
                            Info info = new Info();
                            info.startIndex = index;
                            info.endIndex = index + words[i].Length;
                            ilbeInfo.Add(info);

                            startIndex = index + words[i].Length;
                        }

                        if (startIndex >= endIndex)
                        {
                            startIndex = storedStartIndex;
                            break;
                        }
                    }
                }
            }
        }
               

        private void btnDetect_Click(object sender, EventArgs e)
        {
            int threadCount = 10;
            string text = originalText.Text;            
            char[] delimiterChars = { '\n' };
            string[] words = ilbeWords.Text.Split( delimiterChars );
            int n = text.Length;

            if (n < 100)
            {
                threadCount = 1;
            }

            Worker[] workObjects = new Worker[threadCount];
            Thread[] workerThread = new Thread[threadCount];
            
            int subN = n / threadCount;
            int startIndex = 0;
            
            for ( int i = 0; i < threadCount; ++i )
            {
                int endIndex = startIndex + subN - 1;
                if (i == threadCount - 1) endIndex = text.Length;
                workObjects[i] = new Worker(startIndex, endIndex, text, words);

                startIndex += subN;
                workerThread[i] = new Thread(workObjects[i].DoWork);

                workerThread[i].Start();
            }
            
            while(true)
            {
                Thread.Sleep(1);
                bool foundAlive = false;
                for (int i = 0; i < threadCount; ++i)
                {
                    if (workerThread[i].IsAlive)
                    {
                        foundAlive = true;
                    }
                }

                if (!foundAlive)
                {
                    // then we should stop
                    break;
                }
            }

            // 모든 스레드 작업이 끝나면 화면에 표시해주자.
            for (int i = 0; i < threadCount; ++i)
            {
                List<Info> ilbeInfo = workObjects[i].ilbeInfo;
                for (int j = 0; j < ilbeInfo.Count; ++j)
                {
                    originalText.Select(ilbeInfo[j].startIndex, ilbeInfo[j].endIndex - ilbeInfo[j].startIndex);
                    originalText.SelectionColor = Color.Red;

                    ilbeInfoForSearch.Add(ilbeInfo[j]);
                    string word = text.Substring(ilbeInfo[j].startIndex, ilbeInfo[j].endIndex - ilbeInfo[j].startIndex);
                    listBox1.Items.Add(word);
                }
            }
            
            lblIlbeWordCount.Text = "일베 단어 : " + "[" + ilbeInfoForSearch.Count + "]" + " / [" + text.Length + "]";

            MessageBox.Show("Detection is completed!");
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            // 현재 선택된 단어를 text에서 찾아 보자.
            if (listBox1.SelectedIndex >= 0)
            {
                originalText.Select(originalText.SelectionStart, originalText.SelectionLength);
                originalText.SelectionFont = new System.Drawing.Font("굴림", 9, FontStyle.Regular);
                    
                Info wordInfo = ilbeInfoForSearch[listBox1.SelectedIndex];
                originalText.Select(wordInfo.startIndex, wordInfo.endIndex - wordInfo.startIndex);
                originalText.SelectionFont = new System.Drawing.Font("굴림", 20, FontStyle.Bold);
                originalText.ScrollToCaret();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
