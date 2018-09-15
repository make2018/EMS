using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Snap7;

namespace EMS
{
    public partial class BA_Read_PLC_ethan : Form
    {

        public BA_Read_PLC_ethan()
        {
            InitializeComponent();
            Client = new S7Client();
            if (IntPtr.Size == 4)
                this.Text = this.Text + " - Running 32 bit Code";
            else
                this.Text = this.Text + " - Running 64 bit Code";

        }

        private S7Client Client;
        private byte[] Buffer = new byte[65536];

        private void ShowResult(int Result)
        {
            // This function returns a textual explaination of the error code
            toolStripStatusLabel1.Text = Client.ErrorText(Result) + " (" + Client.ExecTime().ToString() + " ms)";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client = new S7Client();
            int Result;
            int Rack = System.Convert.ToInt32(textBox2.Text);
            int Slot = System.Convert.ToInt32(textBox3.Text);
            Result = Client.ConnectTo(textBox1.Text, Rack, Slot);
            ShowResult(Result);
            if (Result == 0)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                button1.Enabled = false;
                button1.BackColor = Color.Green;
                button2.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                button3.Enabled = true;
                textBox6.Enabled = true;
            }
        }

        private void BA_Read_PLC_ethan_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DateTime DT = new DateTime();
            if (Client.GetPlcDateTime(ref DT) == 0)
            {
                textBox8.Text = DT.ToLongDateString() + " - " + DT.ToLongTimeString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Client.Disconnect();
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            button1.Enabled = true;
            button1.BackColor = Color.Gray;
            button2.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            button3.Enabled = false;
            textBox6.Enabled = false;
        }
        //Snap7标准函数，读取DB块中内容
        private void PlcDBRead()
        {
            // Declaration separated from the code for readability
            int DBNumber;
            int Size;
            int Result;

            DBNumber = System.Convert.ToInt32(textBox4.Text);
            Size = System.Convert.ToInt32(textBox5.Text);
            Result = Client.DBRead(DBNumber, 0, Size, Buffer);
            ShowResult(Result);
            if (Result == 0)
                HexDump(Buffer, Size);
        }

        private void HexDump(byte[] bytes, int Size)
        {
            if (bytes == null)
                return;
            int bytesLength = Size;
            int bytesPerLine = 16;

            char[] HexChars = "0123456789ABCDEF".ToCharArray();

            int firstHexColumn =
                  8                   // 8 characters for the address
                + 3;                  // 3 spaces

            int firstCharColumn = firstHexColumn
                + bytesPerLine * 3       // - 2 digit for the hexadecimal value and 1 space
                + (bytesPerLine - 1) / 8 // - 1 extra space every 8 characters from the 9th
                + 2;                  // 2 spaces 

            int lineLength = firstCharColumn
                + bytesPerLine           // - characters to show the ascii value
                + Environment.NewLine.Length; // Carriage return and line feed (should normally be 2)

            char[] line = (new String(' ', lineLength - 2) + Environment.NewLine).ToCharArray();
            int expectedLines = (bytesLength + bytesPerLine - 1) / bytesPerLine;
            StringBuilder result = new StringBuilder(expectedLines * lineLength);

            for (int i = 0; i < bytesLength; i += bytesPerLine)
            {
                line[0] = HexChars[(i >> 28) & 0xF];
                line[1] = HexChars[(i >> 24) & 0xF];
                line[2] = HexChars[(i >> 20) & 0xF];
                line[3] = HexChars[(i >> 16) & 0xF];
                line[4] = HexChars[(i >> 12) & 0xF];
                line[5] = HexChars[(i >> 8) & 0xF];
                line[6] = HexChars[(i >> 4) & 0xF];
                line[7] = HexChars[(i >> 0) & 0xF];

                int hexColumn = firstHexColumn;
                int charColumn = firstCharColumn;

                for (int j = 0; j < bytesPerLine; j++)
                {
                    if (j > 0 && (j & 7) == 0) hexColumn++;
                    if (i + j >= bytesLength)
                    {
                        line[hexColumn] = ' ';
                        line[hexColumn + 1] = ' ';
                        line[charColumn] = ' ';
                    }
                    else
                    {
                        byte b = bytes[i + j];
                        line[hexColumn] = HexChars[(b >> 4) & 0xF];
                        line[hexColumn + 1] = HexChars[b & 0xF];
                        line[charColumn] = (b < 32 ? '·' : (char)b);
                    }
                    hexColumn += 3;
                    charColumn++;
                }
                result.Append(line);
            }
            textBox6.Text = result.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PlcDBRead();
        }

        private void button5_Click(object sender, EventArgs e)
        {           
                int Pos = System.Convert.ToInt32(textBox7.Text);
                textBox9.Text = "16#" + System.Convert.ToString(Buffer[Pos], 16).ToUpper(); 
            }

        private void button6_Click(object sender, EventArgs e)
        {
            int Pos = System.Convert.ToInt32(textBox11.Text);
            UInt16 Word = S7.GetWordAt(Buffer, Pos);
            textBox10.Text = "16#" + System.Convert.ToString(Word, 16).ToUpper();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            int Pos = System.Convert.ToInt32(textBox13.Text);
    
                UInt32 DWord = S7.GetDWordAt(Buffer, Pos);
                textBox12.Text = "16#" + System.Convert.ToString(DWord, 16).ToUpper();

        }

        private void button8_Click(object sender, EventArgs e)
        {

            int Pos = System.Convert.ToInt32(textBox15.Text);
               

                int S7Int = S7.GetIntAt(Buffer, Pos);
                textBox14.Text = System.Convert.ToString(S7Int);
    
        }
    }
}