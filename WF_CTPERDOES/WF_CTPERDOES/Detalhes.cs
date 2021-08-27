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
using System.Drawing.Printing;

namespace WF_CTPERDOES
{

    public partial class Detalhes : Form
    {
        String proj;
        String mom_name;
        int qtdeRegistros = 0;
        int qtdeImprimida = 0;
        double totalPages = 0;
        int pageNumber = 0;
    

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

        private void imprime_Nucleo_PrintPage(object sender, PrintPageEventArgs e)
        {
            //início header
            //logo bjp
            Point imagePoint = new Point(30, 20);
            Image logo = Image.FromFile(Application.StartupPath + "/logo.png");
            Graphics g = Graphics.FromImage((Image)logo);
            g.DrawImage(logo, 0, 0);
            g.Dispose();

            //titulo
            string title = "Conselho Tutelar";
            Font fonteTitle = new Font("Arial", 46, FontStyle.Regular, GraphicsUnit.Pixel);
            SolidBrush corTitle = new SolidBrush(Color.Black);
            Rectangle header = new Rectangle(100, 35, 800, 50);
            StringFormat alingTitle = new StringFormat();
            alingTitle.Alignment = StringAlignment.Center;
            alingTitle.LineAlignment = StringAlignment.Center;

            //subtitulo
            string subtitle = "Bom Jesus dos Perdões - SP";
            Font fonteSubtitle = new Font("Arial", 17, FontStyle.Regular, GraphicsUnit.Pixel);
            SolidBrush corSubtitle = new SolidBrush(Color.Black);
            Rectangle subheader = new Rectangle(100, 70, 800, 50);
            StringFormat alingSubtitle = new StringFormat();
            alingSubtitle.Alignment = StringAlignment.Center;
            alingSubtitle.LineAlignment = StringAlignment.Center;

            //sb2
            string subtitle2 = "Uma luz em defesa dos direitos da criança e do adolescente";
            Font fonteSubtitle2 = new Font("Arial", 13, FontStyle.Bold, GraphicsUnit.Pixel);
            SolidBrush corSubtitle2 = new SolidBrush(Color.Black);
            Rectangle subheader2 = new Rectangle(100, 100, 800, 50);
            StringFormat alingSubtitle2 = new StringFormat();
            alingSubtitle2.Alignment = StringAlignment.Center;
            alingSubtitle2.LineAlignment = StringAlignment.Center;

            //line
            string line = "________________________________________________________________________________";
            Font fonteLine = new Font("Arial", 17, FontStyle.Bold, GraphicsUnit.Pixel);
            SolidBrush corLine = new SolidBrush(Color.Black);
            Rectangle recLine = new Rectangle(20, 135, 800, 50);
            StringFormat alingLine = new StringFormat();
            alingLine.Alignment = StringAlignment.Center;
            alingLine.LineAlignment = StringAlignment.Center;


            //Detalhes
            string textoPj = "DETALHES DO NÚCLEO FAMILIAR";
            Font fontePj = new Font("Arial", 20, FontStyle.Regular, GraphicsUnit.Pixel);
            SolidBrush corPj = new SolidBrush(Color.Black);
            Rectangle pj = new Rectangle(0, 192, 800, 0);
            StringFormat alingPj = new StringFormat();
            alingPj.Alignment = StringAlignment.Center;
            alingPj.LineAlignment = StringAlignment.Center;

            //definição do número das páginas
            Font fontePages = new Font("Arial", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            Point pagesPoint = new Point(700, 192);
            //fim header



            //corpo
            //coleta de dados para o corpo
            Rectangle titleName = new Rectangle(37, 220, 800, 0);
            StringFormat alignProj = new StringFormat();
            alignProj.Alignment = StringAlignment.Near;
            alignProj.LineAlignment = StringAlignment.Near;
            List<string> listaFilhos = new List<string>();
            List<string> listaPais = new List<string>();
            List<string> listaData = new List<string>();
            List<string> listaEndereco = new List<string>();
            List<string> listaAnotacao = new List<string>();
            int yFilhos = 255;
            int counter = 0;

            for (int i = qtdeImprimida; i < qtdeRegistros; i++)
            {

                if (counter < 11)
                {
                    listaFilhos.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    listaPais.Add(dataGridView1.Rows[i].Cells[2].Value.ToString());
                    string dtNasc = dataGridView1.Rows[i].Cells[3].Value.ToString();

                    //calcula data de nascimento
                    DateTime dtNasc_parsed = DateTime.Parse(dtNasc);
                    double idade = Math.Floor((DateTime.Today.Subtract(dtNasc_parsed).TotalDays) / 365);
                    listaData.Add(dtNasc + " (" + idade.ToString() + " anos de idade)");
                    listaEndereco.Add(dataGridView1.Rows[i].Cells[4].Value.ToString());
                    listaAnotacao.Add(dataGridView1.Rows[i].Cells[5].Value.ToString());
                    qtdeImprimida++;
                    counter++;
               
                }
            }

            Font fonteLista = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Pixel);
            Font fonteListaNegrito = new Font("Arial", 15, FontStyle.Bold, GraphicsUnit.Pixel);
            Font fonteListaNegritoNome = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel);
            Font fonteAnotacao = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Pixel);
            SolidBrush corLista = new SolidBrush(Color.Black);
            //fim corpo


