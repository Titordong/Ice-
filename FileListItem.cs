using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ice云盘
{
    class FileListItem
    {
        public enum Filetype
        {
            file=0,
            folder=1
        }
        public Filetype type { get; set; }
        public string name { get; set; }
        public FileListItem()
        {

        }
        public FileListItem(Filetype type,string name)
        {
            this.type = type;
            this.name = name;
        }
        public string Background
        {
            get
            {
                return type.Equals(Filetype.file) ? "./Public/Image/ic_file.png" : "./Public/Image/ic_folder.png";
            }
        }
    }
}
