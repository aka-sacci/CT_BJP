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
    public partial class Adicionar_filiacao : Form
    {
        String proj;
        String mom_name;

        public void adicionar(String nome, String pai, String mae, String endereco, String bairro, String dt_nasc, String a) {
      
            
            if (nome != "" && pai != "" && mae != "" && endereco != "" && bairro != "" && dt_nasc != "") {

                Conexao comb = new Conexao();
                comb.sql = "Insert into tb02_filhos" +
                    " (tb02_nome, tb02_genitora, tb02_genitor, tb02_endereco, tb02_bairro, tb02_dt_nasc, tb02_anotacao)" +
                    " values ('" + nome + "', '" + mae + "', '" + pai + "', '" + endereco + "', '" + bairro + "', '" + dt_nasc + 
                    "', '" + a + "')";

                comb.open();
                int lin = comb.Runsql();
                comb.close();
                txt_nome.Text = "";
                txt_pai.Text = "";
                txt_end.Text = "";
                txt_bairro.Text = "";

                comb.sql = "update tb01_genitoras set tb01_last_upd = 2  where tb01_seq = " + proj + ";";
                comb.open();
                lin = comb.Runsql();
                comb.close();
                MessageBox.Show("Filiação adicionada com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();

            }
            else
            {
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }

        public Adicionar_filiacao(String mae, String nome)
        {
            InitializeComponent();
            proj = mae;
            mom_name = nome;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Adicionar_filiacao_Load(object sender, EventArgs e)
        {
            projenitora.Text = mom_name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adicionar(txt_nome.Text, txt_pai.Text, proj, txt_end.Text, txt_bairro.Text, txt_nasc.Value.Date.ToString("yyyy-MM-dd"), anotacao.Text);
        }
    }
}
