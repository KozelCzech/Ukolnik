namespace UkolnikFrontend
{
    partial class Register
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
            RegisterButton = new Button();
            UsernameBox = new TextBox();
            EmailBox = new TextBox();
            PasswordBox = new TextBox();
            Label1 = new Label();
            LoginRedirect = new LinkLabel();
            SuspendLayout();
            // 
            // RegisterButton
            // 
            RegisterButton.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            RegisterButton.Location = new Point(103, 323);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(168, 71);
            RegisterButton.TabIndex = 0;
            RegisterButton.Text = "Register";
            RegisterButton.UseVisualStyleBackColor = true;
            RegisterButton.Click += RegisterButton_Click;
            // 
            // UsernameBox
            // 
            UsernameBox.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            UsernameBox.Location = new Point(61, 99);
            UsernameBox.Name = "UsernameBox";
            UsernameBox.Size = new Size(251, 33);
            UsernameBox.TabIndex = 1;
            // 
            // EmailBox
            // 
            EmailBox.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            EmailBox.Location = new Point(61, 174);
            EmailBox.Name = "EmailBox";
            EmailBox.Size = new Size(251, 33);
            EmailBox.TabIndex = 2;
            // 
            // PasswordBox
            // 
            PasswordBox.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            PasswordBox.Location = new Point(61, 253);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.Size = new Size(251, 33);
            PasswordBox.TabIndex = 3;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font("Segoe UI Black", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            Label1.Location = new Point(103, 19);
            Label1.Name = "Label1";
            Label1.Size = new Size(149, 40);
            Label1.TabIndex = 4;
            Label1.Text = "Welcome";
            Label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginRedirect
            // 
            LoginRedirect.AutoSize = true;
            LoginRedirect.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point);
            LoginRedirect.Location = new Point(121, 303);
            LoginRedirect.Name = "LoginRedirect";
            LoginRedirect.Size = new Size(140, 17);
            LoginRedirect.TabIndex = 5;
            LoginRedirect.TabStop = true;
            LoginRedirect.Text = "Don't have an account?";
            LoginRedirect.LinkClicked += LoginRedirect_LinkClicked;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(377, 427);
            Controls.Add(LoginRedirect);
            Controls.Add(Label1);
            Controls.Add(PasswordBox);
            Controls.Add(EmailBox);
            Controls.Add(UsernameBox);
            Controls.Add(RegisterButton);
            Name = "Register";
            Text = "Register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button RegisterButton;
        private TextBox UsernameBox;
        private TextBox EmailBox;
        private TextBox PasswordBox;
        private Label Label1;
        private LinkLabel LoginRedirect;
    }
}