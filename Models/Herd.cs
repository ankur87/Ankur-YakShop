using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Herd : IHerd
    {
        public Herd(IList<IYak> yaks)
        {
            this.yaks = yaks;
        }
        public string Name { get; set; }
        public IList<IYak> yaks { get; set; }

        public double MilkStock { get; set; }

        public int Skins { get; set; }

    }

   
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class herd
    {

        private herdLabyak[] labyakField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("labyak")]
        public herdLabyak[] labyak
        {
            get
            {
                return this.labyakField;
            }
            set
            {
                this.labyakField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class herdLabyak
    {

        private string nameField;

        private decimal ageField;

        private string sexField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal age
        {
            get
            {
                return this.ageField;
            }
            set
            {
                this.ageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string sex
        {
            get
            {
                return this.sexField;
            }
            set
            {
                this.sexField = value;
            }
        }
    }   
}
