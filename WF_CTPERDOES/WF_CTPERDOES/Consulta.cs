using MySql.Data.MySqlClient;
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
    public partial class Consulta : Form
    {
        public Consulta()
        {
            InitializeComponent();
        }

        public void informacoes() {

            try
            {
                String cod = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                String nome_mae = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                Detalhes wf = new Detalhes(cod);
                wf.Show();
            }
            catch(System.NullReferenceException e)
            {


            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
           Conexao comb = new Conexao();
            comb.sql = "select * from tb01_genitoras where tb01_nome LIKE '%"+ textBox1.Text + "%' ORDER BY tb01_nome";
            comb.open();
            MySqlDataReader dados = comb.Execsql();
            if (dados.HasRows)
            {
                while (dados.Read())
                {
                    string nome = dados["tb01_nome"].ToString();
                    string id = dados["tb01_seq"].ToString();
                    dataGridView1.Rows.Add(id, nome);
                }
            }
            comb.close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Index wf = new Index();
            wf.Show();
        }

        private void Consulta_Load(object sender, EventArgs e)
        {
            Conexao comb = new Conexao();
            comb.sql = "select * from tb01_genitoras ORDER BY tb01_nome limit 10 ";
            comb.open();
            MySqlDataReader dados = comb.Execsql();
            if (dados.HasRows)
            {
                while (dados.Read())
                {
                    string nome = dados["tb01_nome"].ToString();
                    string id = dados["tb01_seq"].ToString();
                    dataGridView1.Rows.Add(id, nome);
                }
            }
            comb.close();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            informacoes();


        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                informacoes();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
