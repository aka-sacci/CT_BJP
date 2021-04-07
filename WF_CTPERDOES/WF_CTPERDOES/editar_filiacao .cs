using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_CTPERDOES
{
    public partial class editar_filiacao : Form
    {
        String cod_filho;
        CultureInfo idioma = new CultureInfo("pt-BR");
        String proj;
        public editar_filiacao(String filho)
        {
            InitializeComponent();
            cod_filho = filho;
        }

        public void adicionar(String nome, String pai, String endereco, String bairro, String dt_nasc, String anot)
        {


            if (nome != "" && pai != "" &&  endereco != "" && bairro != "" && dt_nasc != "")
            {

                Conexao comb = new Conexao();
                comb.sql = "update tb02_filhos" +
                    " set tb02_nome = '" + nome + "', tb02_genitor = '" + pai + "', tb02_endereco = '" + endereco + "'," +
                    " tb02_bairro = '" + bairro + "', tb02_dt_nasc = '" + dt_nasc + "', tb02_anotacao = '" + anot + "' where tb02_id = " + cod_filho + "";
                comb.open();
                int lin = comb.Runsql();
                comb.close();

                
                comb.sql = "update tb01_genitoras set tb01_last_upd = 2  where tb01_seq = " + proj + ";";
                comb.open();
                lin = comb.Runsql();
                comb.close();
                MessageBox.Show("Registro alterado com sucesso!");
                this.Hide();


            }
            else
            {
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }

        private void editar_filiacao_Load(object sender, EventArgs e)
        {
            
            Conexao comb = new Conexao();
            comb.sql = "select * from tb02_filhos " +
                "INNER JOIN tb01_genitoras ON tb02_filhos.tb02_genitora = tb01_genitoras.tb01_seq " +
                "where tb02_id = '" + cod_filho + "'";
            comb.open();
            MySqlDataReader dados = comb.Execsql();
            if (dados.HasRows)
            {
                while (dados.Read())
                {
                    
                    string nome_filho = dados["tb02_nome"].ToString();
                    string nome_mae = dados["tb01_nome"].ToString();
                    string nome_pai = dados["tb02_genitor"].ToString();
                    string endereco = dados["tb02_endereco"].ToString();
                    string bairro = dados["tb02_bairro"].ToString();
                    string dt_nasc = dados["tb02_dt_nasc"].ToString();
                    string anot = dados["tb02_anotacao"].ToString();
                    proj = dados["tb01_seq"].ToString();
                    projenitora.Text = nome_mae;
                    txt_nome.Text = nome_filho;
                    txt_pai.Text = nome_pai;
                    txt_end.Text = endereco;
                    txt_bairro.Text = bairro;
                    anotacao.Text = anot;
                    var parsedDate = DateTime.Parse(dt_nasc, idioma, DateTimeStyles.NoCurrentDateDefault);
                    String dt = parsedDate.ToString().Substring(0, 10);
                    txt_nasc.Text = dt;



                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Deseja mesmo alterar esse registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                adicionar(txt_nome.Text, txt_pai.Text, txt_end.Text, txt_bairro.Text, txt_nasc.Value.Date.ToString("yyyy-MM-dd"), anotacao.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Deseja mesmo excluir esse registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Conexao comb = new Conexao();
                comb.sql = "delete from tb02_filhos where tb02_id = " + cod_filho + ";";
                comb.open();
                int lin = comb.Runsql();
                comb.close();

                comb.sql = "update tb01_genitoras set tb01_last_upd = 2  where tb01_seq = " + proj + ";";
                comb.open();
                lin = comb.Runsql();
                comb.close();
                MessageBox.Show("Registro deletado com sucesso!");
                this.Hide();
            }
        }
    }
}
