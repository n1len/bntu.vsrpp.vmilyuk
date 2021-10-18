using System.Xml.Linq;

namespace bntu.vsrpp.vmilyuk.Core
{
    public class XMLEditor
    {
        private readonly XMLReader _reader;

        public XMLEditor(XMLReader reader)
        {
            _reader = reader;
        }

        public void CreateNewXML(string path)
        {
            var xml = _reader.ReadXML(path);
            foreach (XElement node in xml.Elements())
            {
                foreach (XElement child in node.Elements())
                {
                    foreach (XElement item in child.Elements())
                    {
                        if (item.Name.ToString().Equals("FIO") || item.Name.ToString().Equals("FullName"))
                        {
                            var str = item.Value.ToString().Split(' ');
                            item.Remove();
                            child.Add(
                                new XElement("FirstName", str[0]),
                                new XElement("LastName", str[1]),
                                new XElement("Surname", str[2])
                                );
                        }
                    }
                }
            }
            xml.Save(path.Remove(path.Length - 4) + "_output.xml");
        }
    }
}
