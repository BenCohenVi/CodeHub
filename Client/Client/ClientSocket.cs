using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace Client
{
    public class ClientSocket
    {
        //Contains all the functions that sends commends to the server.
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        private string ip;
        private int port;
        private string projects;
        public ClientSocket(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
            this.clientSocket.Connect(this.ip, this.port);
        }


        public bool Try_Login(string username, string password)
        /* Trying to login into a user.
         * 
         * This function sends the server a username and password,
         * and returns the bool answer that the server responded (True if valid, False if not).
         */
        {
            NetworkStream serverStream = clientSocket.GetStream();

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("Login");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);

            outStream = System.Text.Encoding.ASCII.GetBytes(username.Replace("\0", string.Empty) + "," + password.Replace("\0", string.Empty));
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);

            return Convert.ToBoolean(System.Text.Encoding.ASCII.GetString(inStream));
        }

        public void Register(string username, string password)
        /* Register a new user to the system.
         * 
         * The function sends the server a username and password to register.
         */
        {
            NetworkStream serverStream = clientSocket.GetStream();

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("Register");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);

            outStream = System.Text.Encoding.ASCII.GetBytes(username.Replace("\0", string.Empty) + "," + password.Replace("\0", string.Empty));
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);
            
            if (System.Text.Encoding.ASCII.GetString(inStream).Replace("\0", string.Empty) == "NO")
            {
                throw new System.Exception();
            }
        }

        public string Get_Projects()
        /* Getting the project of a user that just logged in.
         * 
         * The function requests the projects from the server,
         * the server sends the information and the function returns it.
         */
        {
            NetworkStream serverStream = clientSocket.GetStream();

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("Start");
            serverStream.Write(outStream, 0, outStream.Length);

            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);
            this.projects = System.Text.Encoding.ASCII.GetString(inStream);

            return this.projects.Replace(" ", "") ;
        }

        public string Get_Projects_New()
        /* Getting the project of a user that is already logged in.
         * 
         * The function requests the projects from the server,
         * the server sends the information and the function returns it.
         */
        {
            NetworkStream serverStream = clientSocket.GetStream();
                byte[] outStream = System.Text.Encoding.ASCII.GetBytes("Projects.");
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();

                byte[] inStream = new byte[10025];
                serverStream.Read(inStream, 0, inStream.Length);

                outStream = System.Text.Encoding.ASCII.GetBytes("Get");
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();

                inStream = new byte[10025];
                serverStream.Read(inStream, 0, inStream.Length);

                return System.Text.Encoding.ASCII.GetString(inStream);
            
        }

        public string Get_Versions(string proName)
        /* Getting the last version of a project.
         * 
         * The function sends a project name to the server,
         * the server sends the latest version back and the function returns it.
         */
        {
            NetworkStream serverStream = clientSocket.GetStream();

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("Versions.");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);

            outStream = System.Text.Encoding.ASCII.GetBytes(proName.Replace("\0", string.Empty));
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);

            return returndata.Replace("\0", string.Empty).Replace("[(", string.Empty).Replace(",)]", string.Empty);
        }

        public string Get_Branches(string proName)
        /* Getting the branches in a project.
         * 
         * The function sends a project name to the server,
         * the server sends the project branches back and the function returns it.
         */
        {
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("Branches.");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);

            outStream = System.Text.Encoding.ASCII.GetBytes(proName.Replace("\0", string.Empty));
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);

            return System.Text.Encoding.ASCII.GetString(inStream);
        }

        public string New_Project(string data, string fileInfo)
        /* Creating a new project.
         * 
         * The function sends the project name, and the first version information to the server,
         * if the server sends back that something wrong act accordingly (for example if the project name is taken).
         */
        {
            NetworkStream serverStream = clientSocket.GetStream();

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("New.");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);

            FileInfo file = new FileInfo(data);
            string lenghtf = file.Length.ToString();
            outStream = System.Text.Encoding.ASCII.GetBytes(lenghtf);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);

            outStream = System.Text.Encoding.ASCII.GetBytes(fileInfo.Replace("\0", string.Empty));
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();


            inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);

            if (System.Text.Encoding.ASCII.GetString(inStream).Replace("\0", string.Empty) == "NO")
            {
                throw new System.DivideByZeroException();
            }

            if (fileInfo.Split('.')[fileInfo.Split(',').Length] != "png")
            {
                using (FileStream fs = File.Open(data, FileMode.Open))
                {
                    byte[] b = new byte[1024];
                    UTF8Encoding temp = new UTF8Encoding(true);
                    while (fs.Read(b, 0, b.Length) > 0)
                    {
                        outStream = System.Text.Encoding.ASCII.GetBytes(temp.GetString(b));
                        serverStream.Write(outStream, 0, outStream.Length);
                        serverStream.Flush();
                    }

                }
            }
            else
            {
                using (var fileStream = File.OpenRead(data))
                {
                    fileStream.CopyTo(serverStream);
                }
            }

            inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);


            return returndata;
        }

        public void Delete_Project(string projectName)
        /* Deleting a project.
         * 
         * The function sends a project name to the server,
         * the server delets the project.
         */
        {
            NetworkStream serverStream = clientSocket.GetStream();

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("Delete.");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);

            outStream = System.Text.Encoding.ASCII.GetBytes(projectName.Replace("\0", string.Empty));
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);
        }

        public string Download_Project(string project, string version)
        /* Downloading a version in a project.
         * 
         * The function sends a project and a version in that project to the server,
         * the server sends the version infomration (content and type),
         * the function returns this information.
         */
        {
            NetworkStream serverStream = clientSocket.GetStream();

            byte[] OutStream = System.Text.Encoding.ASCII.GetBytes("Download.");
            serverStream.Write(OutStream, 0, OutStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);

            OutStream = System.Text.Encoding.ASCII.GetBytes(project.Replace("\0", string.Empty) + "," + version.Replace("\0", string.Empty));
            serverStream.Write(OutStream, 0, OutStream.Length);
            serverStream.Flush();

            inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);
            string fileBuffSize = System.Text.Encoding.ASCII.GetString(inStream);

            OutStream = System.Text.Encoding.ASCII.GetBytes("OK");
            serverStream.Write(OutStream, 0, OutStream.Length);
            serverStream.Flush();

            
            inStream = new byte[Convert.ToInt32(fileBuffSize) + 100];
            int bytesRead = serverStream.Read(inStream, 0, inStream.Length);
            string filedata = System.Text.Encoding.ASCII.GetString(inStream, 0, bytesRead);

            OutStream = System.Text.Encoding.ASCII.GetBytes("OK");
            serverStream.Write(OutStream, 0, OutStream.Length);
            serverStream.Flush();

            return filedata;
        }

        public void Share_Project(string projectName, string projectVersions, string username)
        /* Sharing a project with a user.
         * 
         * The function sends a project name, its latest version, and a username to the server,
         * the servers then shares the project with the user sent,
         * if there is a problem the function acts accordingly (for example if user doesn't exists).
         */
        {
            NetworkStream serverStream = clientSocket.GetStream();

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("Share.");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);


            outStream = System.Text.Encoding.ASCII.GetBytes(projectName.Replace("\0", string.Empty) + "^" + projectVersions.Replace("\0", string.Empty) + "^" + username.Replace("\0", string.Empty));
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);

            string returnValue = System.Text.Encoding.ASCII.GetString(inStream).Replace("\0", string.Empty);

            if (returnValue == "NO")
            {
                throw new System.DivideByZeroException();
            }

            else if (returnValue == "NO1")
            {
                throw new System.DataMisalignedException();
            }

            else if (returnValue == "NO2")
            {
                throw new System.DllNotFoundException();
            }

            else if (returnValue == "NO3")
            {
                throw new System.IndexOutOfRangeException();
            }
        }

        public void Update_Project(string project, string data, string fileInfo)
        /* Updating a non-branch version.
         * 
         * The function sends a project and the new version information to server,
         * the server then saves the new version.
         */
        {
            NetworkStream serverStream = clientSocket.GetStream();

            byte[] OutStream = System.Text.Encoding.ASCII.GetBytes("Update.");
            serverStream.Write(OutStream, 0, OutStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);

            OutStream = System.Text.Encoding.ASCII.GetBytes(project.Replace("\0", string.Empty));
            serverStream.Write(OutStream, 0, OutStream.Length);
            serverStream.Flush();

            inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);


            FileInfo file = new FileInfo(data);
            string lenghtf = file.Length.ToString();
            OutStream = System.Text.Encoding.ASCII.GetBytes(lenghtf);
            serverStream.Write(OutStream, 0, OutStream.Length);
            serverStream.Flush();

            inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);

            OutStream = System.Text.Encoding.ASCII.GetBytes(fileInfo.Replace("\0", string.Empty));
            serverStream.Write(OutStream, 0, OutStream.Length);
            serverStream.Flush();

            inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);

            if (fileInfo != "png")
            {
                using (FileStream fs = File.Open(data, FileMode.Open))
                {
                    byte[] b = new byte[1024];
                    UTF8Encoding temp = new UTF8Encoding(true);
                    while (fs.Read(b, 0, b.Length) > 0)
                    {
                        OutStream = System.Text.Encoding.ASCII.GetBytes(temp.GetString(b));
                        serverStream.Write(OutStream, 0, OutStream.Length);
                        serverStream.Flush();
                    }

                }
            }
            else
            {
                using (var fileStream = File.OpenRead(data))
                {
                    fileStream.CopyTo(serverStream);
                }
            }

            inStream = new byte[1025];
            serverStream.Read(inStream, 0, inStream.Length);
        }



        public void Manage_Branch(string project, string fileP, string fileInfo, string version)
        /* Creating a new branch/Updating branch.
         * 
         * This function send the server an  update/create command according to the request,
         * then it sends the project and the branch information to the server to save.
         */
        {
            NetworkStream serverStream = clientSocket.GetStream();

            byte[] OutStream = new byte[10025];
            byte[] inStream = new byte[10025];

            if (version.Contains('.'))
            {
                OutStream = System.Text.Encoding.ASCII.GetBytes("BranchU.");
            }
            else
            {
                OutStream = System.Text.Encoding.ASCII.GetBytes("Branch.");
            }
            serverStream.Write(OutStream, 0, OutStream.Length);
            serverStream.Flush();

            serverStream.Read(inStream, 0, inStream.Length);

            FileInfo file = new FileInfo(fileP);
            string lenghtf = file.Length.ToString();
            OutStream = System.Text.Encoding.ASCII.GetBytes(lenghtf.Replace("\0", string.Empty));
            serverStream.Write(OutStream, 0, OutStream.Length);
            serverStream.Flush();

            inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);


            OutStream = System.Text.Encoding.ASCII.GetBytes(project.Replace("\0", string.Empty) + "^"+version.Replace("\0", string.Empty));
            serverStream.Write(OutStream, 0, OutStream.Length);
            serverStream.Flush();

            inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);

            OutStream = System.Text.Encoding.ASCII.GetBytes(fileInfo.Replace("\0", string.Empty));
            serverStream.Write(OutStream, 0, OutStream.Length);
            serverStream.Flush();

            inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);
            if (fileInfo != "png")
            {
                using (FileStream fs = File.Open(fileP, FileMode.Open))
                {
                    byte[] b = new byte[1024];
                    UTF8Encoding temp = new UTF8Encoding(true);
                    while (fs.Read(b, 0, b.Length) > 0)
                    {
                        OutStream = System.Text.Encoding.ASCII.GetBytes(temp.GetString(b));
                        serverStream.Write(OutStream, 0, OutStream.Length);
                        serverStream.Flush();
                    }

                }
            }
            else
            {
                using (var fileStream = File.OpenRead(fileP))
                {
                    fileStream.CopyTo(serverStream);
                }
            }

            inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);

        }

        public string Get_Preview(string proName, string version)
        /* Getting a preview of a selected version.
         * 
         * The function sends the server a project name and version,
         * the server sends the version information (content and type) and the function returns it.
         */
        {
            NetworkStream serverStream = clientSocket.GetStream();

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("Preview.");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);

            outStream = System.Text.Encoding.ASCII.GetBytes(proName.Replace("\0", string.Empty) +"^"+ version.Replace("\0", string.Empty).Replace("OK", string.Empty));
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);
            string fileBuffSize = System.Text.Encoding.ASCII.GetString(inStream);

            outStream = System.Text.Encoding.ASCII.GetBytes("OK");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            inStream = new byte[Convert.ToInt32(fileBuffSize) + 100];
            serverStream.Read(inStream, 0, inStream.Length);

            outStream = System.Text.Encoding.ASCII.GetBytes("OK");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            return System.Text.Encoding.ASCII.GetString(inStream).Replace("\0", string.Empty);

        }

        public void Comment(string proName, string Comment, string Version)
        /* Sending a new comment to the server.
         * 
         * The function sends the comment information to the server (project, version and content), 
         * the server saves it.
         */
        {
            NetworkStream serverStream = clientSocket.GetStream();

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("Comment.");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);

            outStream = System.Text.Encoding.ASCII.GetBytes(proName.Replace("\0", string.Empty) + "^"+ Comment.Replace("\0", string.Empty) + "^" + Version.Replace("\0", string.Empty));
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);
        }

        public string Get_Comments(string proName)
        /* Getting the comments for a project.
         * 
         * The function sends the server a project name,
         * the server sends back the comments of the project, the function returns it.
         */
        {
            NetworkStream serverStream = clientSocket.GetStream();

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("GetComments.");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);

            outStream = System.Text.Encoding.ASCII.GetBytes(proName.Replace("\0", string.Empty));
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);

            return returndata.Replace("\0", string.Empty);
        }

        public string Search_User(string username)
        /* Searching a user by username.
         * 
         * The function sends a username to server,
         * returns what the server sent back (the server sends the user project or not found).
         */
        {
            NetworkStream serverStream = clientSocket.GetStream();

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("Search.");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);

            outStream = System.Text.Encoding.ASCII.GetBytes(username.Replace("\0", string.Empty));
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);
    
            return returndata.Replace("\0", string.Empty);
        }

        public string Get_UVersions(string proName, string username)
        /* Getting the latest version of another user project.
         * 
         * The function sends a project name to the server,
         * the server respondes, the function returns the response.
         */
        {
            NetworkStream serverStream = clientSocket.GetStream();

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("UVersions.");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);

            outStream = System.Text.Encoding.ASCII.GetBytes(proName.Replace("\0", string.Empty)+"^"+username.Replace("\0", string.Empty));
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);

            return returndata.Replace("\0", string.Empty).Replace("[(", string.Empty).Replace(",)]", string.Empty);
        }

        public string GetType(string proName, string Version)
        /* Getting a type of a version.
         * 
         * The function sends the server a project name and a version in that project,
         * the server sends the version type (extension), the function returns it.
         */
        {
            NetworkStream serverStream = clientSocket.GetStream();

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("GetType.");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);

            outStream = System.Text.Encoding.ASCII.GetBytes(proName.Replace("\0", string.Empty) + "^" + Version.Replace("\0", string.Empty));
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);

            return returndata.Replace("\0", string.Empty);

        }

    }
}
