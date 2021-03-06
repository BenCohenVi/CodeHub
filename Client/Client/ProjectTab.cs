﻿using System;using System.Collections.Generic;using System.ComponentModel;using System.Drawing;using System.Data;using System.Linq;using System.Text;using System.Threading;using System.Threading.Tasks;using System.Windows.Forms;using System.IO;using System.Diagnostics;namespace Client{    public partial class ProjectTab : UserControl    {        private ClientSocket cSock;        private string Projects;        private string File;
        private string[] text_extensions = {"html","xml","css","svg","json",
        "c","cpp","h","cs","js","py","java","rb","pl","php","sh",
        "txt","tex","markdown","asciidoc","rtf","ps","ini","cfg","rc","reg","csv","tsv", "png"};        public ProjectTab()        {            InitializeComponent();            foreach (Control Item in this.Controls)            {                bunifuTransition1.ShowSync(Item);                Application.DoEvents();            }            errorMessage1.Visible = false;            successMessage1.Visible = false;
            versionList.Items.Clear();
        }        public string Fix_Format(string project)        {            project = project.Replace("[", "").Replace("]", "").Replace("(", "").Replace(")", "").Replace("',", "").Replace("u'", "").Replace(" ", "").Replace("'", "");            return project;        }        public string Get_Latest()        {            if (projectList.SelectedIndex > -1)            {                return projectList.SelectedItem.ToString();            }            else            {                return "None";            }        }        public void Set_Table()        {
            foreach (string proName in this.Projects.Split(','))            {                projectList.Items.Add(proName);            }        }        public void Refresh_Table()        {            this.Projects = this.cSock.Get_Projects_New();            this.Projects = this.Fix_Format(this.Projects);            projectList.Items.Clear();            versionList.Items.Clear();            this.Set_Table();        }        public void SetSocket(ClientSocket cliSock)        {            this.cSock = cliSock;            this.Projects = this.cSock.Get_Projects();            this.Projects = this.Fix_Format(this.Projects);            this.Set_Table();        }        private void NewForm_FormClosed(object sender, FormClosedEventArgs e)        {            Refresh_Table();        }        private int Get_lastVersion()        {            int lastVersion = 0;            for (int i = 0; i < versionList.Items.Count; i++)            {                if (!versionList.Items[i].ToString().Contains("."))                {                    if (Convert.ToInt32(versionList.Items[i].ToString()) > lastVersion)                    {                        lastVersion = Convert.ToInt32(versionList.Items[i].ToString());                    }                }            }            return lastVersion;        }        private string Get_lastBranch(string mainVer)        {            string lastBranch = mainVer + ".1";            int branchVersion = 0;            for (int i = 0; i < versionList.Items.Count; i++)            {                if (versionList.Items[i].ToString().Contains("."))                {                    if (versionList.Items[i].ToString().Split('.')[0] == mainVer)                    {                        branchVersion++;                    }                }            }            lastBranch = mainVer + "." + branchVersion.ToString();            return lastBranch;        }        private void projectList_SelectedIndexChanged(object sender, EventArgs e)
        /* Updating the version list.         *          * When a selected project is changed in the project list,         * the function updates the version list to show the selected project versions.         */
        {            versionList.Items.Clear();            if (projectList.SelectedIndex > -1)
            {
                int Versions = Convert.ToInt32(this.cSock.Get_Versions(projectList.SelectedItem.ToString()));
                string branches = this.cSock.Get_Branches(projectList.SelectedItem.ToString());
                if (branches.Contains('_'))
                {
                    int branchIndex = 0;
                    string temp;
                    for (int i = 0; i < Versions; i++)
                    {
                        temp = branches.Split(',')[branchIndex];
                        if ((i + 1) == Convert.ToInt32(temp.Split('_')[0]))
                        {
                            versionList.Items.Add((i + 1).ToString());
                            for (int x = 0; x < Convert.ToInt32(branches.Split(',')[branchIndex].Split('_')[1]); x++)
                            {
                                versionList.Items.Add("   " + ((i + 1) + "." + (+x + 1).ToString()));
                            }
                            branchIndex++;
                        }
                        else
                        {
                            versionList.Items.Add((i + 1).ToString());
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < Versions; i++)
                    {
                        versionList.Items.Add((i + 1).ToString());
                    }
                }
            }
        }        private void newProjectBtn_Click(object sender, EventArgs e)        {            NewProjectForm NewForm = new NewProjectForm(this.cSock);            NewForm.FormClosed += NewForm_FormClosed;            NewForm.Show();        }        private void uploadBtn_Click(object sender, EventArgs e)        /* Updating a version button click.         *          * The function checks the selected version from the version list,         * and acts accordingly (weather a branch is selected or a version).         */        {
            try            {                bool Done = true;
                if (versionList.SelectedIndex > -1 && versionList.SelectedItem.ToString().Contains("."))                {                    DialogResult result = openFileDialogU.ShowDialog();                    if (result == DialogResult.OK)                    {                        string ver = versionList.SelectedItem.ToString().Split('.')[0];                        string lastBranch = Get_lastBranch(ver);                        if (lastBranch == versionList.SelectedItem.ToString())                        {
                            this.File = openFileDialogU.FileName;                            string fileInfo = this.File.Split('.')[this.File.Split('.').Length - 1];                            string project = projectList.GetItemText(projectList.SelectedItem);
                            bool valiable = false;
                            foreach (string ext in this.text_extensions)
                            {
                                if (fileInfo == ext)
                                {
                                    valiable = true;
                                    break;
                                }
                            }
                            if (!valiable)
                            {
                                successMessage1.Visible = false;
                                errorMessage1.Set_Message("File Type Not Supported");
                                errorMessage1.Visible = true;
                                successMessage1.BringToFront();
                                return;
                            }
                            LoadingForm.ShowLoadingScreen();                            this.cSock.Manage_Branch(projectList.SelectedItem.ToString(), this.File, fileInfo, lastBranch.Replace(" ", string.Empty));    //Sending File To Server Method
                        }                        else                        {                            successMessage1.Visible = false;                            errorMessage1.Set_Message("Newer Version Available");                            errorMessage1.Visible = true;                            successMessage1.BringToFront();                            Done = false;
                        }                    }                }                else                {                    DialogResult result = openFileDialogU.ShowDialog();                    if (result == DialogResult.OK && projectList.SelectedIndex > -1)                    {
                        this.File = openFileDialogU.FileName;                        string fileInfo = this.File.Split('.')[this.File.Split('.').Length - 1];                        string project = projectList.GetItemText(projectList.SelectedItem);                        int lastVersion = Get_lastVersion();                        if (versionList.SelectedItem.ToString() == lastVersion.ToString())                        {
                            bool valiable = false;
                            foreach (string ext in this.text_extensions)
                            {
                                if (fileInfo == ext)
                                {
                                    valiable = true;
                                    break;
                                }
                            }
                            if (!valiable)
                            {
                                successMessage1.Visible = false;
                                errorMessage1.Set_Message("File Type Not Supported");
                                errorMessage1.Visible = true;
                                successMessage1.BringToFront();
                                return;
                            }
                            LoadingForm.ShowLoadingScreen();                            this.cSock.Update_Project(projectList.SelectedItem.ToString(), this.File, fileInfo);    //Sending File To Server Method
                        }                        else                        {                            LoadingForm.CloseForm();                            successMessage1.Visible = false;                            errorMessage1.Set_Message("Newer Version Available");                            errorMessage1.Visible = true;                            successMessage1.BringToFront();                            Done = false;
                        }                    }                }                if (Done)                {
                    LoadingForm.CloseForm();                    errorMessage1.Visible = false;                    successMessage1.Set_Message("Project Updated!");                    successMessage1.Visible = true;                    successMessage1.BringToFront();                    projectList_SelectedIndexChanged(null, null);
                }            }            catch { }        }        private void downloadBtn_Click(object sender, EventArgs e)        {            try            {                DialogResult result = folderBrowserDialogU.ShowDialog();                if (result == DialogResult.OK && versionList.SelectedIndex > -1)                {
                    string path = folderBrowserDialogU.SelectedPath;                    string data = this.cSock.Download_Project(projectList.SelectedItem.ToString(), versionList.SelectedItem.ToString());                    string content = data.Split(new[] { "`~`" }, StringSplitOptions.None)[0];                    string extension = data.Split(new[] { "`~`" }, StringSplitOptions.None)[1];                    extension = extension.Replace("\0", string.Empty);                    if (extension != "png")                    {                    string filePath = path.Replace("\0", string.Empty) + "\\" + projectList.SelectedItem.ToString().Replace("\0", string.Empty) + "_" + versionList.SelectedItem.ToString().Replace("\0", string.Empty).Replace(".", "_").Replace(" ", "") + "." + extension.Replace("\0", string.Empty);                        StreamWriter NewFile = new StreamWriter(filePath);                        NewFile.Write(content);                        NewFile.Close();                    }                    else                    {                        string filePath = path.Replace("\0", string.Empty) + "\\" + projectList.SelectedItem.ToString().Replace("\0", string.Empty) + "_" + versionList.SelectedItem.ToString().Replace(".", "_").Replace(" ", "").Replace("\0", string.Empty) + "."+ extension.Replace("\0", string.Empty);                        System.IO.File.WriteAllBytes(filePath, Convert.FromBase64String(content));                    }
                    errorMessage1.Visible = false;                    successMessage1.Set_Message("Download Completed!");                    successMessage1.Visible = true;                    successMessage1.BringToFront();                }            }            catch            {                successMessage1.Visible = false;                errorMessage1.Set_Message("Download Error");                errorMessage1.Visible = true;                successMessage1.BringToFront();            }        }        private void branchBtn_Click(object sender, EventArgs e)        {
            try            {
                DialogResult result = openFileDialogU.ShowDialog();                if (result == DialogResult.OK && projectList.SelectedIndex > -1 && versionList.SelectedIndex > -1)                {                    int index = projectList.SelectedIndex;                    this.File = openFileDialogU.FileName;                    string fileInfo = this.File.Split('.')[this.File.Split('.').Length - 1];                    string project = projectList.GetItemText(projectList.SelectedItem);
                    bool valiable = false;
                    foreach (string ext in this.text_extensions)
                    {
                        if (fileInfo == ext)
                        {
                            valiable = true;
                            break;
                        }
                    }
                    if (!valiable)
                    {
                        successMessage1.Visible = false;
                        errorMessage1.Set_Message("File Type Not Supported");
                        errorMessage1.Visible = true;
                        successMessage1.BringToFront();
                        return;
                    }
                    LoadingForm.ShowLoadingScreen();                    this.cSock.Manage_Branch(projectList.SelectedItem.ToString(), this.File, fileInfo, versionList.SelectedItem.ToString());                    int branchVer = Convert.ToInt32(versionList.SelectedItem.ToString());                    int Versions = Convert.ToInt32(this.cSock.Get_Versions(projectList.SelectedItem.ToString()));                    versionList.Items.Clear();                    for (int i = 0; i < Versions; i++)                    {                        versionList.Items.Add((i + 1).ToString());                        if (i + 1 == branchVer)                            versionList.Items.Add(i + 1 + ".1");                    }
                    LoadingForm.CloseForm();                }
                errorMessage1.Visible = false;                successMessage1.Set_Message("Branch Created!");                successMessage1.Visible = true;                successMessage1.BringToFront();                projectList_SelectedIndexChanged(null, null);
            }            catch (FieldAccessException)            {                successMessage1.Visible = false;                errorMessage1.Set_Message("File Is Too Big");                errorMessage1.Visible = true;                successMessage1.BringToFront();
            }        }        private void deleteProjectBtn_Click(object sender, EventArgs e)        {            if (projectList.SelectedIndex > -1)            {                string proName = projectList.SelectedItem.ToString();                this.cSock.Delete_Project(proName);                Refresh_Table();                versionList.Items.Clear();                errorMessage1.Visible = false;                successMessage1.Set_Message("Project Deleted!");                successMessage1.Visible = true;                successMessage1.BringToFront();            }            else            {                successMessage1.Visible = false;                errorMessage1.Set_Message("Select A Project To Delete First");                errorMessage1.Visible = true;                successMessage1.BringToFront();            }        }

        private void reloadBtn_Click(object sender, EventArgs e)
        {
            this.projectList.Items.Clear();
            this.versionList.Items.Clear();
            this.Projects = this.cSock.Get_Projects_New();            this.Projects = this.Fix_Format(this.Projects);            this.Set_Table();
        }
    }}