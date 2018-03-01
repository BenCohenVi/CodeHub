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
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        private string ip;
        private int port;
        private string projects;
        private string[] text_extensions = {"html","xml","css","svg","json",
        "c","cpp","h","cs","js","py","java","rb","pl","php","sh",
        "txt","tex","markdown","asciidoc","rtf","ps","ini","cfg","rc","reg","csv","tsv", "png"};
        public ClientSocket(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
            this.clientSocket.Connect(this.ip, this.port);
        }


        public bool Try_Login(string username, string password)
        {
            NetworkStream serverStream = clientSocket.GetStream();

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("Login");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);

            outStream = System.Text.Encoding.ASCII.GetBytes(username+","+password);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);

            return Convert.ToBoolean(System.Text.Encoding.ASCII.GetString(inStream));
        }

        public void Register(string username, string password)
        {
            NetworkStream serverStream = clientSocket.GetStream();

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("Register");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);

            outStream = System.Text.Encoding.ASCII.GetBytes(username + "," + password);
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
        {
            bool valiable = false;
            foreach (string ext in this.text_extensions)
            {
                if (fileInfo.Split('.')[1] == ext)
                {
                    valiable = true;
                    break;
                }
            }
            if (!valiable)
            {
                throw new System.DllNotFoundException();
            }

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

        public string Update_Project(string project, string data, string fileInfo)
        {
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
                throw new System.DivideByZeroException();
            }

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

            return "Done";
        }



        public string Manage_Branch(string project, string fileP, string fileInfo, string version)
        {
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
                throw new System.DivideByZeroException();
            }

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

            if (System.Text.Encoding.ASCII.GetString(inStream).Replace("\0", string.Empty) == "NO")
            {
                throw new System.FieldAccessException();
            }

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

            return System.Text.Encoding.ASCII.GetString(inStream);
        }

        public string Get_Preview(string proName, string version)
        {
            NetworkStream serverStream = clientSocket.GetStream();

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("Preview.");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);

            outStream = System.Text.Encoding.ASCII.GetBytes(proName.Replace("\0", string.Empty) +"^"+ version.Replace("\0", string.Empty));
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

            return System.Text.Encoding.ASCII.GetString(inStream).Replace("\0", string.Empty);

        }

        public void Comment(string proName, string Comment)
        {
            NetworkStream serverStream = clientSocket.GetStream();

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("Comment.");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);

            outStream = System.Text.Encoding.ASCII.GetBytes(proName.Replace("\0", string.Empty) + "^"+ Comment.Replace("\0", string.Empty));
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);
        }

        public string Get_Comments(string proName)
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

        public void Send_Test(string fileP)
        {
            NetworkStream serverStream = clientSocket.GetStream();

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("Update.");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);

            FileInfo file = new FileInfo(fileP);
            string lenghtf = file.Length.ToString();
            outStream = System.Text.Encoding.ASCII.GetBytes(lenghtf);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();


            inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);

            using (FileStream fs = File.Open(fileP, FileMode.Open))
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

    }
}
