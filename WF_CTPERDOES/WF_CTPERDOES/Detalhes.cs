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
using System.Timers;

namespace WF_CTPERDOES
{

    public partial class Detalhes : Form
    {
        String proj;
        String mom_name;

        public Detalhes(String mae)
        {
            InitializeComponent();
            proj = mae;

        }

    

        public void atualiza() {

            CultureInfo idioma = new CultureInfo("pt-BR");
            dataGridView1.Rows.Clear();
            Conexao comb = new Conexao();
            comb.sql = "select * from tb02_filhos " +
                "INNER JOIN tb01_genitoras ON tb02_filhos.tb02_genitora = tb01_genitoras.tb01_seq" +
                " WHERE tb02_genitora = '" + proj + "' ORDER BY tb01_nome";
            comb.open();
            MySqlDataReader dados = comb.Execsql();
            if (dados.HasRows)
            {

                while (dados.Read())
                {
                    string cod_filho = dados["tb02_id"].ToString();
                    string nome_filho = dados["tb02_nome"].ToString();
                    string nome_pai = dados["tb02_genitor"].ToString();
                    string end = dados["tb02_endereco"].ToString();
                    string bairro = dados["tb02_bairro"].ToString();
                    string dt_bd = dados["tb02_dt_nasc"].ToString();
                    string anot = dados["tb02_anotacao"].ToString();
                    var parsedDate = DateTime.Parse(dt_bd, idioma, DateTimeStyles.NoCurrentDateDefault);
                    String dt = parsedDate.ToString().Substring(0, 10);
                    dataGridView1.Rows.Add(cod_filho, nome_filho, nome_pai, dt, end + ", " + bairro, anot);
                }


            }
            comb.close();

            comb.sql = "select * from tb01_genitoras where tb01_seq = '" + proj + "';";
            comb.open();
            dados = comb.Execsql();
            if (dados.HasRows)
            {
                while (dados.Read())
                {
                    string nome_mae = dados["tb01_nome"].ToString();
                    string anot2 = dados["tb01_anotacao"].ToString();
                    Anotacao.Text = anot2;
                    projenitora.Text = nome_mae;
                }
                comb.close();

            }

            comb.sql = "update tb01_genitoras set tb01_last_upd = 1 where tb01_seq = " + proj + "";

            comb.open();

            int lin = comb.Runsql();


            comb.close();

        }
        private void Detalhes_Load(object sender, EventArgs e)
        {
            atualiza();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Adicionar_filiacao wf = new Adicionar_filiacao(proj, mom_name);
            wf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            String cod = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            editar_filiacao wf = new editar_filiacao(cod);
            wf.Show();

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String cod = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                editar_filiacao wf = new editar_filiacao(cod);
                wf.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Deseja mesmo excluir esse núcleo familiar? TODOS os registros de filhos serão apagados!!", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                Conexao comb = new Conexao();

                comb.sql = "delete from tb01_genitoras where tb01_seq = " + proj + ";";


                comb.open();

                int lin = comb.Runsql();


                comb.close();

                MessageBox.Show("Registro deletado com sucesso!");
                this.Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Editar_mae a = new Editar_mae(proj);
            a.Show();
        }

        private void timer_att_Tick(object sender, EventArgs e)
        {
            Conexao comb = new Conexao();
            int upd = 0;
            comb.sql = "select tb01_last_upd from tb01_genitoras where tb01_seq = '" + proj + "';";
            comb.open();
            MySqlDataReader dados = comb.Execsql();
            if (dados.HasRows)
            {
                while (dados.Read())
                {
                    upd = int.Parse(dados["tb01_last_upd"].ToString());
                }
                comb.close();
            }
            if (upd == 2) {

                atualiza();
            
            }

        }
    }
}
