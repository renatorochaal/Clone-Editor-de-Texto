using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace AplicativoEmSala
{
    public partial class Form1 : Form
    {
        public String nomeArquivo;
        public Form1()
        {
            InitializeComponent();
            this.nomeArquivo = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = " Arquivo Não Salvo ";
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Criado por Darth Japa", "Editor de Texto 1.0 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void recortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Texto.Cut();
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Texto.Paste();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Texto.Copy();
        }

        private void salvarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(saveFile.FileName, FileMode.Create);
                StreamWriter escrever = new StreamWriter(fs);
                escrever.WriteLine(Texto.Text);
                escrever.Close();
                toolStripStatusLabel1.Text = "Salvo";
                this.nomeArquivo = saveFile.FileName.ToString();
                Form1.ActiveForm.Text = "Editor de Texto v1.0 - [" + this.nomeArquivo + "]";
                fs.Close();
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(toolStripStatusLabel1.Text.Equals("Arquivo Não Salvo"))
            {
                DialogResult resultado;
                resultado = MessageBox.Show("Arquivo não salvo. Se continuar, todas as alterações serão perdidas." +
                    " Deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(resultado.Equals(DialogResult.Yes))
                {
                    if(openFile.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            var leitura = new StreamReader (openFile.FileName);
                            Texto.Clear();
                            Texto.Text = leitura.ReadToEnd();
                            leitura.Close();
                        }
                        catch (SecurityException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            else
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var leitura = new StreamReader(openFile.FileName);
                        Texto.Clear();
                        Texto.Text = leitura.ReadToEnd();
                        leitura.Close();
                    }
                    catch (SecurityException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Text.Equals("Arquivo Não Salvo"))
            {
                DialogResult resultado;
                resultado = MessageBox.Show("Arquivo não salvo. Se continuar, todas as alterações serão perdidas." +
                    " Deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado.Equals(DialogResult.Yes))
                {
                    Texto.Clear();
                    Form1.ActiveForm.Text = " Editor de Texto 1.0";

                }
            }
            else
            {
                Texto.Clear();
                Form1.ActiveForm.Text = " Editor de Texto 1.0";
            }
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!this.nomeArquivo.Equals(""))
            {
                FileStream fs = new FileStream(saveFile.FileName, FileMode.Create);
                StreamWriter escrever = new StreamWriter(fs);
                escrever.WriteLine(Texto.Text);
                escrever.Close();
                toolStripStatusLabel1.Text = "Salvo";
                Form1.ActiveForm.Text = "Editor de Texto v1.0 - [" + this.nomeArquivo + "]";
                fs.Close();
            }
            else
            {
                if(saveFile.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(saveFile.FileName, FileMode.Create);
                    StreamWriter escrever = new StreamWriter(fs);
                    escrever.WriteLine(Texto.Text);
                    escrever.Close();
                    toolStripStatusLabel1.Text = "Salvo";
                    this.nomeArquivo = saveFile.FileName.ToString();
                    Form1.ActiveForm.Text = "Editor de Texto v1.0 - [" + this.nomeArquivo + "]";
                    fs.Close();
                }
            }
        }

        private void fonteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(FonteSelecao.ShowDialog() == DialogResult.OK)
            {
                Texto.Font = FonteSelecao.Font;
                Texto.ForeColor = FonteSelecao.Color;
            }
        }

        private void quebraAutomáticaDeLinhaToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
