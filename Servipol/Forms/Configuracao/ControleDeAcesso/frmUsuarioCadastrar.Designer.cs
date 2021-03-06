
namespace Servipol.Forms.Configuração.Controle_de_Acesso
{
    partial class frmUsuarioCadastrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuarioCadastrar));
            this.label12 = new System.Windows.Forms.Label();
            this.tabControlUsuario = new System.Windows.Forms.TabControl();
            this.tabPrincipal = new System.Windows.Forms.TabPage();
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.tBoxLogin = new System.Windows.Forms.TextBox();
            this.gbSituacao = new System.Windows.Forms.GroupBox();
            this.chkBoxRegistroAtivo = new System.Windows.Forms.CheckBox();
            this.gbNome = new System.Windows.Forms.GroupBox();
            this.tBoxNome = new System.Windows.Forms.TextBox();
            this.gbNovaSenha = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tBoxCriarRepeticaoSenha = new System.Windows.Forms.TextBox();
            this.tBoxCriarSenha = new System.Windows.Forms.TextBox();
            this.gbAlterarSenha = new System.Windows.Forms.GroupBox();
            this.tBoxRepeticaoNovaSenha = new System.Windows.Forms.TextBox();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.tBoxNovaSenha = new System.Windows.Forms.TextBox();
            this.chkBoxAlterarSenha = new System.Windows.Forms.CheckBox();
            this.tabDadosRegistro = new System.Windows.Forms.TabPage();
            this.groupBox35 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tBoxDataAlteracao = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tBoxUsuarioAlteracao = new System.Windows.Forms.TextBox();
            this.groupBox37 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tBoxDataCadastro = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tBoxUsuarioCadastro = new System.Windows.Forms.TextBox();
            this.groupBox38 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tBoxDataDesativacao = new System.Windows.Forms.TextBox();
            this.tBoxUsuarioDesativacao = new System.Windows.Forms.TextBox();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnConfirmar = new DevExpress.XtraEditors.SimpleButton();
            this.tabControlUsuario.SuspendLayout();
            this.tabPrincipal.SuspendLayout();
            this.gbLogin.SuspendLayout();
            this.gbSituacao.SuspendLayout();
            this.gbNome.SuspendLayout();
            this.gbNovaSenha.SuspendLayout();
            this.gbAlterarSenha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.tabDadosRegistro.SuspendLayout();
            this.groupBox35.SuspendLayout();
            this.groupBox37.SuspendLayout();
            this.groupBox38.SuspendLayout();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 9F);
            this.label12.Location = new System.Drawing.Point(6, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 14);
            this.label12.TabIndex = 13;
            this.label12.Text = "Usuário:";
            // 
            // tabControlUsuario
            // 
            this.tabControlUsuario.Controls.Add(this.tabPrincipal);
            this.tabControlUsuario.Controls.Add(this.tabDadosRegistro);
            this.tabControlUsuario.Location = new System.Drawing.Point(1, 2);
            this.tabControlUsuario.Name = "tabControlUsuario";
            this.tabControlUsuario.SelectedIndex = 0;
            this.tabControlUsuario.Size = new System.Drawing.Size(435, 289);
            this.tabControlUsuario.TabIndex = 241;
            this.tabControlUsuario.TabStop = false;
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.gbLogin);
            this.tabPrincipal.Controls.Add(this.gbSituacao);
            this.tabPrincipal.Controls.Add(this.gbNome);
            this.tabPrincipal.Controls.Add(this.gbNovaSenha);
            this.tabPrincipal.Controls.Add(this.gbAlterarSenha);
            this.tabPrincipal.Location = new System.Drawing.Point(4, 22);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrincipal.Size = new System.Drawing.Size(427, 263);
            this.tabPrincipal.TabIndex = 0;
            this.tabPrincipal.Text = "Principal";
            this.tabPrincipal.UseVisualStyleBackColor = true;
            // 
            // gbLogin
            // 
            this.gbLogin.Controls.Add(this.tBoxLogin);
            this.gbLogin.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLogin.Location = new System.Drawing.Point(6, 67);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(415, 55);
            this.gbLogin.TabIndex = 2;
            this.gbLogin.TabStop = false;
            this.gbLogin.Text = "Login*";
            // 
            // tBoxLogin
            // 
            this.tBoxLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxLogin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBoxLogin.Font = new System.Drawing.Font("Calibri", 9F);
            this.tBoxLogin.Location = new System.Drawing.Point(6, 24);
            this.tBoxLogin.Name = "tBoxLogin";
            this.tBoxLogin.Size = new System.Drawing.Size(403, 22);
            this.tBoxLogin.TabIndex = 1;
            // 
            // gbSituacao
            // 
            this.gbSituacao.Controls.Add(this.chkBoxRegistroAtivo);
            this.gbSituacao.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSituacao.Location = new System.Drawing.Point(6, 209);
            this.gbSituacao.Name = "gbSituacao";
            this.gbSituacao.Size = new System.Drawing.Size(128, 48);
            this.gbSituacao.TabIndex = 8;
            this.gbSituacao.TabStop = false;
            this.gbSituacao.Text = "Situação";
            // 
            // chkBoxRegistroAtivo
            // 
            this.chkBoxRegistroAtivo.AutoSize = true;
            this.chkBoxRegistroAtivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkBoxRegistroAtivo.Font = new System.Drawing.Font("Calibri", 9F);
            this.chkBoxRegistroAtivo.Location = new System.Drawing.Point(6, 22);
            this.chkBoxRegistroAtivo.Name = "chkBoxRegistroAtivo";
            this.chkBoxRegistroAtivo.Size = new System.Drawing.Size(100, 18);
            this.chkBoxRegistroAtivo.TabIndex = 1;
            this.chkBoxRegistroAtivo.Text = "Registro Ativo";
            this.chkBoxRegistroAtivo.UseVisualStyleBackColor = true;
            // 
            // gbNome
            // 
            this.gbNome.Controls.Add(this.tBoxNome);
            this.gbNome.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbNome.Location = new System.Drawing.Point(6, 6);
            this.gbNome.Name = "gbNome";
            this.gbNome.Size = new System.Drawing.Size(415, 55);
            this.gbNome.TabIndex = 1;
            this.gbNome.TabStop = false;
            this.gbNome.Text = "Nome*";
            // 
            // tBoxNome
            // 
            this.tBoxNome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBoxNome.Font = new System.Drawing.Font("Calibri", 9F);
            this.tBoxNome.Location = new System.Drawing.Point(6, 24);
            this.tBoxNome.Name = "tBoxNome";
            this.tBoxNome.Size = new System.Drawing.Size(403, 22);
            this.tBoxNome.TabIndex = 1;
            // 
            // gbNovaSenha
            // 
            this.gbNovaSenha.Controls.Add(this.label2);
            this.gbNovaSenha.Controls.Add(this.label1);
            this.gbNovaSenha.Controls.Add(this.tBoxCriarRepeticaoSenha);
            this.gbNovaSenha.Controls.Add(this.tBoxCriarSenha);
            this.gbNovaSenha.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbNovaSenha.Location = new System.Drawing.Point(6, 128);
            this.gbNovaSenha.Name = "gbNovaSenha";
            this.gbNovaSenha.Size = new System.Drawing.Size(415, 78);
            this.gbNovaSenha.TabIndex = 4;
            this.gbNovaSenha.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.label2.Location = new System.Drawing.Point(188, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Repita a senha:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.label1.Location = new System.Drawing.Point(6, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Senha:";
            // 
            // tBoxCriarRepeticaoSenha
            // 
            this.tBoxCriarRepeticaoSenha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBoxCriarRepeticaoSenha.Font = new System.Drawing.Font("Calibri", 9F);
            this.tBoxCriarRepeticaoSenha.Location = new System.Drawing.Point(284, 46);
            this.tBoxCriarRepeticaoSenha.Name = "tBoxCriarRepeticaoSenha";
            this.tBoxCriarRepeticaoSenha.Size = new System.Drawing.Size(125, 22);
            this.tBoxCriarRepeticaoSenha.TabIndex = 3;
            this.tBoxCriarRepeticaoSenha.UseSystemPasswordChar = true;
            // 
            // tBoxCriarSenha
            // 
            this.tBoxCriarSenha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBoxCriarSenha.Font = new System.Drawing.Font("Calibri", 9F);
            this.tBoxCriarSenha.Location = new System.Drawing.Point(57, 46);
            this.tBoxCriarSenha.Name = "tBoxCriarSenha";
            this.tBoxCriarSenha.Size = new System.Drawing.Size(125, 22);
            this.tBoxCriarSenha.TabIndex = 2;
            this.tBoxCriarSenha.UseSystemPasswordChar = true;
            // 
            // gbAlterarSenha
            // 
            this.gbAlterarSenha.Controls.Add(this.tBoxRepeticaoNovaSenha);
            this.gbAlterarSenha.Controls.Add(this.textEdit2);
            this.gbAlterarSenha.Controls.Add(this.textEdit1);
            this.gbAlterarSenha.Controls.Add(this.tBoxNovaSenha);
            this.gbAlterarSenha.Controls.Add(this.chkBoxAlterarSenha);
            this.gbAlterarSenha.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAlterarSenha.Location = new System.Drawing.Point(6, 125);
            this.gbAlterarSenha.Name = "gbAlterarSenha";
            this.gbAlterarSenha.Size = new System.Drawing.Size(415, 78);
            this.gbAlterarSenha.TabIndex = 3;
            this.gbAlterarSenha.TabStop = false;
            // 
            // tBoxRepeticaoNovaSenha
            // 
            this.tBoxRepeticaoNovaSenha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBoxRepeticaoNovaSenha.Font = new System.Drawing.Font("Calibri", 9F);
            this.tBoxRepeticaoNovaSenha.Location = new System.Drawing.Point(284, 46);
            this.tBoxRepeticaoNovaSenha.Name = "tBoxRepeticaoNovaSenha";
            this.tBoxRepeticaoNovaSenha.Size = new System.Drawing.Size(125, 22);
            this.tBoxRepeticaoNovaSenha.TabIndex = 5;
            // 
            // textEdit2
            // 
            this.textEdit2.EditValue = "Repita a senha:";
            this.textEdit2.Location = new System.Drawing.Point(191, 48);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(87, 20);
            this.textEdit2.TabIndex = 4;
            // 
            // textEdit1
            // 
            this.textEdit1.EditValue = "Senha:";
            this.textEdit1.Location = new System.Drawing.Point(6, 48);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(45, 20);
            this.textEdit1.TabIndex = 3;
            // 
            // tBoxNovaSenha
            // 
            this.tBoxNovaSenha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBoxNovaSenha.Font = new System.Drawing.Font("Calibri", 9F);
            this.tBoxNovaSenha.Location = new System.Drawing.Point(57, 46);
            this.tBoxNovaSenha.Name = "tBoxNovaSenha";
            this.tBoxNovaSenha.Size = new System.Drawing.Size(125, 22);
            this.tBoxNovaSenha.TabIndex = 2;
            // 
            // chkBoxAlterarSenha
            // 
            this.chkBoxAlterarSenha.AutoSize = true;
            this.chkBoxAlterarSenha.Font = new System.Drawing.Font("Calibri", 9F);
            this.chkBoxAlterarSenha.Location = new System.Drawing.Point(6, 22);
            this.chkBoxAlterarSenha.Name = "chkBoxAlterarSenha";
            this.chkBoxAlterarSenha.Size = new System.Drawing.Size(100, 18);
            this.chkBoxAlterarSenha.TabIndex = 1;
            this.chkBoxAlterarSenha.Text = "Alterar Senha";
            this.chkBoxAlterarSenha.UseVisualStyleBackColor = true;
            // 
            // tabDadosRegistro
            // 
            this.tabDadosRegistro.Controls.Add(this.groupBox35);
            this.tabDadosRegistro.Controls.Add(this.groupBox37);
            this.tabDadosRegistro.Controls.Add(this.groupBox38);
            this.tabDadosRegistro.Location = new System.Drawing.Point(4, 22);
            this.tabDadosRegistro.Name = "tabDadosRegistro";
            this.tabDadosRegistro.Padding = new System.Windows.Forms.Padding(3);
            this.tabDadosRegistro.Size = new System.Drawing.Size(427, 263);
            this.tabDadosRegistro.TabIndex = 4;
            this.tabDadosRegistro.Text = "Dados do Registro";
            this.tabDadosRegistro.UseVisualStyleBackColor = true;
            // 
            // groupBox35
            // 
            this.groupBox35.Controls.Add(this.label13);
            this.groupBox35.Controls.Add(this.tBoxDataAlteracao);
            this.groupBox35.Controls.Add(this.label14);
            this.groupBox35.Controls.Add(this.tBoxUsuarioAlteracao);
            this.groupBox35.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox35.Location = new System.Drawing.Point(3, 83);
            this.groupBox35.Name = "groupBox35";
            this.groupBox35.Size = new System.Drawing.Size(421, 69);
            this.groupBox35.TabIndex = 999;
            this.groupBox35.TabStop = false;
            this.groupBox35.Text = "Dados da última alteração do cadastro";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F);
            this.label13.Location = new System.Drawing.Point(6, 45);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 14);
            this.label13.TabIndex = 15;
            this.label13.Text = "Data:";
            // 
            // tBoxDataAlteracao
            // 
            this.tBoxDataAlteracao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxDataAlteracao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBoxDataAlteracao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBoxDataAlteracao.Font = new System.Drawing.Font("Calibri", 9F);
            this.tBoxDataAlteracao.Location = new System.Drawing.Point(65, 45);
            this.tBoxDataAlteracao.Name = "tBoxDataAlteracao";
            this.tBoxDataAlteracao.ReadOnly = true;
            this.tBoxDataAlteracao.Size = new System.Drawing.Size(351, 15);
            this.tBoxDataAlteracao.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 9F);
            this.label14.Location = new System.Drawing.Point(6, 25);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 14);
            this.label14.TabIndex = 13;
            this.label14.Text = "Usuário:";
            // 
            // tBoxUsuarioAlteracao
            // 
            this.tBoxUsuarioAlteracao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxUsuarioAlteracao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBoxUsuarioAlteracao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBoxUsuarioAlteracao.Font = new System.Drawing.Font("Calibri", 9F);
            this.tBoxUsuarioAlteracao.Location = new System.Drawing.Point(65, 25);
            this.tBoxUsuarioAlteracao.Name = "tBoxUsuarioAlteracao";
            this.tBoxUsuarioAlteracao.ReadOnly = true;
            this.tBoxUsuarioAlteracao.Size = new System.Drawing.Size(350, 15);
            this.tBoxUsuarioAlteracao.TabIndex = 12;
            // 
            // groupBox37
            // 
            this.groupBox37.Controls.Add(this.label9);
            this.groupBox37.Controls.Add(this.tBoxDataCadastro);
            this.groupBox37.Controls.Add(this.label10);
            this.groupBox37.Controls.Add(this.tBoxUsuarioCadastro);
            this.groupBox37.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox37.Location = new System.Drawing.Point(3, 6);
            this.groupBox37.Name = "groupBox37";
            this.groupBox37.Size = new System.Drawing.Size(421, 71);
            this.groupBox37.TabIndex = 800;
            this.groupBox37.TabStop = false;
            this.groupBox37.Text = "Dados da inclusão do cadastro";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9F);
            this.label9.Location = new System.Drawing.Point(6, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 14);
            this.label9.TabIndex = 15;
            this.label9.Text = "Data:";
            // 
            // tBoxDataCadastro
            // 
            this.tBoxDataCadastro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxDataCadastro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBoxDataCadastro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBoxDataCadastro.Font = new System.Drawing.Font("Calibri", 9F);
            this.tBoxDataCadastro.Location = new System.Drawing.Point(65, 45);
            this.tBoxDataCadastro.Name = "tBoxDataCadastro";
            this.tBoxDataCadastro.ReadOnly = true;
            this.tBoxDataCadastro.Size = new System.Drawing.Size(349, 15);
            this.tBoxDataCadastro.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9F);
            this.label10.Location = new System.Drawing.Point(6, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 14);
            this.label10.TabIndex = 13;
            this.label10.Text = "Usuário:";
            // 
            // tBoxUsuarioCadastro
            // 
            this.tBoxUsuarioCadastro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxUsuarioCadastro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBoxUsuarioCadastro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBoxUsuarioCadastro.Font = new System.Drawing.Font("Calibri", 9F);
            this.tBoxUsuarioCadastro.Location = new System.Drawing.Point(65, 25);
            this.tBoxUsuarioCadastro.Name = "tBoxUsuarioCadastro";
            this.tBoxUsuarioCadastro.ReadOnly = true;
            this.tBoxUsuarioCadastro.Size = new System.Drawing.Size(350, 15);
            this.tBoxUsuarioCadastro.TabIndex = 12;
            // 
            // groupBox38
            // 
            this.groupBox38.Controls.Add(this.label11);
            this.groupBox38.Controls.Add(this.tBoxDataDesativacao);
            this.groupBox38.Controls.Add(this.label12);
            this.groupBox38.Controls.Add(this.tBoxUsuarioDesativacao);
            this.groupBox38.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox38.Location = new System.Drawing.Point(3, 158);
            this.groupBox38.Name = "groupBox38";
            this.groupBox38.Size = new System.Drawing.Size(421, 70);
            this.groupBox38.TabIndex = 900;
            this.groupBox38.TabStop = false;
            this.groupBox38.Text = "Dados da última desativação do cadastro";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9F);
            this.label11.Location = new System.Drawing.Point(6, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 14);
            this.label11.TabIndex = 15;
            this.label11.Text = "Data:";
            // 
            // tBoxDataDesativacao
            // 
            this.tBoxDataDesativacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxDataDesativacao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBoxDataDesativacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBoxDataDesativacao.Font = new System.Drawing.Font("Calibri", 9F);
            this.tBoxDataDesativacao.Location = new System.Drawing.Point(65, 45);
            this.tBoxDataDesativacao.Name = "tBoxDataDesativacao";
            this.tBoxDataDesativacao.ReadOnly = true;
            this.tBoxDataDesativacao.Size = new System.Drawing.Size(350, 15);
            this.tBoxDataDesativacao.TabIndex = 14;
            // 
            // tBoxUsuarioDesativacao
            // 
            this.tBoxUsuarioDesativacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxUsuarioDesativacao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBoxUsuarioDesativacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBoxUsuarioDesativacao.Font = new System.Drawing.Font("Calibri", 9F);
            this.tBoxUsuarioDesativacao.Location = new System.Drawing.Point(65, 25);
            this.tBoxUsuarioDesativacao.Name = "tBoxUsuarioDesativacao";
            this.tBoxUsuarioDesativacao.ReadOnly = true;
            this.tBoxUsuarioDesativacao.Size = new System.Drawing.Size(350, 15);
            this.tBoxUsuarioDesativacao.TabIndex = 12;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Appearance.Options.UseFont = true;
            this.btnCancelar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnCancelar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCancelar.ImageOptions.SvgImage")));
            this.btnCancelar.Location = new System.Drawing.Point(5, 297);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(143, 44);
            this.btnCancelar.TabIndex = 240;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Text = "[Esc] - Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.Appearance.Options.UseFont = true;
            this.btnConfirmar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnConfirmar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnConfirmar.ImageOptions.SvgImage")));
            this.btnConfirmar.Location = new System.Drawing.Point(289, 297);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(143, 44);
            this.btnConfirmar.TabIndex = 5;
            this.btnConfirmar.Text = "[F12] - Confirmar";
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmUsuarioCadastrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 344);
            this.Controls.Add(this.tabControlUsuario);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUsuarioCadastrar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmUsuarioCadastrar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUsuarioCadastrar_KeyDown);
            this.tabControlUsuario.ResumeLayout(false);
            this.tabPrincipal.ResumeLayout(false);
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            this.gbSituacao.ResumeLayout(false);
            this.gbSituacao.PerformLayout();
            this.gbNome.ResumeLayout(false);
            this.gbNome.PerformLayout();
            this.gbNovaSenha.ResumeLayout(false);
            this.gbNovaSenha.PerformLayout();
            this.gbAlterarSenha.ResumeLayout(false);
            this.gbAlterarSenha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.tabDadosRegistro.ResumeLayout(false);
            this.groupBox35.ResumeLayout(false);
            this.groupBox35.PerformLayout();
            this.groupBox37.ResumeLayout(false);
            this.groupBox37.PerformLayout();
            this.groupBox38.ResumeLayout(false);
            this.groupBox38.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabControl tabControlUsuario;
        private System.Windows.Forms.TabPage tabPrincipal;
        private System.Windows.Forms.GroupBox gbSituacao;
        private System.Windows.Forms.CheckBox chkBoxRegistroAtivo;
        private System.Windows.Forms.GroupBox gbNome;
        private System.Windows.Forms.TextBox tBoxNome;
        private System.Windows.Forms.TabPage tabDadosRegistro;
        private System.Windows.Forms.GroupBox groupBox35;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tBoxDataAlteracao;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tBoxUsuarioAlteracao;
        private System.Windows.Forms.GroupBox groupBox37;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tBoxDataCadastro;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tBoxUsuarioCadastro;
        private System.Windows.Forms.GroupBox groupBox38;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tBoxDataDesativacao;
        private System.Windows.Forms.TextBox tBoxUsuarioDesativacao;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnConfirmar;
        private System.Windows.Forms.GroupBox gbAlterarSenha;
        private System.Windows.Forms.TextBox tBoxRepeticaoNovaSenha;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private System.Windows.Forms.TextBox tBoxNovaSenha;
        private System.Windows.Forms.CheckBox chkBoxAlterarSenha;
        private System.Windows.Forms.GroupBox gbLogin;
        private System.Windows.Forms.TextBox tBoxLogin;
        private System.Windows.Forms.GroupBox gbNovaSenha;
        private System.Windows.Forms.TextBox tBoxCriarRepeticaoSenha;
        private System.Windows.Forms.TextBox tBoxCriarSenha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}