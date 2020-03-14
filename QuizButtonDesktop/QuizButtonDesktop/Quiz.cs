using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace QuizButtonDesktop
{
    public class Quiz
    {
        private List<Team> _teams;
        public List<Team> Teams
        {
            get { return _teams; }
            set { _teams = value; }
        }

        public Quiz()
        {
            _teams = new List<Team>();
        }

        public String Serialize()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Quiz));
            using (StringWriter sw = new StringWriter())
            {
                serializer.Serialize(sw, this);
                return sw.ToString();
            }
        }

        public static Quiz Deserialize(String xml)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Quiz));
            using (StringReader sr = new StringReader(xml))
            {
                return (Quiz)deserializer.Deserialize(sr);
            }
        }

        public Team byButtonId(String id)
        {
            return _teams.FirstOrDefault(x => x.ButtonId.Equals(id));
        }
    }
}
