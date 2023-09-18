namespace UkolnikFrontend
{
    partial class Login
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
            LoginButton = new Button();
            UsernameBox = new TextBox();
            PasswordBox = new TextBox();
            Laber1 = new Label();
            linkLabel1 = new LinkLabel();
            SuspendLayout();
            // 
            // LoginButton
            // 
            LoginButton.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            LoginButton.Location = new Point(103, 323);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(168, 71);
            LoginButton.TabIndex = 0;
            LoginButton.Text = "Login";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // UsernameBox
            // 
            UsernameBox.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            UsernameBox.Location = new Point(61, 174);
            UsernameBox.Name = "UsernameBox";
            UsernameBox.Size = new Size(232, 33);
            UsernameBox.TabIndex = 1;
            // 
            // PasswordBox
            // 
            PasswordBox.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            PasswordBox.Location = new Point(61, 253);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.Size = new Size(232, 33);
            PasswordBox.TabIndex = 2;
            // 
            // Laber1
            // 
            Laber1.AutoSize = true;
            Laber1.Font = new Font("Segoe UI Black", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            Laber1.Location = new Point(103, 19);
            Laber1.Name = "Laber1";
            Laber1.Size = new Size(149, 80);
            Laber1.TabIndex = 3;
            Laber1.Text = "Welcome\r\nBack\r\n";
            Laber1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point);
            linkLabel1.Location = new Point(110, 303);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(152, 17);
            linkLabel1.TabIndex = 4;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Already have an account?";
            linkLabel1.TextAlign = ContentAlignment.MiddleCenter;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(377, 427);
            Controls.Add(linkLabel1);
            Controls.Add(Laber1);
            Controls.Add(PasswordBox);
            Controls.Add(UsernameBox);
            Controls.Add(LoginButton);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button LoginButton;
        private TextBox UsernameBox;
        private TextBox PasswordBox;
        private Label Laber1;
        private LinkLabel linkLabel1;
    }
}