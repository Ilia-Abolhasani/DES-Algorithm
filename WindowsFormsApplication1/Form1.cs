using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Form1_SizeChanged(sender, e);
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            int Width = panel2.Size.Width;
            int Height = panel2.Size.Height / 2;
            panel3.Size = new System.Drawing.Size(Width, Height);
            panel4.Size = new System.Drawing.Size(Width, Height);
            Height = panel10.Size.Height / 4;
            Width = panel10.Size.Width;
            panel9.Size = new System.Drawing.Size(Width, Height);
            panel8.Size = new System.Drawing.Size(Width, Height);

            panel11.Size = new System.Drawing.Size(Width, Height);
            panel12.Size = new System.Drawing.Size(Width, Height);
            panel13.Size = new System.Drawing.Size(Width, Height);
            panel14.Size = new System.Drawing.Size(Width, Height);
            panel15.Size = new System.Drawing.Size(Width, Height);
            panel16.Size = new System.Drawing.Size(Width, Height);
            richTextBox1.Size = new Size(panel11.Size.Width - 140, Height);
            richTextBox2.Size = new Size(panel11.Size.Width - 140, Height);
            richTextBox3.Size = new Size(panel11.Size.Width - 140, Height);
            richTextBox4.Size = new Size(panel11.Size.Width - 140, Height);
            richTextBox5.Size = new Size(panel11.Size.Width - 140, Height);
            richTextBox6.Size = new Size(panel11.Size.Width - 140, Height);
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DES des = new DES();
            richTextBox3.Text = des.Encryption(richTextBox1.Text, richTextBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DES des = new DES();
            richTextBox4.Text = des.Decryption(richTextBox6.Text, richTextBox5.Text);
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            About f = new About();
            f.ShowDialog();
        }

        private void s1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Learn L = new Learn(this.Size, global::DES_Algorithm.Properties.Resources.S01);
            L.ShowDialog();
        }

        private void s2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Learn L = new Learn(this.Size, global::DES_Algorithm.Properties.Resources.S02);
            L.ShowDialog();
        }

        private void s3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Learn L = new Learn(this.Size, global::DES_Algorithm.Properties.Resources.S03);
            L.ShowDialog();
        }

        private void s4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Learn L = new Learn(this.Size, global::DES_Algorithm.Properties.Resources.S04);
            L.ShowDialog();
        }

        private void s5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Learn L = new Learn(this.Size, global::DES_Algorithm.Properties.Resources.S05);
            L.ShowDialog();
        }

        private void s6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Learn L = new Learn(this.Size, global::DES_Algorithm.Properties.Resources.S06);
            L.ShowDialog();
        }

        private void s7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Learn L = new Learn(this.Size, global::DES_Algorithm.Properties.Resources.S07);
            L.ShowDialog();
        }

        private void s8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Learn L = new Learn(this.Size, global::DES_Algorithm.Properties.Resources.S08);
            L.ShowDialog();
        }

        private void permutedChoice1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Learn L = new Learn(this.Size, global::DES_Algorithm.Properties.Resources.P03);
            L.ShowDialog();
        }

        private void permutedChoice2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Learn L = new Learn(this.Size, global::DES_Algorithm.Properties.Resources.P02);
            L.ShowDialog();
        }

        private void initialPermutationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Learn L = new Learn(this.Size, global::DES_Algorithm.Properties.Resources.P01);
            L.ShowDialog();
        }

        private void bITSELECTIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Learn L = new Learn(this.Size, global::DES_Algorithm.Properties.Resources.P04);
            L.ShowDialog();
        }

        private void permutationPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Learn L = new Learn(this.Size, global::DES_Algorithm.Properties.Resources.P05);
            L.ShowDialog();
        }

        private void lastPermutationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Learn L = new Learn(this.Size, global::DES_Algorithm.Properties.Resources.p06);
            L.ShowDialog();
        }


    }
}
