using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace QuizButtonDesktop
{
    public class Team
    {
        public String Name;

        [XmlElement("Image")]
        public byte[] ImageData
        {
            get
            {
                if(Image == null)
                {
                    return new byte[0];
                }
                using (MemoryStream stream = new MemoryStream())
                {
                    Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    return stream.ToArray();
                }
            }
            set
            {
                if(value.Length == 0)
                {
                    Image = null;
                    return;
                }
                using (MemoryStream stream = new MemoryStream(value))
                {
                    Image = System.Drawing.Image.FromStream(stream);
                }
            }
        }

        [XmlIgnore]
        public Image Image;

        [XmlIgnore]
        private byte[] _soundData;
        public byte[] Sound
        {
            get { return _soundData; }
            set { _soundData = value; }
        }

        public String ButtonId;

        public int Score;

        public Team()
        {
            _soundData = new byte[0];
            Image = null;
        }
        
        public String Serialize()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Team));
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, this);
                return writer.ToString();
            }
        }
        
        public static Team DeSerialize(String data)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Team));
            return (Team)deserializer.Deserialize(new StringReader(data));
        }

        public override bool Equals(object obj)
        {
            if(obj.GetType() != typeof(Team))
            {
                return false;
            }
            return ((Team)obj).GetHashCode() == this.GetHashCode();
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
