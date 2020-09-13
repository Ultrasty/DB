using System.Collections.Generic;

namespace API1.Models
{
    

    public class tablename
    {
        public string table;
    }

    public class tableinfo
    {
        public int countofrows;
        public int countofcolumns;
        public string[] tableheader;    
        public List<List<string>> tableinformation;
    }

    public class tablerow
    {
        public string[] tableinformation;
    }

    public class message
    {
        public string sender_id;
        public string receiver_id;
        public string content;
    }
}