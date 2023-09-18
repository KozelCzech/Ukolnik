using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Text.Json;
using System.Reflection.Metadata.Ecma335;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.VisualBasic;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using Newtonsoft.Json.Linq;
using UkolnikFrontend.Models;
using System.Diagnostics;

namespace UkolnikFrontend
{
    public partial class Ukolnik : Form
    {
        private readonly HttpClient _httpClient;
        private List<Models.Tasks> _tasks;
        private List<Models.Comments> _comments;
        private bool tasksLoaded = false;
        private int editTaskId = 0;
        private int commentTaskId = 0;
        private string loggedInUser = null;
        Dictionary<int, bool> isExpanded = new Dictionary<int, bool>();
        public Ukolnik()
        {
            InitializeComponent();

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5000/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            _comments = new List<Models.Comments>();
            _tasks = new List<Models.Tasks>();

            this.Hide();
        }
        private void LoggedUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (LogPanel.Visible == false)
            {
                LogPanel.Visible = true;
            }
            else
            {
                LogPanel.Visible = false;
            }
        }
        private void LogoutButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Visible = false;
        }

        private void Ukolnik_Load(object sender, EventArgs e)
        {
            EditTaskButton.Visible = false;
            try
            {
                HttpResponseMessage response = _httpClient.GetAsync("api/controller/getLoggedInUser").Result;

                if (response.IsSuccessStatusCode)
                {
                    string JsonContent = response.Content.ReadAsStringAsync().Result;
                    var user = JsonSerializer.Deserialize<Models.Users>(JsonContent);
                    if (user != null)
                    {
                        //MessageBox.Show($"Received JSON: {JsonContent}");
                        LoggedUser.Text = user.username;
                        loggedInUser = user.username;
                        if (!tasksLoaded)
                        {
                            LoadTasksAsync();
                            CommentsPanel.Controls.Clear();
                            tasksLoaded = true;
                        };
                    }
                    else
                    {
                        MessageBox.Show("User not found");
                    }
                }
                else
                {
                    MessageBox.Show("Failed to retrieve user data");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //create task ------------------------------------------------------------------
        private async void CreateTaskButton_Click(object sender, EventArgs e)
        {
            string name = TaskNameBox.Text;
            string description = TaskDescriptionBox.Text;
            DateTime? deadline = TaskDeadlineBox.Value;
            string creator = LoggedUser.Text;

            bool createSuccess = await CreateTaskAsync(name, description, deadline, creator);

            if (createSuccess)
            {
                //CreateTaskPanel.Visible = false;
            }
            else
            {
                MessageBox.Show("Task creation failed");
            }
        }

        public async Task<bool> CreateTaskAsync(string name, string description, DateTime? deadline, string creator)
        {
            try
            {
                var apiUrl = "http://localhost:5000/api/controller/createTask";

                var requestData = new
                {
                    name,
                    description,
                    deadline,
                    creator
                };

                var requestJson = JsonSerializer.Serialize(requestData);

                using (var httpClient = new HttpClient())
                {
                    var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        await LoadTasksAsync();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it or throw a custom exception)
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
        //Display tasks ------------------------------------------------------------------

        private async Task LoadTasksAsync()
        {
            try
            {
                HttpResponseMessage response = _httpClient.GetAsync("api/controller/getAllTasks").Result;

                if (response.IsSuccessStatusCode)
                {
                    string JsonContent = response.Content.ReadAsStringAsync().Result;
                    _tasks = JsonSerializer.Deserialize<List<Models.Tasks>>(JsonContent);
                    //MessageBox.Show($"Received JSON: {JsonContent}");
                    DisplayTasks();
                }
                else
                {
                    MessageBox.Show("Failed to retrieve tasks");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisplayTasks()
        {
            TaskDisplayPanel.Controls.Clear();

            int panelTop = 0;

            foreach (var task in _tasks)
            {
                isExpanded[task.id] = true;
                Panel taskPanel = ClonePanel(SingleTaskPanel);
                taskPanel.Location = new Point(0, panelTop);
                taskPanel.Tag = task.id;
                taskPanel.Height -= 200;

                Label taskNameLabel = taskPanel.Controls.Find("TaskNameLabel", true).FirstOrDefault() as Label;
                Label deadlineLabel = taskPanel.Controls.Find("DeadlineLabel", true).FirstOrDefault() as Label;
                Label creatorLabel = taskPanel.Controls.Find("CreatorLabel", true).FirstOrDefault() as Label;
                Label descriptionLabel = taskPanel.Controls.Find("DescriptionLabel", true).FirstOrDefault() as Label;

                if (taskNameLabel != null)
                {
                    taskNameLabel.Text = task.name;
                }
                if (deadlineLabel != null)
                {
                    deadlineLabel.Text = task.deadline.ToString();
                }
                if (creatorLabel != null)
                {
                    creatorLabel.Text = task.creator;
                }
                if (descriptionLabel != null)
                {
                    descriptionLabel.Text = task.description;
                    descriptionLabel.Visible = false;
                }


                if (taskPanel.Controls.Find("StatusComboBox", true).FirstOrDefault() is System.Windows.Forms.ComboBox comboBox)
                {
                    comboBox.Items.AddRange(new string[] { "New", "Urgent", "In Progress", "Done" });
                    if (task.status == null)
                    {
                        comboBox.SelectedItem = "New";
                    }
                    else
                    {
                        comboBox.SelectedItem = task.status;
                    }
                    comboBox.SelectedIndexChanged += StatusComboBox_SelectedIndexChanged;
                    taskPanel.Controls.Add(comboBox);
                }

                if (taskPanel.Controls.Find("ExpandTaskDisplay", true).FirstOrDefault() is LinkLabel extendTaskDisplay)
                {
                    //MessageBox.Show($"Task ID: {task.id} isExpanded: {isExpanded[task.id]}");
                    extendTaskDisplay.Name = "extendTaskDisplay_" + task.id;
                    extendTaskDisplay.LinkClicked += ExpandTaskDisplay_LinkClicked;
                    taskPanel.Controls.Add(extendTaskDisplay);
                }

                if (taskPanel.Controls.Find("EditThisTaskButton", true).FirstOrDefault() is System.Windows.Forms.Button editThisTaskButton)
                {
                    editThisTaskButton.Name = "editThisTaskButton_" + task.id;
                    editThisTaskButton.Click += EditThisTaskButton_Click;
                    taskPanel.Controls.Add(editThisTaskButton);
                }
                if (taskPanel.Controls.Find("DeleteTaskButton", true).FirstOrDefault() is System.Windows.Forms.Button deleteTaskButton)
                {
                    deleteTaskButton.Name = "deleteTaskButton_" + task.id;
                    deleteTaskButton.Click += DeleteTaskButton_Click;
                    deleteTaskButton.Tag = task.id;
                    taskPanel.Controls.Add(deleteTaskButton);
                }
                if (taskPanel.Controls.Find("AddCommentButton", true).FirstOrDefault() is System.Windows.Forms.Button addCommentButton)
                {
                    addCommentButton.Name = "addCommentButton_" + task.id;
                    addCommentButton.Click += AddCommentButton_Click;
                    addCommentButton.Tag = task.id;
                    taskPanel.Controls.Add(addCommentButton);
                }

                TaskDisplayPanel.Controls.Add(taskPanel);
                panelTop += taskPanel.Height + 25;
            }
            TaskDisplayPanel.Refresh();
        }

        private Panel ClonePanel(Panel originalPanel)
        {
            Panel clonedPanel = new Panel();
            clonedPanel.Size = originalPanel.Size;
            clonedPanel.BackColor = originalPanel.BackColor;
            clonedPanel.BorderStyle = originalPanel.BorderStyle;

            foreach (Control control in originalPanel.Controls)
            {
                Control clonedControl = CloneControl(control);
                clonedPanel.Controls.Add(clonedControl);
            }

            return clonedPanel;
        }

        private Control CloneControl(Control originalControl)
        {
            Control clonedControl = (Control)Activator.CreateInstance(originalControl.GetType());

            clonedControl.Size = originalControl.Size;
            clonedControl.Location = originalControl.Location;
            clonedControl.BackColor = originalControl.BackColor;
            clonedControl.ForeColor = originalControl.ForeColor;
            clonedControl.Font = originalControl.Font;
            clonedControl.Text = originalControl.Text;
            clonedControl.Name = originalControl.Name;
            clonedControl.Enabled = originalControl.Enabled;
            clonedControl.Visible = originalControl.Visible;
            clonedControl.Anchor = originalControl.Anchor;
            clonedControl.Dock = originalControl.Dock;

            // Handle child controls (recursively)
            foreach (Control childControl in originalControl.Controls)
            {
                Control clonedChildControl = CloneControl(childControl);
                clonedControl.Controls.Add(clonedChildControl);
            }

            return clonedControl;
        }

        //i dont know why this is here but im too afraid to delete it
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void ExpandTaskDisplay_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //MessageBox.Show("Expand task display");
            LinkLabel clickedLinkLabel = sender as LinkLabel;

            if (clickedLinkLabel != null)
            {
                string taskIdStr = clickedLinkLabel.Name;
                string[] taskIdParts = taskIdStr.Split('_');

                if (taskIdParts.Length >= 2)
                {
                    int taskId;

                    if (int.TryParse(taskIdParts[1], out taskId))
                    {
                        isExpanded[taskId] = !isExpanded[taskId];
                        //commentTaskId = taskId;
                        List<Models.Comments> comments = await GetAllComments();
                        _comments.Clear();
                        _comments = comments;
                        Panel taskPanel = clickedLinkLabel.Parent as Panel;
                        Label descriptionLabel = taskPanel.Controls.Find("DescriptionLabel", true).FirstOrDefault() as Label;
                        int descriptionHeight = 200;

                        //MessageBox.Show($"Expand task display for Task ID: {taskId}");

                        if (taskPanel != null)
                        {
                            if (!isExpanded[taskId])
                            {
                                clickedLinkLabel.Text = "Click To Collapse";
                                descriptionLabel.Visible = true;
                                taskPanel.Height += descriptionHeight;

                                commentTaskId = taskId;
                                //MessageBox.Show($"Task ID: {_comments}");
                                CloneComments();
                            }
                            else
                            {
                                clickedLinkLabel.Text = "Click To Expand";
                                descriptionLabel.Visible = false;
                                taskPanel.Height -= descriptionHeight;
                                CommentsPanel.Controls.Clear();
                            }
                            taskPanel.Invalidate();
                        }
                        else
                        {
                            MessageBox.Show("Task panel not found");
                        }
                    }
                    else
                    {
                        MessageBox.Show("failed to parse");
                    }
                }
                else
                {
                    MessageBox.Show("no 2 parts");
                }


            }
        }

        private async void StatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox comboBox = sender as System.Windows.Forms.ComboBox;
            Panel panel = comboBox.Parent as Panel;

            if (comboBox.SelectedIndex >= 0)
            {
                int taskId = (int)panel.Tag;
                //MessageBox.Show($"{(int)panel.Tag}");
                string selectedStatus = comboBox.SelectedItem.ToString();

                bool updateSuccess = await UpdateTaskAsync(taskId, selectedStatus);

                if (updateSuccess)
                {
                    //MessageBox.Show("Task updated");
                    LoadTasksAsync();
                }
                else
                {
                    MessageBox.Show($"Task update failed");
                }
            }
        }

        public async Task<bool> UpdateTaskAsync(int taskId, string status)
        {
            try
            {
                var apiUrl = "http://localhost:5000/api/controller/updateTask";

                var requestData = new
                {
                    taskId,
                    status
                };
                //MessageBox.Show($"Task ID: {taskId} Status: {status}");
                var requestJson = JsonSerializer.Serialize(requestData);

                using (var httpClient = new HttpClient())
                {
                    var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        await LoadTasksAsync();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it or throw a custom exception)
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }


        //update task ------------------------------------------------------------------
        private async void EditTaskButton_Click(object sender, EventArgs e)
        {
            int id = editTaskId;
            string name = TaskNameBox.Text;
            string description = TaskDescriptionBox.Text;
            DateTime? deadline = TaskDeadlineBox.Value;

            bool updateSuccess = await EditTaskAsync(id, name, description, deadline);

            if (updateSuccess)
            {
                //CreateTaskPanel.Visible = false;
                TaskNameBox.Text = "";
                TaskDescriptionBox.Text = "";
                TaskDeadlineBox.Value = DateTime.Now;
                EditTaskButton.Visible = false;
            }
            else
            {
                MessageBox.Show("Task edit failed");
            }
        }
        public async Task<bool> EditTaskAsync(int taskid, string name, string description, DateTime? deadline)
        {
            try
            {
                var apiUrl = "http://localhost:5000/api/controller/editTask";

                var requestData = new
                {
                    taskid,
                    name,
                    description,
                    deadline
                };

                var requestJson = JsonSerializer.Serialize(requestData);

                using (var httpClient = new HttpClient())
                {
                    var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        await LoadTasksAsync();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it or throw a custom exception)
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        private void EditThisTaskButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = sender as System.Windows.Forms.Button;
            Panel panel = button.Parent as Panel;

            if (panel != null)
            {
                Label creatorLabel = panel.Controls.Find("CreatorLabel", true).FirstOrDefault() as Label;
                if (creatorLabel.Text == loggedInUser)
                {
                    int taskId = (int)panel.Tag;
                    editTaskId = taskId;
                    //MessageBox.Show($"{(int)panel.Tag}");
                    Models.Tasks task = _tasks.Find(x => x.id == taskId);

                    TaskNameBox.Text = task.name;
                    TaskDescriptionBox.Text = task.description;
                    TaskDeadlineBox.Value = (DateTime)task.deadline;

                    EditTaskButton.Visible = true;
                }
                else
                {
                    MessageBox.Show("You can only delete tasks you created");
                }

            }
            else
            {
                MessageBox.Show("Task panel not found");
            }
        }

        private async void DeleteTaskButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = sender as System.Windows.Forms.Button;
            Panel panel = button.Parent as Panel;

            if (panel != null)
            {
                if (panel.Tag is int taskId)
                {
                    Label creatorLabel = panel.Controls.Find("CreatorLabel", true).FirstOrDefault() as Label;
                    if (creatorLabel.Text == loggedInUser)
                    {
                        bool deleteSuccess = await DeleteTaskAsync(taskId);

                        if (deleteSuccess)
                        {
                            //MessageBox.Show("Task deleted");
                        }
                        else
                        {
                            MessageBox.Show($"Task deletion failed");
                        }
                    }
                    else
                    {
                        MessageBox.Show("You can only delete tasks you created");
                    }
                }
                else
                {
                    MessageBox.Show("Task ID not found");
                }
            }
            else
            {
                MessageBox.Show("Task panel not found");
            }
        }

        public async Task<bool> DeleteTaskAsync(int taskId)
        {
            try
            {
                string apiUrl = "http://localhost:5000/api/controller/deleteTask";
                //MessageBox.Show($"Task ID: {taskId}");
                var requestData = new
                {
                    taskId
                };

                var requestJson = JsonSerializer.Serialize(requestData);

                using (HttpClient httpClient = new HttpClient())
                {
                    var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                    // Send an HTTP POST request with the task ID in the request body
                    HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Task deletion was successful
                        await LoadTasksAsync(); // Reload the task list
                        return true;
                    }
                    else
                    {
                        // Task deletion failed
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., network error, API unavailable, etc.)
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        //get all comments ------------------------------------------------------------------
        private Panel CloneComments()
        {
            Panel clonedPanel = new Panel();
            CommentsPanel.Controls.Clear();
            clonedPanel.Size = CommentsPanel.Size;
            clonedPanel.BackColor = CommentsPanel.BackColor;
            clonedPanel.BorderStyle = CommentsPanel.BorderStyle;
            int top = 0;

            // Filter comments based on the taskId
            //int taskId = commentTaskId; // Replace with the actual task ID

            // Filter comments for the specified task ID
            List<Models.Comments> taskComments = _comments
                .Where(comment => comment.taskId == commentTaskId)
                .ToList();

            // Clear the existing content of CommentsPanel
            CommentsPanel.Controls.Clear();

            foreach (var comment in taskComments)
            {
                Panel commentPanel = ClonePanel(SingleCommentPanel);
                commentPanel.Location = new Point(0, top);

                // Populate the labels in the cloned comment panel with comment data
                Label commentNameLabel = commentPanel.Controls.Find("commentName", true).FirstOrDefault() as Label;
                Label commentTextLabel = commentPanel.Controls.Find("CommentText", true).FirstOrDefault() as Label;
                Label commentCreatedTimeLabel = commentPanel.Controls.Find("CommentCreatedTime", true).FirstOrDefault() as Label;
                Label commentCreatorLabel = commentPanel.Controls.Find("CommentCreator", true).FirstOrDefault() as Label;

                if (commentNameLabel != null)
                {
                    commentNameLabel.Text = comment.name; // Replace with the actual property name in your Comment model
                }
                if (commentTextLabel != null)
                {
                    commentTextLabel.Text = comment.text;
                }
                if (commentCreatedTimeLabel != null)
                {
                    commentCreatedTimeLabel.Text = comment.created.ToString();
                }
                if (commentCreatorLabel != null)
                {
                    commentCreatorLabel.Text = comment.creator;
                }

                if (commentPanel.Controls.Find("DeleteComment", true).FirstOrDefault() is System.Windows.Forms.Button deleteCommentButton)
                {
                    deleteCommentButton.Name = "deleteCommentButton_" + comment.id;
                    deleteCommentButton.Click += DeleteComment_Click;
                    deleteCommentButton.Tag = comment.id;
                    commentPanel.Controls.Add(deleteCommentButton);
                }

                // Add the cloned comment panel to CommentsPanel
                CommentsPanel.Controls.Add(commentPanel);

                // Update the top position for the next comment panel
                top += commentPanel.Height + 10; // Adjust as needed for spacing
            }

            return clonedPanel;
        }


        private async Task<List<Models.Comments>> GetAllComments()
        {
            try
            {
                string apiUrl = "http://localhost:5000/api/controller/getAllComments"; // API endpoint without taskId in the URL


                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string JsonContent = response.Content.ReadAsStringAsync().Result;
                    var comments = JsonSerializer.Deserialize<List<Models.Comments>>(JsonContent);
                    //MessageBox.Show($"Received JSON: {JsonContent}");
                    return comments;
                }
                else
                {
                    MessageBox.Show("Failed to retrieve comments");
                    return new List<Models.Comments>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                return new List<Models.Comments>();
            }
        }




        //create comment ------------------------------------------------------------------

        private void AddCommentButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = sender as System.Windows.Forms.Button;
            Panel panel = button.Parent as Panel;

            if (panel != null)
            {
                commentTaskId = (int)panel.Tag;
                //MessageBox.Show($"{commentTaskId}");
                CreateTaskButton.Visible = false;
                TaskDeadlineBox.Visible = false;
                creationdeadline.Visible = false;
                CreateCommentButton.Visible = true;
            }
            else
            {
                MessageBox.Show("Task panel not found");
            }
        }

        private void CreateCommentButton_Click(object sender, EventArgs e)
        {
            try
            {
                string apiUrl = "http://localhost:5000/api/controller/createComment";

                string name = TaskNameBox.Text;
                string text = TaskDescriptionBox.Text;
                DateTime? created = DateTime.Now;
                string creator = LoggedUser.Text;
                int taskId = commentTaskId;

                //MessageBox.Show($"Task ID: {taskId}");

                TaskNameBox.Text = "";
                TaskDescriptionBox.Text = "";

                var requestData = new
                {
                    name,
                    text,
                    created,
                    creator,
                    taskId
                };

                var requestJson = JsonSerializer.Serialize(requestData);

                using (var httpClient = new HttpClient())
                {
                    var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                    var response = httpClient.PostAsync(apiUrl, content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        //MessageBox.Show("Comment created");
                        CreateTaskButton.Visible = true;
                        TaskDeadlineBox.Visible = true;
                        CreateCommentButton.Visible = false;
                        LoadTasksAsync();
                        GetAllComments();
                    }
                    else
                    {
                        MessageBox.Show("Comment creation failed");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void DeleteComment_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = sender as System.Windows.Forms.Button;
            Panel panel = button.Parent as Panel;

            if (panel != null)
            {
                if (button.Tag is int commentId)
                {
                    Label creatorLabel = panel.Controls.Find("CommentCreator", true).FirstOrDefault() as Label;
                    if (creatorLabel.Text == loggedInUser)
                    {
                        bool deleteSuccess = await DeleteCommentAsync(commentId);

                        if (deleteSuccess)
                        {
                            //MessageBox.Show("Comment deleted");
                            commentTaskId = commentId;
                            CloneComments();
                            LoadTasksAsync();

                        }
                        else
                        {
                            MessageBox.Show($"Comment deletion failed");
                        }
                    }
                    else
                    {
                        MessageBox.Show("You can only delete comments you created");
                    }
                }
                else
                {
                    MessageBox.Show("Comment ID not found");
                }
            }
            else
            {
                MessageBox.Show("Comment panel not found");
            }
        }

        public async Task<bool> DeleteCommentAsync(int commentId)
        {
            try
            {
                string apiUrl = "http://localhost:5000/api/controller/deleteComment";
                var requestData = new
                {
                    commentId
                };

                var requestJson = JsonSerializer.Serialize(requestData);

                using (HttpClient httpClient = new HttpClient())
                {
                    var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        await LoadTasksAsync();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        private void Exit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CloseApplication();
        }
        private void CloseApplication()
        {
            Process[] processes = Process.GetProcessesByName("UkolnikBackend");

            if (processes.Length > 0)
            {
                foreach (Process process in processes)
                {
                    process.Kill();
                }
            }


            Application.Exit();
        }
    }
}

