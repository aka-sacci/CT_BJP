using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_CTPERDOES
{
    public partial class Novo_nucleo : Form
    {
        
        List<string> listCod = new List<string>();
        List<string> listMae = new List<string>();
        List<string> listFilhos = new List<string>();
        int qtdeRegistros = 0;
        int pageNumber = 0;
        double pageTotalNumber = 0;

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

        private void printAll_Click(object sender, EventArgs e)
        {
            printDialog1.AllowSomePages = true;
            printDialog1.ShowHelp = true;
            printDialog1.Document = print_All;
            DialogResult result = printDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                PrintController();
            }
        }

        private void PrintController() {
            Conexao comb = new Conexao();
            comb.sql = "SELECT tb01_seq, tb01_nome, tb02_nome FROM tb01_genitoras INNER JOIN tb02_filhos ON tb01_genitoras.tb01_seq = tb02_filhos.tb02_genitora ORDER BY tb01_nome";
            comb.open();
            listCod.Clear();
            listFilhos.Clear();
            listMae.Clear();
            string maeAnterior = "";

            MySqlDataReader dados = comb.Execsql();
            if (dados.HasRows)
            {
                int i = 0;
                while (dados.Read())
                {
                    string nomeMae = dados["tb01_nome"].ToString();
                    string nomeFilho = dados["tb02_nome"].ToString();
                    string id = dados["tb01_seq"].ToString();
                    if (id == maeAnterior)
                    {
                        listCod.Add(id);
                        listMae.Add("");
                        listFilhos.Add(nomeFilho);
                    }
                    else
                    {
                        listCod.Add("");
                        listMae.Add("________________________________________________________________________________________________________________");
                        listFilhos.Add("");
                        listCod.Add("");
                        listMae.Add("");
                        listFilhos.Add("");
                        i++;
                        i++;

                        listCod.Add(id);
                        listMae.Add(nomeMae);
                        listFilhos.Add(nomeFilho);
                    }
                    maeAnterior = id;
                    i++;
                }
                qtdeRegistros = i;
            }
            comb.close();

            pageNumber = 1;
            double count = listMae.Count;
            if (listMae.Count % 60 == 0)
            {
                pageTotalNumber = qtdeRegistros / 60;
            }
            else
            {
                pageTotalNumber = Math.Floor(count / 60) + 1;
            }

            print_All.Print();
        }
            
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
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

            //definição do número das páginas
            Font fontePages = new Font("Arial", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            Point pagesPoint = new Point(700, 192);
           
            //fim header


            //Detalhes
            string textoPj = "REGISTROS";
            Font fontePj = new Font("Arial", 20, FontStyle.Regular, GraphicsUnit.Pixel);
            SolidBrush corPj = new SolidBrush(Color.Black);
            Rectangle pj = new Rectangle(0, 192, 800, 0);
            StringFormat alingPj = new StringFormat();
            alingPj.Alignment = StringAlignment.Center;
            alingPj.LineAlignment = StringAlignment.Center;
            string textoTitle1 = "PROJENITORAS";
            string textoTitle2 = "AFILIADOS";
            Font fonteTitle1 = new Font("Arial", 15, FontStyle.Bold, GraphicsUnit.Pixel);
            Rectangle recTitle1 = new Rectangle(0, 220, 300, 0);
            Rectangle recTitle2 = new Rectangle(400, 220, 300, 0);
            //fim header


            //início footer
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
            int yFilhos = 255;
            Font fonteListaNegritoNome = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel);
            Font fonteListaNome = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Pixel);


            //PRINT HEADER
            //print title
            e.Graphics.DrawImage(logo, imagePoint);
            e.Graphics.DrawString(title, fonteTitle, corTitle, header, alingTitle);
            e.Graphics.DrawString(subtitle, fonteSubtitle, corSubtitle, subheader, alingSubtitle);
            e.Graphics.DrawString(subtitle2, fonteSubtitle2, corSubtitle2, subheader2, alingSubtitle2);
            e.Graphics.DrawString(line, fonteLine, corLine, recLine, alingLine);
            e.Graphics.DrawString(textoPj, fontePj, corPj, pj, alingPj);
            e.Graphics.DrawString(textoTitle1, fonteTitle1, corPj, recTitle1, alingPj);
            e.Graphics.DrawString(textoTitle2, fonteTitle1, corPj, recTitle2, alingPj);
            e.Graphics.DrawString(pageNumber.ToString() + "/" + pageTotalNumber.ToString(), fontePages, corLine, pagesPoint, alingLine);
            pageNumber++;

            //print body
            int removeCounter = 0;
            foreach (string nome in listMae)
            {

                if (yFilhos <= 1045)
                {
                    e.Graphics.DrawString(nome, fonteListaNegritoNome, corPj, new Point(37, yFilhos));
                    yFilhos += 13;
                    removeCounter++;
                }
                else {
                    break;
                }
               
            }

            yFilhos = 255;

            foreach (string nome in listFilhos)
            {
                if (yFilhos <= 1045)
                {
                e.Graphics.DrawString(nome, fonteListaNome, corPj, new Point(400, yFilhos));
                yFilhos += 13;

                }
                else
                {
                    break;
                }
            }

            listMae.RemoveRange(0, removeCounter);
            listFilhos.RemoveRange(0, removeCounter);
            //MessageBox.Show(listMae.Count.ToString());
            //print footer
            e.Graphics.DrawString(line, fonteLine, corLine, recLineFooter, alingLine);
            e.Graphics.DrawString(l1Footer, fontel1Footer, corLine, recl1Footer, alingLine);
            e.Graphics.DrawString(l2Footer, fontel2Footer, corLine, recl2Footer, alingLine);
            e.Graphics.DrawString(l3Footer, fontel2Footer, corLine, recl3Footer, alingLine);

            if (listMae.Count > 0) {
                e.HasMorePages = true;
            }

        }
    }
}
