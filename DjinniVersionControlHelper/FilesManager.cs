﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DjinniVersionControlHelper
{
    class FilesManager
    {
        private string gitModPath;
        private string editorModPath;

        public FilesManager(string gitModPath, string editorModPath)
        {
            UpdatePaths(gitModPath, editorModPath);
        }

        public void UpdatePaths(string gitModPath, string editorModPath)
        {
            this.gitModPath = gitModPath;
            this.editorModPath = editorModPath;
        }

        public void CopyFilesToGitDirectory()
        {
            string[] files = Directory.GetFiles(editorModPath);

            if (files != null)
            {
                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    if (File.Exists(fileInfo.FullName))
                    {
                        string destFile = Path.Combine(gitModPath, fileInfo.Name);
                        File.Copy(fileInfo.FullName, destFile, true);
                    }
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        public void CopyFilesToEditorDirectory()
        {
            string[] files = Directory.GetFiles(gitModPath);

            if (files != null)
            {
                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    if (File.Exists(fileInfo.FullName))
                    {
                        string destFile = Path.Combine(editorModPath, fileInfo.Name);
                        File.Copy(fileInfo.FullName, destFile, true);
                    }
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
    }
}
