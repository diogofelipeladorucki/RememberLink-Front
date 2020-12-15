using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RememberLink.Models
{
    public class Category
    {
        [DisplayName("ID")]
        public string _id { get; set; }

        [DisplayName("COR")]
        public string color { get; set; }

        [DisplayName("TÍTULO")]
        public string titleCategory { get; set; }

        [DisplayName("DESCRIÇÃO")]
        public string descriptionCategory { get; set; }

    }

    public class LinksNotes
    {
        [DisplayName("ID")]
        public string _id { get; set; }

        [DisplayName("TÍTULO")]
        public string titleLink { get; set; }

        [DisplayName("LINK")]
        public string link { get; set; }

        [DisplayName("DESCRIÇÃO")]
        public string descriptionLink { get; set; }

    }

    public class LinksNotesRequest
    {

        public string titleLink { get; set; }
        public string link { get; set; }
        public string descriptionLink { get; set; }
        public string category { get; set; }

    }



}
