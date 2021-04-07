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
    public partial class Novo_nucleo : Form
    {
        public Novo_nucleo()
        {
            InitializeComponent();
        }

        private void Novo_nucleo_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            Conexao comb = new Conexao();
            comb.sql = "select * from tb01_genitoras ORDER BY tb01_nome";
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

        private void label4_Click(object sender, EventArgs e)
        {
            Adicionar_mae wf = new Adicionar_mae();
            wf.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Conexao comb = new Conexao();

            if (comboBox1.SelectedIndex == 0)
            {
                comb.sql = "select * from tb01_genitoras where tb01_nome LIKE '%" + textBox1.Text + "%' ORDER BY tb01_nome";
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
            if (comboBox1.SelectedIndex == 1)
            {
                comb.sql = "SELECT tb02_genitora, tb02_genitor, tb01_nome FROM tb02_filhos INNER JOIN tb01_genitoras ON tb02_filhos.tb02_genitora = tb01_genitoras.tb01_seq WHERE tb02_genitor != '*' AND TB02_GENITOR LIKE '%" + textBox1.Text + "%' GROUP BY tb02_genitora, tb02_genitor ORDER BY tb02_GENITOR";
                comb.open();
                MySqlDataReader dados = comb.Execsql();
                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        string nome_gen = dados["tb01_nome"].ToString();
                        string nome = dados["tb02_genitor"].ToString();
                        string id = dados["tb02_genitora"].ToString();
                        dataGridView1.Rows.Add(id, ""+nome+" ("+nome_gen+")");
                    }
                }
                comb.close();
            }
            if (comboBox1.SelectedIndex == 2)
            {
                comb.sql = "SELECT tb02_genitora, tb02_nome, tb01_nome FROM tb02_filhos INNER JOIN tb01_genitoras ON tb02_filhos.tb02_genitora = tb01_genitoras.tb01_seq where tb02_nome LIKE '%" + textBox1.Text + "%' ORDER BY tb02_nome";
                comb.open();
                MySqlDataReader dados = comb.Execsql();
                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        string nome_gen = dados["tb01_nome"].ToString();
                        string nome = dados["tb02_nome"].ToString();
                        string id = dados["tb02_genitora"].ToString();
                        dataGridView1.Rows.Add(id, "" + nome + " (" + nome_gen + ")");
                    }
                }
                comb.close();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String cod = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            String nome_mae = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Detalhes wf = new Detalhes(cod);
            wf.Show();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String cod = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                String nome_mae = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                Detalhes wf = new Detalhes(cod);
                wf.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            dataGridView1.Rows.Clear();

        }
    }
}
