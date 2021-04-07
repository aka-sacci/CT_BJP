using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_CTPERDOES
{
    public partial class Adicionar_mae : Form
    {
        public Adicionar_mae()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string gen = textBox1.Text;
            string ano = anotacao.Text;
     

                Conexao comb = new Conexao();

                comb.sql = "Insert into tb01_genitoras (tb01_nome, tb01_anotacao) values ('" + gen + "', '"+ano+"')";
                comb.open();
                int lin = comb.Runsql();
                comb.close();

                MessageBox.Show("Registro inserido com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                anotacao.Clear();
            

        }

        private void Adicionar_mae_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void anotacao_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
