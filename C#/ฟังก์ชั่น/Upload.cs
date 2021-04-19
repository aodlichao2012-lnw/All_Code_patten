        protected void UploadTextFile(object sender, EventArgs e)
        {
            // string filePath = Server.MapPath("~/Files/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
            // if (File.Exists(filePath)) { File.Delete(filePath); }
            // FileUpload1.SaveAs(filePath);

            HttpPostedFile postedFile = FileUpload1.PostedFile;
            string filePath = "";

            if (postedFile != null)
            {
                string path = Server.MapPath("~/FilesUploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                filePath = path + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(filePath);

                //<---->

                string tmpData = System.IO.File.ReadAllText(filePath, System.Text.Encoding.Default);

                string fileName = path + "tmpDataOfficer.txt";

                FileInfo pathFile = new FileInfo(fileName);

                FileStream fs = null;
                try
                {
                    if (IsFileLocked(pathFile))
                    {
                        fs = new FileStream(fileName, FileMode.CreateNew);
                    }
                    else
                    {
                        System.IO.File.Delete(fileName);
                        fs = new FileStream(fileName, FileMode.CreateNew);
                    }
                    using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8))
                    {
                        //writer.Write(textToAdd);
                        foreach (string row in tmpData.Split('\n'))
                        {
                            if (!string.IsNullOrEmpty(row))
                            {
                                writer.Write(row);
                            }
                        }
                    }
                }
                finally
                {
                    //if (fs != null)
                    //    fs.Dispose();
                }

                //<---->

                //Create a DataTable.
                DataTable dt = new DataTable();

                for(int j = 0; j < 90; j++)
                {
                    dt.Columns.Add(new DataColumn("F" + j, typeof(string)));
                }
                

                //Read the contents of CSV file.
                string textData = System.IO.File.ReadAllText(fileName, System.Text.Encoding.UTF8);

                //Execute a loop over the rows.
                foreach (string row in textData.Split('\r'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        dt.Rows.Add();
                        int i = 0;

                        //Execute a loop over the columns.
                        foreach (string cell in row.Split('$'))
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = cell;
                            i++;
                        }
                    }
                }

                if (!dt.Rows.Count.Equals(0))
                {
                    DataRow Top = dt.Rows[0];
                    //DataRow Low = dt.Rows[89];
                    dt.Rows.Remove(Top);
                    //dt.Rows.Remove(Low);
                    dt.Columns.Remove(dt.Columns[89]);
                }

                //DataTable dataInDataBase = Function_CheckDataForChange("2563", "10");
                Function_SqlBulkCopy(dt);
                Function_CheckUpdateData(dt,"2563","1");


                System.IO.File.Delete(fileName);

            }
        }