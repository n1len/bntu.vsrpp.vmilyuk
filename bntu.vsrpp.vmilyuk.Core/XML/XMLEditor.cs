using System.Xml.Linq;

namespace bntu.vsrpp.vmilyuk.Core.XML
{
    public class XMLEditor
    {
        private readonly XMLReader reader;

        #region Const variables
        private const int FileExtensionLength = 4;

        private const string PartOfFileOutputNameWithFileExtension = "_output.xml";
        #endregion

        public XMLEditor(XMLReader reader)
        {
            this.reader = reader;
        }

        /// <summary>
        /// Create new xml, after changing file
        /// </summary>
        /// <param name="path"></param>
        public void CreateNewXML(string path)
        {
            var xml = reader.ReadXML(path);
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
            xml.Save(path.Remove(path.Length - FileExtensionLength) + PartOfFileOutputNameWithFileExtension);
        }
    }
}
