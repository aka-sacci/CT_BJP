namespace WF_CTPERDOES
{
    partial class Detalhes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Detalhes));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.projenitora = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filhos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projenitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endereco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dt_anotacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.Anotacao = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.timer_att = new System.Windows.Forms.Timer(this.components);
            this.imprime_Nucleo = new System.Drawing.Printing.PrintDocument();
            this.button2 = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(360, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Detalhes do núcleo familiar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Projenitora:";
            // 
            // projenitora
            // 
            this.projenitora.AutoSize = true;
            this.projenitora.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projenitora.Location = new System.Drawing.Point(110, 66);
            this.projenitora.Name = "projenitora";
            this.projenitora.Size = new System.Drawing.Size(130, 24);
            this.projenitora.TabIndex = 6;
            this.projenitora.Text = "Nome da mãe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Afiliados";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod,
            this.filhos,
            this.projenitor,
            this.dt,
            this.endereco,
            this.dt_anotacao});
            this.dataGridView1.Location = new System.Drawing.Point(12, 134);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1263, 232);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // cod
            // 
            this.cod.HeaderText = "codigo";
            this.cod.MinimumWidth = 6;
            this.cod.Name = "cod";
            this.cod.ReadOnly = true;
            this.cod.Visible = false;
            this.cod.Width = 125;
            // 
            // filhos
            // 
            this.filhos.HeaderText = "Filhos(s)";
            this.filhos.MinimumWidth = 6;
            this.filhos.Name = "filhos";
            this.filhos.ReadOnly = true;
            this.filhos.Width = 200;
            // 
            // projenitor
            // 
            this.projenitor.HeaderText = "Projenitor";
            this.projenitor.MinimumWidth = 6;
            this.projenitor.Name = "projenitor";
            this.projenitor.ReadOnly = true;
            this.projenitor.Width = 200;
            // 
            // dt
            // 
            this.dt.HeaderText = "D. N.";
            this.dt.MinimumWidth = 6;
            this.dt.Name = "dt";
            this.dt.ReadOnly = true;
            this.dt.Width = 125;
            // 
            // endereco
            // 
            this.endereco.HeaderText = "Endereco";
            this.endereco.MinimumWidth = 6;
            this.endereco.Name = "endereco";
            this.endereco.ReadOnly = true;
            this.endereco.Width = 400;
            // 
            // dt_anotacao
            // 
            this.dt_anotacao.HeaderText = "Anotação ";
            this.dt_anotacao.MinimumWidth = 6;
            this.dt_anotacao.Name = "dt_anotacao";
            this.dt_anotacao.ReadOnly = true;
            this.dt_anotacao.Width = 300;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1145, 446);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Adicionar novo membro";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Anotacao
            // 
            this.Anotacao.AutoSize = true;
            this.Anotacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Anotacao.Location = new System.Drawing.Point(12, 412);
            this.Anotacao.Name = "Anotacao";
            this.Anotacao.Size = new System.Drawing.Size(108, 20);
            this.Anotacao.TabIndex = 12;
            this.Anotacao.Text = "Nome da mãe";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 388);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(290, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "Anotação sobre o núcleo familiar:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1119, 98);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(156, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "Excluir núcleo familiar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1119, 69);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(156, 23);
            this.button4.TabIndex = 14;
            this.button4.Text = "Editar detalhes da genitora";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // timer_att
            // 
            this.timer_att.Enabled = true;
            this.timer_att.Interval = 1000;
            this.timer_att.Tick += new System.EventHandler(this.timer_att_Tick);
            // 
            // imprime_Nucleo
            // 
            this.imprime_Nucleo.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.imprime_Nucleo_PrintPage);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1145, 388);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Imprimir relatório";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1145, 417);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(130, 23);
            this.button5.TabIndex = 16;
            this.button5.Text = "Atualizar dados";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Detalhes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1288, 501);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Anotacao);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.projenitora);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1304, 540);
            this.MinimumSize = new System.Drawing.Size(1304, 540);
            this.Name = "Detalhes";
            this.Text = "Sistema de Gestão de Prontuários - Bom Jesus dos Perdões";
            this.Load += new System.EventHandler(this.Detalhes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label projenitora;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn filhos;
        private System.Windows.Forms.DataGridViewTextBoxColumn projenitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dt;
        private System.Windows.Forms.DataGridViewTextBoxColumn endereco;
        private System.Windows.Forms.DataGridViewTextBoxColumn dt_anotacao;
        private System.Windows.Forms.Label Anotacao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Timer timer_att;
        private System.Drawing.Printing.PrintDocument imprime_Nucleo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Button button5;
    }
}