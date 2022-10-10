using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static int liczbaGrup = 0;
        public static string grupy = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            if (richTextBox1.Text.Length < 1)
            {
                try
                {
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.InitialDirectory = "c:\\";
                        openFileDialog.Filter = "txt files (*.txt)|*.txt";

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            filePath = openFileDialog.FileName;
                            var fileStream = openFileDialog.OpenFile();
                            using (StreamReader reader = new StreamReader(fileStream))
                            {
                                fileContent = reader.ReadToEnd();
                            }
                        }
                    }

                    if(filePath != "")
                    {
                        MessageBox.Show("Plik został załączony.", "Sukces!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                    string odczyt, liczby;
                    liczby = "";
                    int i, j, t, g;
                    t = 0;
                    double liczba, temp;
                    string[] znak = new string[] { "|" };
                    double[] tab = new double[fileContent.Length];

                    StreamReader tresc = new StreamReader(filePath);

                    while ((odczyt = tresc.ReadLine()) != null)
                    {
                        for (i = 0; i < odczyt.Length; i++)
                        {
                            if (Char.IsDigit(odczyt[i]))
                            {
                                liczby += odczyt[i];
                            }
                            else if (odczyt.Substring(i, 1) == "." || odczyt.Substring(i, 1) == ",")
                            {
                                liczby += ",";
                            }
                            else
                            {
                                liczby += "|";
                            }
                        }
                    }

                    string[] z = liczby.Split(znak, StringSplitOptions.RemoveEmptyEntries);

                    for (i = 0; i < z.Length; i++)
                    {
                        liczba = double.Parse(z[i]);
                        tab[t] = liczba;
                        t++;
                    }

                    for (j = 0; j < t - 1; j++)
                    {
                        for (i = j + 1; i < t; i++)
                        {
                            if (tab[i] < tab[j])
                            {
                                temp = tab[i];
                                tab[i] = tab[j];
                                tab[j] = temp;
                            }
                        }
                    }

                    double[] tabn = new double[t];

                    for (i = 0; i < t; i++)
                    {
                        tabn[i] += tab[i];
                    }

                    int max, min;
                    max = (int)Math.Ceiling(tabn[t-1]);
                    min = (int)Math.Floor(tabn[0]);

                    liczbaGrup = max - min;
                    int[] wyniki = new int[liczbaGrup];

                    foreach (var x in tabn)
                    {
                        g = 0;
                        for (i = min + 1; i <= max; i++)
                        {
                            if (x > i - 1 && x <= i)
                            {
                                wyniki[g]++;
                            }
                            else if (x == 0)
                            {
                                wyniki[0]++;
                            }
                            g++;
                        }
                    }

                    g = min + 1;
                    grupy = "";
                    richTextBox1.Text += "Rozkład ocen:\n \n";

                    foreach (var x in wyniki)
                    {
                        richTextBox1.Text += (g - 1 + "-" + g + ":\t \t" + x + "\n");
                        grupy += g - 1 + "-" + g + "|" + x + "|";
                        g++;
                    }

                    tresc.Close();
                }
                catch (ArgumentException argExp) when (filePath == "")
                {
                    MessageBox.Show("Plik nie został załączony.", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                MessageBox.Show("Aby załączyć nowy plik, pierw odłącz obecny.", "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length >= 1)
            {
                DialogResult dialogResult = MessageBox.Show("Czy napewno chcesz odłączyć plik?", "Uwaga!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    richTextBox1.Clear();
                }
            }
            else
            {
                MessageBox.Show("Nie załączyłeś żadnego pliku.", "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length >= 1)
            {
                Stream myStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "txt files (*.txt)|*.txt";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        richTextBox1.SaveFile(myStream, RichTextBoxStreamType.PlainText);
                        myStream.Close();
                    }
                }

                if (saveFileDialog1.FileName == "")
                {
                    MessageBox.Show("Plik nie został zapisany.", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Plik został zapisany.", "Sukces!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Brak danych do zapisu.", "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length >= 1)
            {
                Form2 form2 = new Form2();
                form2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Brak danych do wykresu.", "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
