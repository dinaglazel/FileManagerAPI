using DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public static class DB
    {
        public static List<FileData> FileList = new List<FileData>()
        {
            new FileData() {Id = 1, Name = "תמונה ילדים", Type = FileTypes.jpg, Size = 350, encoded = false, author = "חיים לוי", dateCreated = DateTime.Now.AddDays(-10)},
            new FileData() {Id = 2, Name = "מכתב ברכה", Type = FileTypes.docx, Size = 16, encoded = false, author = "אהרון כהן", dateCreated = DateTime.Now.AddDays(-55)},
            new FileData() {Id = 3, Name = "סיכום פרטים", Type = FileTypes.pdf, Size = 100, encoded = false, author = "חיים לוי", dateCreated = DateTime.Now.AddDays(-2)},
            new FileData() {Id = 4, Name = "מצגת ארוכה", Type = FileTypes.pptx, Size = 190500, encoded = false, author = "דוד שמעון", dateCreated = DateTime.Now.AddDays(-15)}
        };

        public static bool UpdateFile(FileData file)
        {
            FileData prevFile = FileList.Where(x => x.Id == file.Id).FirstOrDefault();
            if (prevFile != null)
            {
                prevFile.Name = file.Name;
                prevFile.Type = file.Type;
                prevFile.Size = file.Size;
                prevFile.dateCreated = file.dateCreated;
                prevFile.encoded = file.encoded;
                prevFile.author = file.author;
                return true;
            }
            else
                return false;
        }
    }
}
