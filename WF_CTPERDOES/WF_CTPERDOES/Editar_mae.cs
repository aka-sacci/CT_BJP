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

    public partial class Editar_mae : Form
    {
        String cod_mae;

        public void adicionar(String nome, String anot)
        {


            if (nome != "")
            {

                Conexao comb = new Conexao();

                comb.sql = "update tb01_genitoras" +
                    " set tb01_nome = '" + nome + "', tb01_anotacao = '" + anot + "', tb01_last_upd = 2 where tb01_seq = " + cod_mae + "";

                comb.open();

                int lin = comb.Runsql();


                comb.close();

                MessageBox.Show("Registro alterado com sucesso!");
                this.Hide();


            }
            else
            {
                MessageBox.Show("Preencha todos os campos obrigatórios!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nome.Focus();

            }

        }

        public Editar_mae(String cod_mae)
        {
            InitializeComponent();
            this.cod_mae = cod_mae;
        }

        private void Editar_mae_Load(object sender, EventArgs e)
        {

            Conexao comb = new Conexao();
            comb.sql = "select * from tb01_genitoras where tb01_seq = " + cod_mae + "";
            comb.open();
            MySqlDataReader dados = comb.Execsql();
            if (dados.HasRows)
            {
                while (dados.Read())
                {


                    string nome_mae = dados["tb01_nome"].ToString();
                    string anot = dados["tb01_anotacao"].ToString();
                    nome.Text = nome_mae;
                    anotacao.Text = anot;
        



                }
            }
            comb.close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Deseja mesmo alterar esse registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                adicionar(nome.Text, anotacao.Text);
            }
        }
    }
}