            //footer
            Rectangle recLineFooter = new Rectangle(20, 1030, 800, 50);
            string l1Footer = "Rua Bárbara Carsodo, 145 - Centro - Bom Jesus dos Perdões - SP - 12955-000";
            Font fontel1Footer = new Font("Arial", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            Font fontel2Footer = new Font("Arial", 14, FontStyle.Regular, GraphicsUnit.Pixel);
            Rectangle recl1Footer = new Rectangle(0, 1080, 800, 0);
            string l2Footer = "Tel: (11) 4012-7814 | WhatsApp: (11) 97419-7513 | Email: conselho.tutelar@bjperdoes.sp.gov.br";
            Rectangle recl2Footer = new Rectangle(0, 1100, 800, 0);
            string l3Footer = "Horário de funcionamento (Sede do conselho): 8h às 12h - 13h às 17h";
            Rectangle recl3Footer = new Rectangle(0, 1120, 800, 0);
            //fim footer


            //PRINT HEADER
            e.Graphics.DrawImage(logo, imagePoint);
            e.Graphics.DrawString(title, fonteTitle, corTitle, header, alingTitle);
            e.Graphics.DrawString(subtitle, fonteSubtitle, corSubtitle, subheader, alingSubtitle);
            e.Graphics.DrawString(subtitle2, fonteSubtitle2, corSubtitle2, subheader2, alingSubtitle2);
            e.Graphics.DrawString(line, fonteLine, corLine, recLine, alingLine);
            e.Graphics.DrawString(textoPj, fontePj, corPj, pj, alingPj);
            e.Graphics.DrawString(pageNumber.ToString() + "/" + totalPages.ToString(), fontePages, corLine, pagesPoint, alingLine);
            pageNumber++;


            //PRINT DATA
            e.Graphics.DrawString("MÃE: " + projenitora.Text, fonteListaNegrito, corSubtitle2, titleName, alignProj);
       
            foreach (string nome in listaFilhos)
            {
                e.Graphics.DrawString(nome, fonteListaNegritoNome, corLista, new Point(37, yFilhos));
                yFilhos += 75;
            }


            yFilhos = 268;
            foreach (string data in listaData)
            {
                e.Graphics.DrawString(data, fonteLista, corLista, new Point(37, yFilhos));
                e.Graphics.DrawString("ENDEREÇO:", fonteListaNegritoNome, corLista, new Point(350, yFilhos));
                yFilhos += 75;
            }

            yFilhos = 281;
            foreach (string pai in listaPais)
            {
                e.Graphics.DrawString("PAI: " + pai, fonteLista, corLista, new Point(37, yFilhos));
                yFilhos += 75;
            }

            yFilhos = 281;
            foreach (string endereco in listaEndereco)
            {
                e.Graphics.DrawString(endereco, fonteLista, corLista, new Point(350, yFilhos));
                yFilhos += 75;
            }

            yFilhos = 295;
            foreach (string anotacao in listaAnotacao)
            {
                if (anotacao == "")
                {

                }
                else {
                    e.Graphics.DrawString("*" + anotacao, fonteAnotacao, corLista, new Point(37, yFilhos));
                }
              
                yFilhos += 75;
            }
            //END PRINT DATA

            //PRINT FOOTER
            e.Graphics.DrawString(line, fonteLine, corLine, recLineFooter, alingLine);
            e.Graphics.DrawString(l1Footer, fontel1Footer, corLine, recl1Footer, alingLine);
            e.Graphics.DrawString(l2Footer, fontel2Footer, corLine, recl2Footer, alingLine);
            e.Graphics.DrawString(l3Footer, fontel2Footer, corLine, recl3Footer, alingLine);
            //end print footer

            if (qtdeRegistros -  qtdeImprimida > 0) {
                e.HasMorePages = true;
            }

            imprime_Nucleo.DocumentName = proj.ToString() + "_datails";

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            printDialog1.AllowSomePages = true;
            printDialog1.ShowHelp = true;
            printDialog1.Document = imprime_Nucleo;
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                PrintController();
            }


           
        }

        private void PrintController()
        {
            qtdeRegistros = dataGridView1.RowCount;
            qtdeImprimida = 0;
            double qtdeRegDouble = qtdeRegistros;
            pageNumber = 1;

            if (qtdeRegistros % 11 == 0)
            {
                totalPages = qtdeRegistros / 11;
            }
            else {
                totalPages = Math.Floor(qtdeRegDouble / 11) + 1;
            }

            imprime_Nucleo.Print();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
 