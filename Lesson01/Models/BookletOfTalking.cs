namespace Lesson01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LangLearn.BookletOfTalking")]
    public partial class BookletOfTalking
    {
        public int ID { get; set; }

        public int MainGroupID { get; set; }

        public string WordAz { get; set; }

        public string WordEn { get; set; }

        public string WordRus { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CreateDate { get; set; }
    }
}
