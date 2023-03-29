using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            chart1.Series["oceny"].IsValueShownAsLabel = false;
            chart1.Legends["Legend1"].Enabled = false;

            int liczbaGrup = Form1.liczbaGrup;
            string grupy = Form1.grupy;
            string[] tabGrupy = grupy.Split('|');
            int j = 0;

            for (int i = 0; i < liczbaGrup * 2; i += 2)
            {
                chart1.Series["oceny"].Points.AddXY(tabGrupy[i], tabGrupy[i + 1]);                
                checkedListBox1.Items.Add(tabGrupy[i]);
                checkedListBox1.SetItemChecked(j, true);
                j++;
            }            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                chart1.Legends["Legend1"].Enabled = true;
            }
            else
            {
                chart1.Legends["Legend1"].Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked)
            {
                chart1.Series["oceny"].IsValueShownAsLabel = true;
            }
            else
            {
                chart1.Series["oceny"].IsValueShownAsLabel = false;
            }
                        
            for(int i = 0; i <= checkedListBox1.Items.Count - 1; i++)
            {
                if (chart1.Series["oceny"].Points[i].Color == Color.Transparent)
                {
                    chart1.Series["oceny"].IsValueShownAsLabel = false;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <= checkedListBox1.Items.Count - 1; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        chart1.Series["oceny"].Points[i].Color = Color.Black;
                        chart1.Series["oceny"].Color = Color.Black;
                    }

                    if (comboBox1.SelectedIndex == 1)
                    {
                        chart1.Series["oceny"].Points[i].Color = Color.PeachPuff;
                        chart1.Series["oceny"].Color = Color.PeachPuff;
                    }

                    if (comboBox1.SelectedIndex == 2)
                    {
                        chart1.Series["oceny"].Points[i].Color = Color.GreenYellow;
                        chart1.Series["oceny"].Color = Color.GreenYellow;
                    }

                    if (comboBox1.SelectedIndex == 3)
                    {
                        chart1.Series["oceny"].Points[i].Color = Color.BlueViolet;
                        chart1.Series["oceny"].Color = Color.BlueViolet;
                    }
                }
                else
                {
                    chart1.Series["oceny"].Points[i].Color = Color.Transparent;
                }
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <= checkedListBox1.Items.Count - 1; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        chart1.Series["oceny"].Points[i].Color = Color.Black;
                        chart1.Series["oceny"].Color = Color.Black;
                    }

                    if (comboBox1.SelectedIndex == 1)
                    {
                        chart1.Series["oceny"].Points[i].Color = Color.PeachPuff;
                        chart1.Series["oceny"].Color = Color.PeachPuff;
                    }

                    if (comboBox1.SelectedIndex == 2)
                    {
                        chart1.Series["oceny"].Points[i].Color = Color.GreenYellow;
                        chart1.Series["oceny"].Color = Color.GreenYellow;
                    }

                    if (comboBox1.SelectedIndex == 3)
                    {
                        chart1.Series["oceny"].Points[i].Color = Color.BlueViolet;
                        chart1.Series["oceny"].Color = Color.BlueViolet;
                    }                    
                }
                else
                {                    
                    chart1.Series["oceny"].Points[i].Color = Color.Transparent;
                }
            }
        }
    }
}
