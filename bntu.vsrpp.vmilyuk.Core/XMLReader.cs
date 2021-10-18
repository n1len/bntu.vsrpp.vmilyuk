using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace bntu.vsrpp.vmilyuk.Core
{
    public class XMLReader
    {
        private List<XElement> Node = new List<XElement>();
        private List<string> ChildNode = new List<string>();
        private List<string> AvaliableStringValues = new List<string>();

        public XDocument ReadXML(string path)
        {
            ClearAllLists();
            XDocument xml = XDocument.Load(path);
            foreach (XElement node in xml.Elements())
            {
                foreach (XElement child in node.Elements())
                {
                    Node.Add(child);
                    foreach (XElement item in child.Elements())
                    {
                        ChildNode.Add(item.Name.ToString());
                    }
                }
            }
            return xml;
        }

        public int GetNodesCount()
        {
            var count = ChildNode.Count();
            return count;
        }

        /// <summary>
        /// Method that displays the available options for operations
        /// </summary>
        /// <returns>Available options</returns>
        public List<string> GetAvailiableStrings()
        {
            var value = ChildNode.Distinct().ToList();
            foreach (string item in value)
            {
                if (Node.All(x => x.Elements().Any(x => x.Name.ToString().Equals(item))))
                    if (!AvaliableStringValues.Contains(item))
                        AvaliableStringValues.Add(item);
            }

            return AvaliableStringValues;
        }

        /// <summary>
        /// Getting a list of numbers for number operations
        /// </summary>
        /// <param name="element">Combobox selected item</param>
        /// <returns></returns>
        private List<int> GetIntValues(string element)
        {
            GetAvailiableStrings();
            List<int> values = new List<int>();

            foreach (var item in Node)
            {
                foreach (var i in item.Elements().Where(x => x.Name.ToString().Equals(element)))
                    if (Int32.TryParse(i.Value, out int temp))
                        values.Add(temp);
            }

            return values;
        }

        /// <summary>
        /// Getting a list of strings for string operations
        /// </summary>
        /// <param name="element">Combobox selected item</param>
        /// <returns></returns>
        private List<string> GetStringValues(string element)
        {
            GetAvailiableStrings();
            List<string> values = new List<string>();

            foreach (var item in Node)
            {
                foreach (var i in item.Elements().Where(x => x.Name.ToString().Equals(element)))
                    if (!Int32.TryParse(i.Value, out int temp))
                        values.Add(i.Value.ToString());
            }

            return values;
        }

        private void ClearAllLists()
        {
            Node.Clear();
            ChildNode.Clear();
            AvaliableStringValues.Clear();
        }

        #region ShitMethodsToDisplayResult
        public int GetMaxLength(string element)
        {
            var str = GetStringValues(element).OrderByDescending(s => s.Length).First();
            return str.Length;
        }

        public int GetMinLength(string element)
        {
            var str = GetStringValues(element).OrderBy(s => s.Length).First();
            return str.Length;
        }

        public double GetAverageLength(string element)
        {
            var average = GetStringValues(element).Average(x => x.Length);
            return average;
        }

        public int GetMax(string element)
        {
            var max = GetIntValues(element).Max();
            return max;
        }

        public int GetMin(string element)
        {
            var min = GetIntValues(element).Min();
            return min;
        }

        public double GetAverage(string element)
        {
            var average = GetIntValues(element).Average();
            return average;
        }
        #endregion
    }
}
