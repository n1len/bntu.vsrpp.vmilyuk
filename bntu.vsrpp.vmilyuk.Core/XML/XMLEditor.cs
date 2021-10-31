using System;
using System.Collections.Generic;
using System.Linq;
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
                    foreach (string nameChildNode in GetChildNodeNames(xml))
                    {
                        if (child.Elements().ToList().Find(x => x.Name.ToString().Equals(nameChildNode)) == null)
                        {
                            XElement childNode = GetChildNodeToAddElseReturnsNull(nameChildNode, path);
                            if (Int32.TryParse(childNode.Value, out int temp))
                            {
                                child.Add(new XElement(childNode.Name, 0));
                            }
                            else
                            {
                                child.Add(new XElement(childNode.Name, "N/A"));
                            }
                        }
                    }

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

        private XElement GetChildNodeToAddElseReturnsNull(string name, string path)
        {
            XDocument xml = reader.ReadXML(path);
            foreach (XElement rootNode in xml.Elements())
            {
                foreach (XElement node in rootNode.Elements())
                {
                    XElement childNode = node.Elements().ToList().Find(x => x.Name.ToString().Equals(name));
                    if (childNode != null)
                    {
                        return childNode;
                    }
                }
            }
            return null;
        }

        private List<string> GetChildNodeNames(XDocument xDocument)
        {
            List<string> childNodeNames = new List<string>();

            foreach (XElement rootNode in xDocument.Elements())
            {
                foreach (XElement node in rootNode.Elements())
                {
                    foreach (XElement childNode in node.Elements())
                    {
                        if ((!childNodeNames.Contains(childNode.Name.ToString())) && !childNode.Name.ToString().Equals("FIO") && !childNode.Name.ToString().Equals("FullName")
                            && !childNode.Name.ToString().Equals("LastName") && !childNode.Name.ToString().Equals("FirstName") && !childNode.Name.ToString().Equals("Surname"))
                        {
                            childNodeNames.Add(childNode.Name.ToString());
                        }
                    }
                }
            }

            return childNodeNames;
        }
    }
}
