namespace UkolnikFrontend
{
    partial class Ukolnik
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
            LogPanel = new Panel();
            Exit = new LinkLabel();
            LogoutButton = new LinkLabel();
            LoggedUser = new LinkLabel();
            CreateTaskPanel = new Panel();
            CreateCommentButton = new Button();
            EditTaskButton = new Button();
            creationdeadline = new Label();
            TaskDeadlineBox = new DateTimePicker();
            label2 = new Label();
            TaskDescriptionBox = new TextBox();
            label1 = new Label();
            TaskNameBox = new TextBox();
            CreateTaskButton = new Button();
            panel2 = new Panel();
            TaskDisplayPanel = new Panel();
            SingleTaskPanel = new Panel();
            AddCommentButton = new Button();
            EditThisTaskButton = new Button();
            DeleteTaskButton = new Button();
            DescriptionLabel = new Label();
            ExpandTaskDisplay = new LinkLabel();
            CreatorLabel = new Label();
            StatusComboBox = new ComboBox();
            DeadLineLabel = new Label();
            TaskNameLabel = new Label();
            CommentsPanel = new Panel();
            SingleCommentPanel = new Panel();
            DeleteComment = new Button();
            CommentCreatedTime = new Label();
            CommentCreator = new Label();
            CommentText = new Label();
            CommentName = new Label();
            LogPanel.SuspendLayout();
            CreateTaskPanel.SuspendLayout();
            panel2.SuspendLayout();
            TaskDisplayPanel.SuspendLayout();
            SingleTaskPanel.SuspendLayout();
            CommentsPanel.SuspendLayout();
            SingleCommentPanel.SuspendLayout();
            SuspendLayout();
            // 
            // LogPanel
            // 
            LogPanel.Controls.Add(Exit);
            LogPanel.Controls.Add(LogoutButton);
            LogPanel.Location = new Point(40, 28);
            LogPanel.Name = "LogPanel";
            LogPanel.Size = new Size(171, 84);
            LogPanel.TabIndex = 0;
            LogPanel.Visible = false;
            // 
            // Exit
            // 
            Exit.AutoSize = true;
            Exit.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            Exit.LinkColor = Color.Black;
            Exit.Location = new Point(126, 44);
            Exit.Name = "Exit";
            Exit.Size = new Size(42, 25);
            Exit.TabIndex = 1;
            Exit.TabStop = true;
            Exit.Text = "Exit";
            Exit.LinkClicked += Exit_LinkClicked;
            // 
            // LogoutButton
            // 
            LogoutButton.AutoSize = true;
            LogoutButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            LogoutButton.LinkColor = Color.Black;
            LogoutButton.Location = new Point(89, 9);
            LogoutButton.Name = "LogoutButton";
            LogoutButton.Size = new Size(79, 25);
            LogoutButton.TabIndex = 0;
            LogoutButton.TabStop = true;
            LogoutButton.Text = "Log Out";
            LogoutButton.LinkClicked += LogoutButton_LinkClicked;
            // 
            // LoggedUser
            // 
            LoggedUser.AutoSize = true;
            LoggedUser.Dock = DockStyle.Right;
            LoggedUser.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            LoggedUser.ImageAlign = ContentAlignment.MiddleRight;
            LoggedUser.LinkBehavior = LinkBehavior.NeverUnderline;
            LoggedUser.LinkColor = Color.Black;
            LoggedUser.Location = new Point(99, 0);
            LoggedUser.Name = "LoggedUser";
            LoggedUser.Size = new Size(112, 25);
            LoggedUser.TabIndex = 1;
            LoggedUser.TabStop = true;
            LoggedUser.Text = "Placeholder";
            LoggedUser.TextAlign = ContentAlignment.MiddleRight;
            LoggedUser.LinkClicked += LoggedUser_LinkClicked;
            // 
            // CreateTaskPanel
            // 
            CreateTaskPanel.Controls.Add(CreateCommentButton);
            CreateTaskPanel.Controls.Add(EditTaskButton);
            CreateTaskPanel.Controls.Add(creationdeadline);
            CreateTaskPanel.Controls.Add(TaskDeadlineBox);
            CreateTaskPanel.Controls.Add(label2);
            CreateTaskPanel.Controls.Add(TaskDescriptionBox);
            CreateTaskPanel.Controls.Add(label1);
            CreateTaskPanel.Controls.Add(TaskNameBox);
            CreateTaskPanel.Controls.Add(CreateTaskButton);
            CreateTaskPanel.Location = new Point(12, 116);
            CreateTaskPanel.Name = "CreateTaskPanel";
            CreateTaskPanel.Size = new Size(346, 569);
            CreateTaskPanel.TabIndex = 2;
            // 
            // CreateCommentButton
            // 
            CreateCommentButton.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            CreateCommentButton.Location = new Point(3, 503);
            CreateCommentButton.Name = "CreateCommentButton";
            CreateCommentButton.Size = new Size(273, 63);
            CreateCommentButton.TabIndex = 12;
            CreateCommentButton.Text = "CreateComment";
            CreateCommentButton.UseVisualStyleBackColor = true;
            CreateCommentButton.Visible = false;
            CreateCommentButton.Click += CreateCommentButton_Click;
            // 
            // EditTaskButton
            // 
            EditTaskButton.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            EditTaskButton.Location = new Point(3, 503);
            EditTaskButton.Name = "EditTaskButton";
            EditTaskButton.Size = new Size(187, 63);
            EditTaskButton.TabIndex = 11;
            EditTaskButton.Text = "Edit Task";
            EditTaskButton.UseVisualStyleBackColor = true;
            EditTaskButton.Click += EditTaskButton_Click;
            // 
            // creationdeadline
            // 
            creationdeadline.AutoSize = true;
            creationdeadline.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            creationdeadline.Location = new Point(3, 406);
            creationdeadline.Name = "creationdeadline";
            creationdeadline.Size = new Size(105, 21);
            creationdeadline.TabIndex = 10;
            creationdeadline.Text = "Task deadline:";
            // 
            // TaskDeadlineBox
            // 
            TaskDeadlineBox.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            TaskDeadlineBox.Location = new Point(3, 430);
            TaskDeadlineBox.Name = "TaskDeadlineBox";
            TaskDeadlineBox.Size = new Size(242, 35);
            TaskDeadlineBox.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(3, 108);
            label2.Name = "label2";
            label2.Size = new Size(92, 21);
            label2.TabIndex = 8;
            label2.Text = "Description:";
            // 
            // TaskDescriptionBox
            // 
            TaskDescriptionBox.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            TaskDescriptionBox.Location = new Point(3, 132);
            TaskDescriptionBox.Multiline = true;
            TaskDescriptionBox.Name = "TaskDescriptionBox";
            TaskDescriptionBox.Size = new Size(340, 251);
            TaskDescriptionBox.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(3, 11);
            label1.Name = "label1";
            label1.Size = new Size(52, 21);
            label1.TabIndex = 6;
            label1.Text = "name:";
            // 
            // TaskNameBox
            // 
            TaskNameBox.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            TaskNameBox.Location = new Point(3, 35);
            TaskNameBox.Name = "TaskNameBox";
            TaskNameBox.Size = new Size(340, 46);
            TaskNameBox.TabIndex = 5;
            // 
            // CreateTaskButton
            // 
            CreateTaskButton.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            CreateTaskButton.Location = new Point(3, 503);
            CreateTaskButton.Name = "CreateTaskButton";
            CreateTaskButton.Size = new Size(187, 63);
            CreateTaskButton.TabIndex = 4;
            CreateTaskButton.Text = "Create task";
            CreateTaskButton.UseVisualStyleBackColor = true;
            CreateTaskButton.Click += CreateTaskButton_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(LoggedUser);
            panel2.Controls.Add(LogPanel);
            panel2.Location = new Point(939, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(211, 136);
            panel2.TabIndex = 3;
            // 
            // TaskDisplayPanel
            // 
            TaskDisplayPanel.AutoScroll = true;
            TaskDisplayPanel.Controls.Add(SingleTaskPanel);
            TaskDisplayPanel.Location = new Point(364, 116);
            TaskDisplayPanel.Name = "TaskDisplayPanel";
            TaskDisplayPanel.Size = new Size(569, 566);
            TaskDisplayPanel.TabIndex = 4;
            // 
            // SingleTaskPanel
            // 
            SingleTaskPanel.Controls.Add(AddCommentButton);
            SingleTaskPanel.Controls.Add(EditThisTaskButton);
            SingleTaskPanel.Controls.Add(DeleteTaskButton);
            SingleTaskPanel.Controls.Add(DescriptionLabel);
            SingleTaskPanel.Controls.Add(ExpandTaskDisplay);
            SingleTaskPanel.Controls.Add(CreatorLabel);
            SingleTaskPanel.Controls.Add(StatusComboBox);
            SingleTaskPanel.Controls.Add(DeadLineLabel);
            SingleTaskPanel.Controls.Add(TaskNameLabel);
            SingleTaskPanel.Dock = DockStyle.Top;
            SingleTaskPanel.Location = new Point(0, 0);
            SingleTaskPanel.Name = "SingleTaskPanel";
            SingleTaskPanel.Size = new Size(569, 306);
            SingleTaskPanel.TabIndex = 0;
            // 
            // AddCommentButton
            // 
            AddCommentButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            AddCommentButton.Location = new Point(213, 50);
            AddCommentButton.Name = "AddCommentButton";
            AddCommentButton.Size = new Size(164, 31);
            AddCommentButton.TabIndex = 8;
            AddCommentButton.Text = "Add Comment";
            AddCommentButton.UseVisualStyleBackColor = true;
            AddCommentButton.Click += AddCommentButton_Click;
            // 
            // EditThisTaskButton
            // 
            EditThisTaskButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            EditThisTaskButton.Location = new Point(459, 185);
            EditThisTaskButton.Name = "EditThisTaskButton";
            EditThisTaskButton.Size = new Size(97, 56);
            EditThisTaskButton.TabIndex = 7;
            EditThisTaskButton.Text = "Edit";
            EditThisTaskButton.UseVisualStyleBackColor = true;
            EditThisTaskButton.Click += EditThisTaskButton_Click;
            // 
            // DeleteTaskButton
            // 
            DeleteTaskButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            DeleteTaskButton.Location = new Point(459, 247);
            DeleteTaskButton.Name = "DeleteTaskButton";
            DeleteTaskButton.Size = new Size(97, 56);
            DeleteTaskButton.TabIndex = 6;
            DeleteTaskButton.Text = "Delete";
            DeleteTaskButton.UseVisualStyleBackColor = true;
            DeleteTaskButton.Click += DeleteTaskButton_Click;
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            DescriptionLabel.Location = new Point(8, 113);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new Size(445, 190);
            DescriptionLabel.TabIndex = 5;
            DescriptionLabel.Text = "DescriptionPH";
            // 
            // ExpandTaskDisplay
            // 
            ExpandTaskDisplay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ExpandTaskDisplay.AutoEllipsis = true;
            ExpandTaskDisplay.Font = new Font("Segoe UI", 10F, FontStyle.Italic, GraphicsUnit.Point);
            ExpandTaskDisplay.LinkArea = new LinkArea(0, 17);
            ExpandTaskDisplay.Location = new Point(411, 56);
            ExpandTaskDisplay.Name = "ExpandTaskDisplay";
            ExpandTaskDisplay.Size = new Size(145, 23);
            ExpandTaskDisplay.TabIndex = 4;
            ExpandTaskDisplay.TabStop = true;
            ExpandTaskDisplay.Text = "Click To Expand";
            ExpandTaskDisplay.TextAlign = ContentAlignment.MiddleRight;
            ExpandTaskDisplay.UseCompatibleTextRendering = true;
            ExpandTaskDisplay.LinkClicked += ExpandTaskDisplay_LinkClicked;
            // 
            // CreatorLabel
            // 
            CreatorLabel.Anchor = AnchorStyles.Top;
            CreatorLabel.AutoSize = true;
            CreatorLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            CreatorLabel.Location = new Point(278, 13);
            CreatorLabel.Name = "CreatorLabel";
            CreatorLabel.Size = new Size(99, 25);
            CreatorLabel.TabIndex = 3;
            CreatorLabel.Text = "CreatorPH";
            CreatorLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // StatusComboBox
            // 
            StatusComboBox.Anchor = AnchorStyles.Top;
            StatusComboBox.AutoCompleteCustomSource.AddRange(new string[] { "New", "In progress", "Done" });
            StatusComboBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            StatusComboBox.FormattingEnabled = true;
            StatusComboBox.Location = new Point(8, 50);
            StatusComboBox.Name = "StatusComboBox";
            StatusComboBox.Size = new Size(140, 29);
            StatusComboBox.TabIndex = 2;
            StatusComboBox.SelectedIndexChanged += StatusComboBox_SelectedIndexChanged;
            // 
            // DeadLineLabel
            // 
            DeadLineLabel.Anchor = AnchorStyles.Top;
            DeadLineLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            DeadLineLabel.ImageAlign = ContentAlignment.MiddleLeft;
            DeadLineLabel.Location = new Point(411, 13);
            DeadLineLabel.Name = "DeadLineLabel";
            DeadLineLabel.Size = new Size(145, 25);
            DeadLineLabel.TabIndex = 1;
            DeadLineLabel.Text = "Deadline: PH";
            DeadLineLabel.TextAlign = ContentAlignment.MiddleRight;
            DeadLineLabel.UseCompatibleTextRendering = true;
            // 
            // TaskNameLabel
            // 
            TaskNameLabel.Anchor = AnchorStyles.Top;
            TaskNameLabel.AutoSize = true;
            TaskNameLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            TaskNameLabel.Location = new Point(3, 8);
            TaskNameLabel.Name = "TaskNameLabel";
            TaskNameLabel.Size = new Size(140, 30);
            TaskNameLabel.TabIndex = 0;
            TaskNameLabel.Text = "taskNamePH";
            // 
            // CommentsPanel
            // 
            CommentsPanel.AutoScroll = true;
            CommentsPanel.Controls.Add(SingleCommentPanel);
            CommentsPanel.Location = new Point(939, 154);
            CommentsPanel.Name = "CommentsPanel";
            CommentsPanel.Size = new Size(211, 531);
            CommentsPanel.TabIndex = 5;
            // 
            // SingleCommentPanel
            // 
            SingleCommentPanel.Controls.Add(DeleteComment);
            SingleCommentPanel.Controls.Add(CommentCreatedTime);
            SingleCommentPanel.Controls.Add(CommentCreator);
            SingleCommentPanel.Controls.Add(CommentText);
            SingleCommentPanel.Controls.Add(CommentName);
            SingleCommentPanel.Dock = DockStyle.Top;
            SingleCommentPanel.Location = new Point(0, 0);
            SingleCommentPanel.Name = "SingleCommentPanel";
            SingleCommentPanel.Size = new Size(211, 282);
            SingleCommentPanel.TabIndex = 0;
            // 
            // DeleteComment
            // 
            DeleteComment.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            DeleteComment.Location = new Point(129, 238);
            DeleteComment.Name = "DeleteComment";
            DeleteComment.Size = new Size(75, 37);
            DeleteComment.TabIndex = 4;
            DeleteComment.Text = "Delete";
            DeleteComment.UseVisualStyleBackColor = true;
            DeleteComment.Click += DeleteComment_Click;
            // 
            // CommentCreatedTime
            // 
            CommentCreatedTime.AutoSize = true;
            CommentCreatedTime.Location = new Point(7, 238);
            CommentCreatedTime.Name = "CommentCreatedTime";
            CommentCreatedTime.Size = new Size(90, 15);
            CommentCreatedTime.TabIndex = 3;
            CommentCreatedTime.Text = "CreatedTimePH";
            // 
            // CommentCreator
            // 
            CommentCreator.AutoSize = true;
            CommentCreator.Location = new Point(7, 260);
            CommentCreator.Name = "CommentCreator";
            CommentCreator.Size = new Size(100, 15);
            CommentCreator.TabIndex = 2;
            CommentCreator.Text = "CommentCreator";
            // 
            // CommentText
            // 
            CommentText.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            CommentText.Location = new Point(6, 39);
            CommentText.Name = "CommentText";
            CommentText.Size = new Size(202, 199);
            CommentText.TabIndex = 1;
            CommentText.Text = "CommentTextPH";
            // 
            // CommentName
            // 
            CommentName.AutoSize = true;
            CommentName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            CommentName.Location = new Point(6, 8);
            CommentName.Name = "CommentName";
            CommentName.Size = new Size(153, 21);
            CommentName.TabIndex = 0;
            CommentName.Text = "CommentNamePH";
            // 
            // Ukolnik
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1162, 697);
            Controls.Add(CommentsPanel);
            Controls.Add(TaskDisplayPanel);
            Controls.Add(panel2);
            Controls.Add(CreateTaskPanel);
            Name = "Ukolnik";
            Text = "Ukolnik";
            Load += Ukolnik_Load;
            LogPanel.ResumeLayout(false);
            LogPanel.PerformLayout();
            CreateTaskPanel.ResumeLayout(false);
            CreateTaskPanel.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            TaskDisplayPanel.ResumeLayout(false);
            SingleTaskPanel.ResumeLayout(false);
            SingleTaskPanel.PerformLayout();
            CommentsPanel.ResumeLayout(false);
            SingleCommentPanel.ResumeLayout(false);
            SingleCommentPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel LogPanel;
        private LinkLabel LogoutButton;
        private LinkLabel LoggedUser;
        private Panel CreateTaskPanel;
        private Panel panel2;
        private Button CreateTaskButton;
        private Label label1;
        private TextBox TaskNameBox;
        private Label label2;
        private TextBox TaskDescriptionBox;
        private Label creationdeadline;
        private DateTimePicker TaskDeadlineBox;
        private Panel TaskDisplayPanel;
        private Panel SingleTaskPanel;
        private ComboBox StatusComboBox;
        private Label DeadLineLabel;
        private Label TaskNameLabel;
        private LinkLabel ExpandTaskDisplay;
        private Label CreatorLabel;
        private Label DescriptionLabel;
        private Button EditTaskButton;
        private Button EditThisTaskButton;
        private Button DeleteTaskButton;
        private Panel CommentsPanel;
        private Panel SingleCommentPanel;
        private Label CommentText;
        private Label CommentName;
        private Label CommentCreator;
        private Button CreateCommentButton;
        private Label CommentCreatedTime;
        private Button AddCommentButton;
        private Button DeleteComment;
        private LinkLabel Exit;
    }
}