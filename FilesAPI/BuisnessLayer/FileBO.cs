using BuisnessLayer.Interfaces;
using DAL;
using DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuisnessLayer
{
    public class FileBO : IFileBO
    {
        private readonly IMailBO _mailBO;
        public FileBO(IMailBO mailBO)
        {
            _mailBO = mailBO;
        }
        public List<FileData> GetAllFiles()
        {
            return DB.FileList;
        }

        public bool SaveFile(FileData file)
        {
            try
            {
                if (file.Id != null) //update
                {
                    if (!DB.UpdateFile(file))
                        return false;
                }
                else //insert
                {
                    file.Id = DB.FileList.Max(x => x.Id) + 1;
                    DB.FileList.Add(file);
                }

                if (file.Size / 1024 > 100)//the file store in KB in the DB, if the file > 100MB need to send by mail
                {
                    SendMail(file);
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        private void SendMail(FileData file)
        {
            try
            {
                MailRequest req = new MailRequest();
                req.ToEmail = "dina.glazel@gmail.com";
                req.Body = "file: " + file.Name + " big than 100MB";
                req.Subject = "file big than 100MB!";
                _mailBO.SendEmailAsync(req);

            }
            catch (Exception ex)
            {
                throw (ex.InnerException);
            }
        }
    }
}
